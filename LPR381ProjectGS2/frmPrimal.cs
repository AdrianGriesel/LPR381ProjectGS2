using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static LinearProgrammingSolver.LPInputParser;
using LPR381ProjectGS2.Domain.Algorithms;

namespace LPR381ProjectGS2
{

    public partial class frmPrimal : Form
    {
        private SimplexResult _result;
        private int _iterIndex = 0;
        private LPModel _model;

        public frmPrimal()
        {
            InitializeComponent();
        }

        private void frmPrimal_Load(object sender, EventArgs e)
        {
            // grid sensible defaults
            gridTableau.ReadOnly = true;
            gridTableau.AllowUserToAddRows = false;
            gridTableau.RowHeadersVisible = true;
            gridTableau.ColumnHeadersVisible = true;

            gridOptimal.ReadOnly = true;
            gridOptimal.AllowUserToAddRows = false;
            gridOptimal.RowHeadersVisible = true;
            gridOptimal.ColumnHeadersVisible = true;

            // buttons & status
            btnSolve.Enabled = false;
            btnExport.Enabled = false;
            lblStatus.Text = "Status: load an LP file to begin.";
        }

        // ===================== UI Events =====================

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Open LP Input File"
            })
            {
                if (ofd.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    _model = ParseInputFile(ofd.FileName);  // from LPInputParser
                    _result = null;
                    _iterIndex = 0;

                    lstIterations.Items.Clear();
                    ClearGrid(gridTableau);
                    ClearGrid(gridOptimal);

                    lblStatus.Text = "Status: model loaded. Click Solve.";
                    btnSolve.Enabled = true;
                    btnExport.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Parse error:\n" + ex.Message, "Input Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (_model == null)
            {
                MessageBox.Show(this, "Load an LP first.", "No Model",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var solver = new PrimalSimplexSolver();
            _result = solver.Solve(_model);

            // populate the iteration list
            lstIterations.Items.Clear();
            for (int i = 0; i < _result.Iterations.Count; i++)
            {
                var snap = _result.Iterations[i];
                string label = $"Iteration {i + 1}";
                if (snap.EnteringColumn.HasValue && snap.LeavingRow.HasValue)
                {
                    var enterName = snap.ColumnLabels[snap.EnteringColumn.Value];
                    var leaveName = snap.RowLabels[snap.LeavingRow.Value];
                    label += $"  (enter {enterName}, leave {leaveName})";
                }
                lstIterations.Items.Add(label);
            }

            // show first tableau if any
            if (_result.Iterations.Count > 0)
            {
                _iterIndex = 0;
                lstIterations.SelectedIndex = 0; // triggers RenderIteration
            }
            else
            {
                ClearGrid(gridTableau);
            }

            // render optimal tableau (separate grid on the form)
            RenderOptimalTableau();

            // show status
            lblStatus.Text = $"Status: {_result.Status} — {_result.TerminationReason}";
            btnExport.Enabled = true;
        }

        // save file - export 
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_result == null)
            {
                MessageBox.Show(this, "Run the solver first.", "No Result",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            using (var sfd = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = "output.txt"
            })
            {
                if (sfd.ShowDialog(this) != DialogResult.OK) return;

                OutputWriter.WriteToFile(sfd.FileName, _result);
                MessageBox.Show(this, "Exported:\n" + sfd.FileName);
            }
        }

        private void lstIterations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_result == null) return;
            if (lstIterations.SelectedIndex < 0) return;

            _iterIndex = lstIterations.SelectedIndex;
            RenderIteration(_iterIndex);
        }

        // ===================== Rendering helpers =====================

        private void RenderIteration(int idx)
        {
            var snap = _result.Iterations[idx];

            gridTableau.SuspendLayout();
            gridTableau.Columns.Clear();
            gridTableau.Rows.Clear();

            // normal columns
            for (int j = 0; j < snap.ColumnLabels.Length; j++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = snap.ColumnLabels[j],
                    Name = "col" + j,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                gridTableau.Columns.Add(col);
            }

            // extra column showing iteration number (far right)
            var iterCol = new DataGridViewTextBoxColumn
            {
                HeaderText = "Iteration " + (idx + 1),
                Name = "iterCol",
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            gridTableau.Columns.Add(iterCol);

            // rows
            for (int i = 0; i < snap.RowLabels.Length; i++)
            {
                int rowIndex = gridTableau.Rows.Add();
                gridTableau.Rows[rowIndex].HeaderCell.Value = snap.RowLabels[i];

                for (int j = 0; j < snap.ColumnLabels.Length; j++)
                {
                    gridTableau.Rows[rowIndex].Cells[j].Value =
                        Math.Round(snap.Matrix[i, j], 3).ToString("0.000");
                }
                // blank cell for the iteration column
                gridTableau.Rows[rowIndex].Cells[snap.ColumnLabels.Length].Value = "";
            }

            gridTableau.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridTableau.ResumeLayout();
        }

        private void RenderOptimalTableau()
        {
            gridOptimal.SuspendLayout();
            gridOptimal.Columns.Clear();
            gridOptimal.Rows.Clear();

            if (_result != null &&
                _result.Status == SimplexStatus.Optimal &&
                _result.Iterations.Count > 0)
            {
                var finalSnap = _result.Iterations[_result.Iterations.Count - 1];

                // flip z-row for display only if this was a max problem
                var displaySnap = finalSnap;
                if (_model != null && _model.IsMaximization)
                {
                    var M = (double[,])finalSnap.Matrix.Clone();
                    int z = M.GetLength(0) - 1;
                    int cols = M.GetLength(1);
                    for (int j = 0; j < cols; j++) M[z, j] = -M[z, j];

                    displaySnap = TableauSnapshot.From(
                        M, finalSnap.ColumnLabels, finalSnap.RowLabels,
                        finalSnap.EnteringColumn, finalSnap.LeavingRow);
                }

                FillGridWithSnapshot(gridOptimal, displaySnap);
            }
            gridOptimal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridOptimal.ResumeLayout();
        }

        private void FillGridWithSnapshot(DataGridView grid, TableauSnapshot snap)
        {
            grid.SuspendLayout();
            grid.Columns.Clear();
            grid.Rows.Clear();

            // columns
            for (int j = 0; j < snap.ColumnLabels.Length; j++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = snap.ColumnLabels[j],
                    Name = "col" + j,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                grid.Columns.Add(col);
            }

            // rows
            for (int i = 0; i < snap.RowLabels.Length; i++)
            {
                int rowIndex = grid.Rows.Add();
                grid.Rows[rowIndex].HeaderCell.Value = snap.RowLabels[i];

                for (int j = 0; j < snap.ColumnLabels.Length; j++)
                {
                    grid.Rows[rowIndex].Cells[j].Value =
                        Math.Round(snap.Matrix[i, j], 3).ToString("0.000");
                }
            }

            grid.ResumeLayout();
        }

        private void ClearGrid(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();
        }

        // ------- empty handlers kept so the Designer won’t complain -------
        private void gridOptimal_CellContentClick(object sender, DataGridViewCellEventArgs e) { /* not used */ }
        private void gridTableau_CellContentClick(object sender, DataGridViewCellEventArgs e) { /* not used */ }
    }
}
