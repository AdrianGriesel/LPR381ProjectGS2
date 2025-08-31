
using LinearProgrammingSolver;
using LPR381ProjectGS2.Domain.Algorithms;
using LPR381ProjectGS2.Domain.Analysis;
using LPR381ProjectGS2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static LinearProgrammingSolver.LPInputParser;
using SimplexStatus = LPR381ProjectGS2.Domain.Models.SimplexStatus;

namespace LPR381ProjectGS2.Presentation
{
    public partial class frmSensitivity : Form
    {
        private LinearProgrammingSolver.LPInputParser.LPModel _primalModel;
        private Domain.Models.SimplexResult _primalResult;

        private LinearProgrammingSolver.LPInputParser.LPModel _dualModel;
        private Domain.Models.SimplexResult _dualResult;

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

            lstDualIters.SelectedIndexChanged += lstDualIters_SelectedIndexChanged;
            lstPrimalIters.SelectedIndexChanged += lstPrimalIters_SelectedIndexChanged;

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

                _primalModel = LPInputParser.ParseInputFile(ofd.FileName);

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
                btnBuildDual.Enabled = true;
                btnSolveDual.Enabled = true;
                btnAnalyze.Enabled = false;
                btnExport.Enabled = false;

                BuildObjRangesGrid();
                BuildRhsRangesGrid();

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
            btnAnalyze.Enabled = _primalResult.Status == SimplexStatus.Optimal;
            btnExport.Enabled = true;

            // compute initial sensitivity report
            var analyzer = new SensitivityAnalyzer();
            _report = analyzer.Analyze(_primalModel, _primalResult, _dualModel, _dualResult, (double)numNewValue.Value);
            UpdateAfterChange();
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
            if (_primalResult == null) return;

            // build dual ready for solver
            _dualModel = DualBuilder.BuildDual(_primalModel);

            var solver = new PrimalSimplexSolver();
            _dualResult = solver.Solve(_dualModel);

            lstDualIters.Items.Clear();

            for (int i = 0; i < _dualResult.Iterations.Count; i++)
            {
                var s = _dualResult.Iterations[i];
                string label = $"iteration {i + 1}";
                if (s.EnteringColumn.HasValue && s.LeavingRow.HasValue)
                    label += $" (enter {s.ColumnLabels[s.EnteringColumn.Value]}, leave {s.RowLabels[s.LeavingRow.Value]})";
                lstDualIters.Items.Add(label);
            }

            if (_dualResult.Iterations.Any())
            {
                lstDualIters.SelectedIndex = _dualResult.Iterations.Count - 1;
                FillGridWithSnapshot(gridDualTableau, _dualResult.Iterations.Last());
                gridDualTableau.Refresh();
            }

            double dualTrue = ComputeDualObjectiveFromPrimal();
            lblDualObj.Text = $"w* (dual) = {dualTrue:0.000}";

            double tol = (double)numNewValue.Value;
            bool strong = Math.Abs(dualTrue - _primalResult.ObjectiveValue) <= tol;
            lblDualityCheck.Text = $"strong duality: {(strong ? "passed" : "failed")} (|z* - w*| ≤ {tol})";

            lblStatus.Text = "dual solved and duality checked.";
        }



        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (_primalResult == null) return;

            var analyzer = new SensitivityAnalyzer();
            _report = analyzer.Analyze(_primalModel, _primalResult, _dualModel, _dualResult, (double)numNewValue.Value);

            UpdateAfterChange();
            lblStatus.Text = "analysis complete.";
        }

     

        

        // ===== Apply Changes =====

        private void ApplyVariableChange(string varName, double newValue)
        {
            int idx = -1;
            for (int i = 0; i < _primalModel.ObjectiveCoefficients.Count; i++)
            {
                if ($"x{i + 1}" == varName)
                {
                    idx = i;
                    break;
                }
            }
            if (idx < 0) return;

            _primalModel.ObjectiveCoefficients[idx] = newValue;

            var solver = new PrimalSimplexSolver();
            _primalResult = solver.Solve(_primalModel);
            if (_dualModel != null)
                _dualResult = solver.Solve(_dualModel);

            RecomputeSensitivityReport(); // recompute report and update grids
        }

        private void ApplyRhsChange(string constrName, double newRhs)
        {
            if (!constrName.StartsWith("Constraint")) return;
            if (!int.TryParse(constrName.Replace("Constraint", ""), out int idx)) return;
            if (idx < 0 || idx >= _primalModel.Constraints.Count) return;

            _primalModel.Constraints[idx].RightHandSide = newRhs;

            var solver = new PrimalSimplexSolver();
            _primalResult = solver.Solve(_primalModel);
            if (_dualModel != null)
                _dualResult = solver.Solve(_dualModel);

            RecomputeSensitivityReport(); // recompute report and update grids
        }

        private void AddNewActivity()
        {
            int n = _primalModel.ObjectiveCoefficients.Count + 1;
            string newVarName = "x" + n;

            // Add new variable with 0 coefficient
            _primalModel.ObjectiveCoefficients.Add(0.0);

            // Add 0 coefficients to all existing constraints
            foreach (var c in _primalModel.Constraints)
                c.Coefficients.Add(0.0);

            // Solve the updated model
            var solver = new PrimalSimplexSolver();
            _primalResult = solver.Solve(_primalModel);
            if (_dualModel != null)
                _dualResult = solver.Solve(_dualModel);

            // Recompute the sensitivity report
            RecomputeSensitivityReport();

            // Force the grids to include the new variable
            UpdateAfterChange();

            lblStatus.Text = $"Added new activity {newVarName}. Solution updated.";
        }  

        private void AddNewConstraint()
        {
            int n = _primalModel.Constraints.Count + 1;
            var newConstr = new LinearProgrammingSolver.LPInputParser.Constraint
            {
                Coefficients = new List<double>(new double[_primalModel.ObjectiveCoefficients.Count]),
                RightHandSide = 0.0,
                Type = LinearProgrammingSolver.LPInputParser.ConstraintType.LessOrEqual
            };
            _primalModel.Constraints.Add(newConstr);

            var solver = new PrimalSimplexSolver();
            _primalResult = solver.Solve(_primalModel);

            if (_dualModel != null)
                _dualResult = solver.Solve(_dualModel);

            UpdateAfterChange();
            lblStatus.Text = $"Added new constraint c{n}. Solution updated.";
        }

        private void UpdateAfterChange()
        {
            ClearGrid(gridShadowPrices);
            ClearGrid(gridReducedCosts);
            ClearGrid(gridObjRanges);
            ClearGrid(gridRhsRanges);

            BuildShadowPricesGrid();
            BuildReducedCostsGrid();
            BuildObjRangesGrid();
            BuildRhsRangesGrid();
            BuildReportPreview();
        }

        // ===== Helpers =====
        private void RecomputeSensitivityReport()
        {
            if (_primalResult == null) return;

            var analyzer = new SensitivityAnalyzer();
            _report = analyzer.Analyze(_primalModel, _primalResult, _dualModel, _dualResult, (double)numNewValue.Value);

            UpdateAfterChange();
        }
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

        private void BuildObjRangesGrid()
        {
            gridObjRanges.Columns.Clear();
            gridObjRanges.Rows.Clear();
            gridObjRanges.Columns.Add("Variable", "Variable");
            gridObjRanges.Columns.Add("Down", "Allowable Down");
            gridObjRanges.Columns.Add("Up", "Allowable Up");

            if (_report == null) return;

            foreach (var kv in _report.ObjectiveCoeffRanges)
            {
                int r = gridObjRanges.Rows.Add();
                gridObjRanges.Rows[r].Cells[0].Value = kv.Key;
                gridObjRanges.Rows[r].Cells[1].Value = kv.Value.down?.ToString("0.000") ?? "∞";
                gridObjRanges.Rows[r].Cells[2].Value = kv.Value.up?.ToString("0.000") ?? "∞";
            }
        }

        private void BuildRhsRangesGrid()
        {
            gridRhsRanges.Columns.Clear();
            gridRhsRanges.Rows.Clear();
            gridRhsRanges.Columns.Add("Constraint", "Constraint");
            gridRhsRanges.Columns.Add("Down", "Allowable Down");
            gridRhsRanges.Columns.Add("Up", "Allowable Up");

            if (_report == null) return;

            foreach (var kv in _report.RhsRanges)
            {
                int r = gridRhsRanges.Rows.Add();
                gridRhsRanges.Rows[r].Cells[0].Value = kv.Key;
                gridRhsRanges.Rows[r].Cells[1].Value = kv.Value.down?.ToString("0.000") ?? "∞";
                gridRhsRanges.Rows[r].Cells[2].Value = kv.Value.up?.ToString("0.000") ?? "∞";
            }
        }

        private void BuildReportPreview()
        {
            if (_report == null)
            {
                txtReportPreview.Clear();
                txtReportPreview.AppendText("No sensitivity report available.\n");
                return;
            }

            txtReportPreview.Clear();

            // --- Objective values ---
            txtReportPreview.AppendText($"z* (primal): {_report.PrimalObjective:0.000}\n");
            if (_report.DualObjective.HasValue)
                txtReportPreview.AppendText($"w* (dual): {_report.DualObjective.Value:0.000}\n");

            // --- Solver status ---
            txtReportPreview.AppendText($"Primal status: {_primalResult?.Status}\n");
            txtReportPreview.AppendText($"Dual status: {_dualResult?.Status}\n");

            // --- Simplex iterations ---
            txtReportPreview.AppendText($"Primal iterations: {_primalResult?.Iterations.Count ?? 0}\n");
            txtReportPreview.AppendText($"Dual iterations: {_dualResult?.Iterations.Count ?? 0}\n");

            txtReportPreview.AppendText(new string('-', 50) + "\n");

            // --- Weak/strong duality ---
            txtReportPreview.AppendText($"Weak duality: {(_report.WeakDualityHolds ? "holds" : "fails")}\n");
            txtReportPreview.AppendText($"Strong duality: {(_report.StrongDualityHolds ? "holds" : "not verified")}\n");

            txtReportPreview.AppendText(new string('-', 50) + "\n");

            // --- Basic variables (from last primal iteration) ---
            if (_primalResult?.Iterations.Any() == true)
            {
                var last = _primalResult.Iterations.Last();
                txtReportPreview.AppendText("Primal basic variables:\n");
                for (int i = 0; i < last.RowLabels.Length - 1; i++)
                {
                    double val = last.Matrix[i, last.Matrix.GetLength(1) - 1];
                    txtReportPreview.AppendText($"  {last.RowLabels[i]} = {val:0.000}\n");
                }
                txtReportPreview.AppendText(new string('-', 50) + "\n");
            }

            // --- Shadow prices ---
            if (_report.ShadowPrices != null && _report.ShadowPrices.Count > 0)
            {
                txtReportPreview.AppendText("Shadow prices:\n");
                foreach (var kv in _report.ShadowPrices)
                    txtReportPreview.AppendText($"  {kv.Key}: {kv.Value:0.000}\n");
                txtReportPreview.AppendText(new string('-', 50) + "\n");
            }

            // --- Reduced costs ---
            if (_report.ReducedCosts != null && _report.ReducedCosts.Count > 0)
            {
                txtReportPreview.AppendText("Reduced costs:\n");
                foreach (var kv in _report.ReducedCosts)
                {
                    string basic = kv.Value.isBasic ? "(basic)" : "";
                    txtReportPreview.AppendText($"  {kv.Key}: {kv.Value.value:0.000} {basic}\n");
                }
                txtReportPreview.AppendText(new string('-', 50) + "\n");
            }
        }

    // --- Objective coefficient range


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

        private void FillGridWithSnapshot(DataGridView grid, TableauSnapshot snap, LPModel model = null)
        {
            if (grid == null || snap == null || snap.Matrix == null) return;

            grid.SuspendLayout();
            grid.Rows.Clear();

            int rows = snap.Matrix.GetLength(0);
            int cols = snap.Matrix.GetLength(1);

            // Use snapshot column labels first; fallback to model variable names; finally, default c0, c1...
            string[] colLabels;
            if (snap.ColumnLabels != null)
            {
                colLabels = snap.ColumnLabels;
            }
            else if (model != null && model.VariableNames != null && model.VariableNames.Count == cols)
            {
                colLabels = model.VariableNames.ToArray();
            }
            else
            {
                colLabels = Enumerable.Range(0, cols).Select(i => "c" + i).ToArray();
            }

            string[] rowLabels = snap.RowLabels ?? Enumerable.Range(0, rows).Select(i => "r" + i).ToArray();

            // Build columns
            if (grid.Columns.Count != cols)
            {
                grid.Columns.Clear();
                for (int j = 0; j < cols; j++)
                {
                    var col = new DataGridViewTextBoxColumn
                    {
                        HeaderText = colLabels[j],
                        Name = "col" + j,
                        SortMode = DataGridViewColumnSortMode.NotSortable,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };
                    grid.Columns.Add(col);
                }
            }

            // Fill rows
            for (int i = 0; i < rows; i++)
            {
                int r = grid.Rows.Add();
                grid.Rows[r].HeaderCell.Value = rowLabels[i];
                for (int j = 0; j < cols; j++)
                {
                    double val = snap.Matrix[i, j];
                    grid.Rows[r].Cells[j].Value = double.IsNaN(val) ? "-" : val.ToString("0.000");
                }
            }

            grid.ResumeLayout();
            grid.Refresh();
        }



        // ===== Updated Selection Helpers =====

        private string GetSelectedVariableFromGrid(DataGridView g)
        {
            if (g.CurrentRow != null)
                return g.CurrentRow.Cells[0].Value?.ToString();
            return null;
        }

        private string GetSelectedConstraintFromGrid(DataGridView g)
        {
            if (g.CurrentRow != null)
                return g.CurrentRow.Cells[0].Value?.ToString();
            return null;
        }

        private double GetNewValueFromInput()
        {
            return (double)numNewValue.Value;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "Text Files (*.txt)|*.txt", Title = "Export Sensitivity Report" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, txtReportPreview.Text);
                    MessageBox.Show("Report exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gridObjRanges_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // ===== Sensitivity Actions =====
        private void btnApplyVarChange_Click(object sender, EventArgs e)
        {
            string varName = GetSelectedVariableFromGrid(gridObjRanges);
            if (string.IsNullOrEmpty(varName))
            {
                MessageBox.Show("Select a variable from the table first.");
                return;
            }

            double newValue = GetNewValueFromInput();
            ApplyVariableChange(varName, newValue);
            RecomputeSensitivityReport();

            lblStatus.Text = $"Variable {varName} objective coefficient changed to {newValue}. Solution updated.";
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            AddNewActivity();
            RecomputeSensitivityReport();

            lblStatus.Text = $"Added new activity. Solution updated.";

        }

        private void btnAddConstraint_Click(object sender, EventArgs e)
        {
            AddNewConstraint();
            RecomputeSensitivityReport();

            lblStatus.Text = $"Added new constraint. Solution updated.";
        }

        private void btnApplyRhsChange_Click(object sender, EventArgs e)
        {
            string constrName = GetSelectedConstraintFromGrid(gridRhsRanges);
            if (string.IsNullOrEmpty(constrName))
            {
                MessageBox.Show("Select a constraint from the table first.");
                return;
            }

            double newRhs = GetNewValueFromInput();
            ApplyRhsChange(constrName, newRhs);

            RecomputeSensitivityReport();

            lblStatus.Text = $"Constraint {constrName} RHS changed to {newRhs}. Solution updated.";
        }

        private void btnCopyReport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "Text Files (*.txt)|*.txt", Title = "Export Sensitivity Report" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, txtReportPreview.Text);
                    MessageBox.Show("Report exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        // Add this event handler method to fix CS0103
        

        private void lstDualIters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dualResult == null || !_dualResult.Iterations.Any()) return;
            if (lstDualIters.SelectedIndex < 0 || lstDualIters.SelectedIndex >= _dualResult.Iterations.Count) return;

            var selectedIteration = _dualResult.Iterations[lstDualIters.SelectedIndex];
            FillGridWithSnapshot(gridDualTableau, selectedIteration);
        }

        private void lstPrimalIters_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure a valid index is selected
            if (_primalResult == null || lstPrimalIters.SelectedIndex < 0) return;

            int iterIndex = lstPrimalIters.SelectedIndex;

            if (iterIndex >= 0 && iterIndex < _primalResult.Iterations.Count)
            {
                var snapshot = _primalResult.Iterations[iterIndex];
                FillGridWithSnapshot(gridPrimalTableau, snapshot);
                lblStatus.Text = $"Displaying iteration {iterIndex + 1}";
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void grpPrimal_Enter(object sender, EventArgs e)
        {

        }

        private void lblPrimalObj_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
