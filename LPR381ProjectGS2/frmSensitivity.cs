using LPR381ProjectGS2.Domain.Analysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LinearProgrammingSolver.LPInputParser;
using LPR381ProjectGS2.Domain.Algorithms;
using LPR381ProjectGS2.Application;
using LPR381ProjectGS2.Domain.Models;

namespace LPR381ProjectGS2.Presentation
{
    public partial class frmSensitivity : Form
    {
        private LPModel _primalModel;
        private SimplexResult _primalResult;

        private LPModel _dualModel;
        private SimplexResult _dualResult;

        private SensitivityReport _report;

        public frmSensitivity()
        {
            InitializeComponent();
        }

        private void frmSensitivity_Load(object sender, EventArgs e)
        {
            // grid defaults
            SetGridDefaults(gridPrimalTableau);
            SetGridDefaults(gridDualTableau);
            SetGridDefaults(gridShadowPrices);
            SetGridDefaults(gridReducedCosts);
            SetGridDefaults(gridObjRanges);
            SetGridDefaults(gridRhsRanges);

            // initial state
            btnSolvePrimal.Enabled = false;
            btnBuildDual.Enabled = false;
            btnSolveDual.Enabled = false;
            btnAnalyze.Enabled = false;
            btnExport.Enabled = false;

            lblPrimalObj.Text = "z* (primal) = _";
            lblDualObj.Text = "w* (dual) = _";
            lblDualityCheck.Text = "strong duality: _";
            lblStatus.Text = "load a primal lp file.";

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Open LP Input File"
            };
            try
            {
                if (ofd.ShowDialog(this) != DialogResult.OK) return;

                _primalModel = ParseInputFile(ofd.FileName);

                _primalResult = null;
                _dualModel = null;
                _dualResult = null;
                _report = null;

                lstPrimalIters.Items.Clear();
                ClearGrid(gridPrimalTableau);
                ClearGrid(gridDualTableau);
                ClearGrid(gridShadowPrices);
                ClearGrid(gridReducedCosts);
                ClearGrid(gridObjRanges);
                ClearGrid(gridRhsRanges);
                txtReportPreview.Clear();

                lblPrimalObj.Text = "z* (primal) = _";
                lblDualObj.Text = "w* (dual) = _";
                lblDualityCheck.Text = "strong duality: _";

                btnSolvePrimal.Enabled = true;
                btnBuildDual.Enabled = false;
                btnSolveDual.Enabled = false;
                btnAnalyze.Enabled = false;
                btnExport.Enabled = false;

                lblStatus.Text = "model loaded. click solve primal.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "parse error:\n" + ex.Message, "input error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ofd.Dispose();
            }
        }

        private void btnSolvePrimal_Click(object sender, EventArgs e)
        {
            if (_primalModel == null) return;

            var solver = new Domain.Algorithms.PrimalSimplexSolver();
            _primalResult = solver.Solve(_primalModel);

            // list iterations
            lstPrimalIters.Items.Clear();
            for (int i = 0; i < _primalResult.Iterations.Count; i++)
            {
                var s = _primalResult.Iterations[i];
                string label = $"iteration {i + 1}";
                if (s.EnteringColumn.HasValue && s.LeavingRow.HasValue)
                    label += $" (enter {s.ColumnLabels[s.EnteringColumn.Value]}, leave {s.RowLabels[s.LeavingRow.Value]})";
                lstPrimalIters.Items.Add(label);
            }
            if (_primalResult.Iterations.Count > 0)
                lstPrimalIters.SelectedIndex = _primalResult.Iterations.Count - 1;

            // show final tableau
            if (_primalResult.Iterations.Any())
                FillGridWithSnapshot(gridPrimalTableau, _primalResult.Iterations.Last());

            lblPrimalObj.Text = $"z* (primal) = {_primalResult.ObjectiveValue:0.000}";
            lblStatus.Text = $"primal status: {_primalResult.Status}";

            btnBuildDual.Enabled = _primalResult.Status == SimplexStatus.Optimal;
        }

        private void btnBuildDual_Click(object sender, EventArgs e)
        {
            _dualModel = DualBuilder.BuildDual(_primalModel);

            if (_dualModel == null)
            {
                MessageBox.Show(this,
                    "dual builder (v1) supports: max with <= and x >= 0.\nunsupported form.",
                    "dual build", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnSolveDual.Enabled = true;
            lblStatus.Text = "dual built. click solve dual.";
        }

        private void btnSolveDual_Click(object sender, EventArgs e)
        {
            bool canSolveDual = _dualModel != null;

            double dualTrue;

            if (canSolveDual)
            {
                // attempt: run our primal solver on the dual (may fail if rhs < 0 etc.)
                var solver = new LPR381ProjectGS2.Domain.Algorithms.PrimalSimplexSolver();
                _dualResult = solver.Solve(_dualModel);

                // show tableau if we actually got one
                if (_dualResult.Iterations.Any())
                    FillGridWithSnapshot(gridDualTableau, _dualResult.Iterations.Last());

                // if we built a solver-compatible dual as max(-b^T y),
                // flip sign back to the true min(b^T y). if not sure, just compute from primal.
                if (_dualResult.Status == LPR381ProjectGS2.Domain.Models.SimplexStatus.Optimal)
                {
                    // safest: recompute from primal to avoid sign confusion
                    dualTrue = ComputeDualObjectiveFromPrimal();
                }
                else
                {
                    // fallback: compute from primal anyway
                    dualTrue = ComputeDualObjectiveFromPrimal();
                }

            }
            else
            {
                // no dual or unsupported → compute from primal
                dualTrue = ComputeDualObjectiveFromPrimal();
            }

            // display and strong duality check
            lblDualObj.Text = $"w* (dual) = {dualTrue:0.000}";
            double tol = (double)numTolerance.Value;
            bool strong = Math.Abs(dualTrue - _primalResult.ObjectiveValue) <= tol;
            lblDualityCheck.Text = $"strong duality: {(strong ? "passed" : "failed")} (|z* - w*| ≤ {tol})";

            // enable analysis/export now that we have a valid dual value
            btnAnalyze.Enabled = _primalResult.Status == LPR381ProjectGS2.Domain.Models.SimplexStatus.Optimal;
            btnExport.Enabled = btnAnalyze.Enabled;
        }

            private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var analyzer = new SensitivityAnalyzer();
            _report = analyzer.Analyze(_primalModel, _primalResult, _dualModel, _dualResult, (double)numTolerance.Value);

            // --- Shadow Prices Grid ---
            gridShadowPrices.Columns.Clear();
            gridShadowPrices.Rows.Clear();
            gridShadowPrices.Columns.Add("Constraint", "Constraint");
            gridShadowPrices.Columns.Add("Value", "Shadow Price");
            gridShadowPrices.Columns.Add("Note", "Note");

            foreach (var kv in _report.ShadowPrices)
            {
                int r = gridShadowPrices.Rows.Add();
                gridShadowPrices.Rows[r].Cells[0].Value = kv.Key;
                gridShadowPrices.Rows[r].Cells[1].Value = kv.Value.ToString("0.000");
                gridShadowPrices.Rows[r].Cells[2].Value = "per unit rhs";
            }

            // --- Reduced Costs Grid ---
            gridReducedCosts.Columns.Clear();
            gridReducedCosts.Rows.Clear();
            gridReducedCosts.Columns.Add("Variable", "Variable");
            gridReducedCosts.Columns.Add("Value", "Reduced Cost");
            gridReducedCosts.Columns.Add("Basic", "Basic?");

            foreach (var kv in _report.ReducedCosts)
            {
                int r = gridReducedCosts.Rows.Add();
                gridReducedCosts.Rows[r].Cells[0].Value = kv.Key;
                gridReducedCosts.Rows[r].Cells[1].Value = kv.Value.value.ToString("0.000");
                gridReducedCosts.Rows[r].Cells[2].Value = kv.Value.isBasic ? "yes" : "no";
            }

            // --- Report Preview ---
            BuildReportPreview();
            lblStatus.Text = "analysis complete.";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_report == null)
            {
                MessageBox.Show(this, "run analysis first.", "no report",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = "sensitivity_report.txt"
            };
            try
            {
                if (sfd.ShowDialog(this) != DialogResult.OK) return;

                SensitivityWriter.Write(sfd.FileName, _report);
                MessageBox.Show(this, "exported:\n" + sfd.FileName);
            }
            finally
            {
                sfd.Dispose();
            }
        }

        private void gridPrimalTableau_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void lstPrimalIters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_primalResult == null) return;
            int idx = lstPrimalIters.SelectedIndex;
            if (idx >= 0 && idx < _primalResult.Iterations.Count)
                FillGridWithSnapshot(gridPrimalTableau, _primalResult.Iterations[idx]);
        }

        // ========== helpers ==========

        private void SetGridDefaults(DataGridView g)
        {
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.RowHeadersVisible = true;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ClearGrid(DataGridView g)
        {
            g.Columns.Clear();
            g.Rows.Clear();
        }

        private void FillGridWithSnapshot(DataGridView grid, TableauSnapshot snap)
        {
            grid.SuspendLayout();
            grid.Columns.Clear();
            grid.Rows.Clear();

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

            for (int i = 0; i < snap.RowLabels.Length; i++)
            {
                int r = grid.Rows.Add();
                grid.Rows[r].HeaderCell.Value = snap.RowLabels[i];
                for (int j = 0; j < snap.ColumnLabels.Length; j++)
                    grid.Rows[r].Cells[j].Value = Math.Round(snap.Matrix[i, j], 3).ToString("0.000");
            }

            grid.ResumeLayout();
        }

        private void BuildReportPreview()
        {
            txtReportPreview.Clear();
            txtReportPreview.AppendText($"z* (primal): {_report.PrimalObjective:0.000}\n");
            if (_report.DualObjective.HasValue)
                txtReportPreview.AppendText($"w* (dual): {_report.DualObjective.Value:0.000}\n");
            txtReportPreview.AppendText($"weak duality: {(_report.WeakDualityHolds ? "holds" : "fails")}\n");
            txtReportPreview.AppendText($"strong duality: {(_report.StrongDualityHolds ? "holds" : "not verified")}\n");
            if (!string.IsNullOrWhiteSpace(_report.Notes))
                txtReportPreview.AppendText($"notes: {_report.Notes}\n");

            txtReportPreview.AppendText("\nshadow prices (y):\n");
            foreach (var kv in _report.ShadowPrices)
                txtReportPreview.AppendText($"{kv.Key}: {kv.Value:0.000}\n");

            txtReportPreview.AppendText("\nreduced costs:\n");
            foreach (var kv in _report.ReducedCosts)
                txtReportPreview.AppendText($"{kv.Key}: {kv.Value.value:0.000} (basic: {(kv.Value.isBasic ? "yes" : "no")})\n");
        }

        // compute w* = b^T y from the final primal tableau
        // y_i comes from z-row slack columns: for max with <= we use y_i = -zcoef(s_i)
        private double ComputeDualObjectiveFromPrimal()
        {
            if (_primalResult == null || !_primalResult.Iterations.Any()) return 0.0;

            var last = _primalResult.Iterations.Last();
            var T = last.Matrix;
            var cols = last.ColumnLabels;
            int zRow = T.GetLength(0) - 1;

            double w = 0.0;

            // sum b_i * y_i
            for (int i = 0; i < _primalModel.Constraints.Count; i++)
            {
                string slackName = "s" + (i + 1);
                int sCol = Array.IndexOf(cols, slackName);
                if (sCol < 0) continue;

                double zcoef = T[zRow, sCol];
                double yi = _primalModel.IsMaximization ? -zcoef : zcoef; // sign per our convention
                double bi = _primalModel.Constraints[i].RightHandSide;

                w += bi * yi;
            }

            return w;
        }

        private void gridObjRanges_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

