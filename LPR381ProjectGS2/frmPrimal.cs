using LPR381ProjectGS2.Domain.Algorithms;
using LPR381ProjectGS2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static LinearProgrammingSolver.LPInputParser;

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
            gridTableau.EnableHeadersVisualStyles = false;
            gridOptimal.EnableHeadersVisualStyles = false;

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

                // leave the extra "Iteration" column blank
                gridTableau.Rows[rowIndex].Cells[snap.ColumnLabels.Length].Value = "";
            }

            // overwrite z-row rhs with c^T x so objective displays with correct sign
            try
            {
                int zRowIndex = snap.RowLabels.Length - 1;        // last row is "Z"
                int rhsColIndex = snap.ColumnLabels.Length - 1;   // last of the normal columns is RHS
                double zDisplay = ComputeObjectiveFromSnapshot(snap, _model);
                gridTableau.Rows[zRowIndex].Cells[rhsColIndex].Value = zDisplay.ToString("0.000");
            }
            catch { /* keep ui resilient if labels or sizes differ */ }

            // highlight pivot (there is 1 extra trailing column: "Iteration N")
            ApplyPivotHighlight(gridTableau, snap, extraTrailingColumns: 1);

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

                // use shared renderer which overwrites z rhs with c^T x
                FillGridWithSnapshot(gridOptimal, finalSnap);
                // FillGridWithSnapshot already calls ApplyPivotHighlight(..., 0)
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

            // overwrite z-row rhs with c^T x so objective displays correctly 
            try
            {
                int zRowIndex = snap.RowLabels.Length - 1;      // last row is Z
                int rhsColIndex = snap.ColumnLabels.Length - 1; // last col is RHS
                double zDisplay = ComputeObjectiveFromSnapshot(snap, _model);
                grid.Rows[zRowIndex].Cells[rhsColIndex].Value = zDisplay.ToString("0.000");
            }
            catch { /* ignore */ }

            // highlight pivot if present (no extra columns in this grid)
            ApplyPivotHighlight(grid, snap, extraTrailingColumns: 0);

            grid.ResumeLayout();
        }



        // ============== helpers ====================

        // compute c^T x for a given snapshot using the model's objective
        private double ComputeObjectiveFromSnapshot(Domain.Models.TableauSnapshot snap, LPModel model)
        {
            int rhsCol = snap.ColumnLabels.Length - 1;
            var x = new double[model.NumberOfVariables];

            // read basic x values from the snapshot rhs
            for (int i = 0; i < snap.RowLabels.Length; i++)
            {
                string lbl = snap.RowLabels[i];
                if (!string.IsNullOrEmpty(lbl) && lbl[0] == 'x')
                {
                    int k;
                    if (int.TryParse(lbl.Substring(1), out k))
                    {
                        int idx = k - 1;
                        if (idx >= 0 && idx < x.Length)
                            x[idx] = snap.Matrix[i, rhsCol];
                    }
                }
            }

            double z = 0.0;
            for (int j = 0; j < x.Length; j++)
                z += model.ObjectiveCoefficients[j] * x[j];

            return z;
        }


        // clears any prior highlighting
        private void ClearGridStyles(DataGridView grid)
        {
            foreach (DataGridViewRow r in grid.Rows)
            {
                r.DefaultCellStyle.BackColor = SystemColors.Window;
                r.HeaderCell.Style.BackColor = SystemColors.Control;
                foreach (DataGridViewCell c in r.Cells)
                    c.Style.BackColor = SystemColors.Window;
            }
            foreach (DataGridViewColumn c in grid.Columns)
                c.HeaderCell.Style.BackColor = SystemColors.Control;
        }

        // highlights the entering column and leaving row; pivot cell gets a distinct color
        // extraTrailingColumns = number of extra columns appended after the normal tableau columns
        private void ApplyPivotHighlight(DataGridView grid, TableauSnapshot snap, int extraTrailingColumns = 0)
        {
            if (!snap.EnteringColumn.HasValue || !snap.LeavingRow.HasValue)
                return;

            int pivotCol = snap.EnteringColumn.Value;   // within normal tableau columns
            int pivotRow = snap.LeavingRow.Value;

            int normalCols = snap.ColumnLabels.Length;  // tableau columns only
            int totalCols = grid.Columns.Count;        // includes extra trailing columns

            if (pivotCol < 0 || pivotCol >= normalCols) return;
            if (pivotRow < 0 || pivotRow >= grid.Rows.Count) return;

            // colors
            var colColor = Color.FromArgb(255, 255, 220); // yellow
            var rowColor = Color.FromArgb(220, 240, 255); // light blue
            var pivotColor = Color.FromArgb(255, 230, 140); // gold
            var hdrEmph = Color.FromArgb(210, 225, 240);

            // clear previous styling
            ClearGridStyles(grid);

            // 1) paint the entire leaving row across ALL columns (incl. trailing)
            for (int c = 0; c < totalCols; c++)
                grid.Rows[pivotRow].Cells[c].Style.BackColor = rowColor;
            grid.Rows[pivotRow].HeaderCell.Style.BackColor = hdrEmph;

            // 2) paint the entering column within the normal tableau columns
            //    (this will overlay yellow on top of blue where they intersect)
            for (int r = 0; r < grid.Rows.Count; r++)
                grid.Rows[r].Cells[pivotCol].Style.BackColor = colColor;
            grid.Columns[pivotCol].HeaderCell.Style.BackColor = hdrEmph;

            // 3) pivot cell gets a distinct color
            grid.Rows[pivotRow].Cells[pivotCol].Style.BackColor = pivotColor;
        }


        private void ClearGrid(DataGridView grid)
        {
            if (grid == null) return;

            grid.SuspendLayout();
            grid.Columns.Clear();
            grid.Rows.Clear();
            ClearGridStyles(grid); // wipes background colors back to defaults
            grid.ResumeLayout();
        }


        // ------- empty handlers kept so the Designer won’t complain -------
        private void gridOptimal_CellContentClick(object sender, DataGridViewCellEventArgs e) { /* not used */ }
        private void gridTableau_CellContentClick(object sender, DataGridViewCellEventArgs e) { /* not used */ }
    }
}
