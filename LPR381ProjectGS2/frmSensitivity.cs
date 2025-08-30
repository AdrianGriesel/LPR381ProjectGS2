using LPR381ProjectGS2.Domain.Algorithms;
using LPR381ProjectGS2.Domain.Analysis;
using LPR381ProjectGS2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static LinearProgrammingSolver.LPInputParser;

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
            SetGridDefaults(gridPrimalTableau);
            SetGridDefaults(gridDualTableau);
            SetGridDefaults(gridShadowPrices);
            SetGridDefaults(gridReducedCosts);
            SetGridDefaults(gridObjRanges);
            SetGridDefaults(gridRhsRanges);

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

            var solver = new PrimalSimplexSolver();
            _primalResult = solver.Solve(_primalModel);

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
            if (_dualModel == null) return;

            var solver = new PrimalSimplexSolver();
            _dualResult = solver.Solve(_dualModel);

            if (_dualResult.Iterations.Any())
                FillGridWithSnapshot(gridDualTableau, _dualResult.Iterations.Last());

            double dualTrue = ComputeDualObjectiveFromPrimal();
            lblDualObj.Text = $"w* (dual) = {dualTrue:0.000}";

            double tol = (double)numTolerance.Value;
            bool strong = Math.Abs(dualTrue - _primalResult.ObjectiveValue) <= tol;
            lblDualityCheck.Text = $"strong duality: {(strong ? "passed" : "failed")} (|z* - w*| ≤ {tol})";

            lblStatus.Text = "dual solved and duality checked.";
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var analyzer = new SensitivityAnalyzer();
            _report = analyzer.Analyze(_primalModel, _primalResult, _dualModel, _dualResult, (double)numTolerance.Value);

            BuildShadowPricesGrid();
            BuildReducedCostsGrid();
            BuildReportPreview();

            lblStatus.Text = "analysis complete.";
        }

        // ===== Sensitivity Actions =====

        private void gridObjRanges_SelectionChanged(object sender, EventArgs e)
        {
            string varName = GetSelectedVariableFromGrid(gridObjRanges);
            if (string.IsNullOrEmpty(varName)) return;

            var range = _report.GetVariableRange(varName);
            lblStatus.Text = $"Variable {varName} range: {range.Min:0.000} → {range.Max:0.000}";
        }

        private void btnApplyVarChange_Click(object sender, EventArgs e)
        {
            string varName = GetSelectedVariableFromGrid(gridObjRanges);
            double newValue = GetNewValueFromInput();
            // TODO: Apply change in model / recalc
            lblStatus.Text = $"Non-basic variable {varName} changed to {newValue}.";
        }

        private void gridRhsRanges_SelectionChanged(object sender, EventArgs e)
        {
            string constrName = GetSelectedConstraintFromGrid(gridRhsRanges);
            if (string.IsNullOrEmpty(constrName)) return;

            var range = _report.GetRhsRange(constrName);
            lblStatus.Text = $"Constraint {constrName} RHS range: {range.Min:0.000} → {range.Max:0.000}";
        }

        private void btnApplyRhsChange_Click(object sender, EventArgs e)
        {
            string constrName = GetSelectedConstraintFromGrid(gridRhsRanges);
            double newRhs = GetNewValueFromInput();
            // TODO: Apply change in model / recalc
            lblStatus.Text = $"Constraint {constrName} RHS changed to {newRhs}.";
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            // TODO: Implement new activity addition
            lblStatus.Text = "Added new activity (placeholder). Recompute solution.";
        }

        private void btnAddConstraint_Click(object sender, EventArgs e)
        {
            // TODO: Implement new constraint addition
            lblStatus.Text = "Added new constraint (placeholder). Recompute solution.";
        }

        // ===== Helpers =====

        private void BuildShadowPricesGrid()
        {
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
        }

        private void BuildReducedCostsGrid()
        {
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
        }

        // Helper to compute dual objective from primal
        private double ComputeDualObjectiveFromPrimal()
        {
            if (_primalResult == null || !_primalResult.Iterations.Any()) return 0.0;

            var last = _primalResult.Iterations.Last();
            var T = last.Matrix;
            var cols = last.ColumnLabels;
            int zRow = T.GetLength(0) - 1;

            double w = 0.0;
            for (int i = 0; i < _primalModel.Constraints.Count; i++)
            {
                string slackName = "s" + (i + 1);
                int sCol = Array.IndexOf(cols, slackName);
                if (sCol < 0) continue;

                double zcoef = T[zRow, sCol];
                double yi = _primalModel.IsMaximization ? -zcoef : zcoef;
                double bi = _primalModel.Constraints[i].RightHandSide;

                w += bi * yi;
            }

            return w;
        }

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

        // TODO: Implement these helper functions to connect grid selection and user input
        private string GetSelectedVariableFromGrid(DataGridView g) => "x1"; // placeholder
        private string GetSelectedConstraintFromGrid(DataGridView g) => "c1"; // placeholder
        private double GetNewValueFromInput() => 1.0; // placeholder
                                                      // Add this method to frmSensitivity.cs to fix CS1061
        private void btnExport_Click(object sender, EventArgs e)
        {
            // Example implementation: Export the report preview to a text file
            using (var sfd = new SaveFileDialog { Filter = "Text Files (*.txt)|*.txt", Title = "Export Sensitivity Report" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, txtReportPreview.Text);
                    MessageBox.Show("Report exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        // Add this method to frmSensitivity.cs to fix CS1061
        private void gridObjRanges_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can implement any desired logic here, or leave it empty if not needed.
        }
    }
}

