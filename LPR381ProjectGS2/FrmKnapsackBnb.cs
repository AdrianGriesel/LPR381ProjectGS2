using LPR381ProjectGS2.Domain.Algorithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPR381ProjectGS2
{
    public partial class FrmKnapsackBnb : Form
    {
        private readonly LinearProgrammingSolver.LPInputParser.LPModel _model;
        private KnapsackRunCache _lastRun;


        private void FrmKnapsackBnb_Load(object sender, EventArgs e)
        {
            // safe defaults on open
            if (btnExport != null) btnExport.Enabled = false;

            // if your columns were added in the Designer, make sure we don't add them again:
            if (gridIterations != null)
            {
                gridIterations.AutoGenerateColumns = false;
                
            }
        }

        public FrmKnapsackBnb(LinearProgrammingSolver.LPInputParser.LPModel model)
        {
            InitializeComponent();
            _model = model ?? throw new ArgumentNullException(nameof(model));
            Text = "Branch & Bound - Knapsack";

            // set up grid columns if you didn't add them in the designer
            gridIterations.AutoGenerateColumns = false;
            if (gridIterations.Columns.Count == 0)
            {
                gridIterations.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colIter",
                    HeaderText = "Iter",
                    DataPropertyName = "Iteration",
                    Width = 60,
                    ReadOnly = true
                });
                gridIterations.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colLog",
                    HeaderText = "Log",
                    DataPropertyName = "Log",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });
            }


            if (btnExport != null) btnExport.Enabled = false;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                // Map LP to knapsack (first constraint is weights/capacity)
                var values = _model.ObjectiveCoefficients.ToArray();
                var first = _model.Constraints.FirstOrDefault();
                if (first == null)
                {
                    MessageBox.Show(this, "No constraints found.", "Invalid input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var weights = first.Coefficients.ToArray();
                var capacity = first.RightHandSide;

                if (weights.Length != values.Length)
                {
                    MessageBox.Show(this, "Objective and constraint variable counts differ.",
                        "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Solve
                var solver = KnapSackSolver.FromLPModel(_model);
                solver.Solve();
                var (bestVal, bestItems) = solver.GetSolution();

                // Show summary
                txtCapacity.Text = capacity.ToString("F3", CultureInfo.InvariantCulture);
                txtBestValue.Text = bestVal.ToString("F3", CultureInfo.InvariantCulture);
                txtItemsTaken.Text = "[" + string.Join(", ", bestItems) + "]";

                // Bind iterations
                var rows = solver.IterationLog
                    .Select((line, i) => new { Iteration = i + 1, Log = line })
                    .ToList();
                gridIterations.DataSource = rows;

                // Cache for export
                _lastRun = new KnapsackRunCache
                {
                    Title = "Knapsack (Branch & Bound)",
                    Values = values,
                    Weights = weights,
                    Capacity = capacity,
                    Iterations = new List<string>(solver.IterationLog),
                    BestValue = bestVal,
                    BestItems = ToBitArray(bestItems, values.Length)
                };

                btnExport.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Solve failed:\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_lastRun == null)
            {
                MessageBox.Show(this, "Run the solver first.", "Nothing to export",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog
            {
                Title = "Save Knapsack Output",
                Filter = "Text files (*.txt)|*.txt",
                FileName = $"run_{DateTime.Now:yyyyMMdd_HHmmss}_knapsack.txt"
            }) 
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                OutputWriter.WriteKnapsackRun(
                    sfd.FileName,
                    _lastRun.Title,
                    _lastRun.Values,
                    _lastRun.Weights,
                    _lastRun.Capacity,
                    _lastRun.Iterations,
                    _lastRun.BestValue,
                    _lastRun.BestItems
                );
                MessageBox.Show(this, "Exported.", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private static BitArray ToBitArray(IEnumerable<int> oneBasedIndices, int length)
        {
            var bits = new BitArray(length);
            foreach (var idx in oneBasedIndices)
                if (idx >= 1 && idx <= length) bits[idx - 1] = true;
            return bits;
        }

        private sealed class KnapsackRunCache
        {
            public string Title { get; set; }
            public double[] Values { get; set; }
            public double[] Weights { get; set; }
            public double Capacity { get; set; }
            public List<string> Iterations { get; set; }
            public double BestValue { get; set; }
            public BitArray BestItems { get; set; }
        }
    }
}
