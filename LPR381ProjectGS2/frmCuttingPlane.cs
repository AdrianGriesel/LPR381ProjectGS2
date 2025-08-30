using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LinearProgrammingSolver;

namespace LPR381ProjectGS2
{
    public partial class frmCuttingPlane : Form
    {
        public frmCuttingPlane()
        {
            InitializeComponent();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var model = LPInputParser.ParseInputFile(ofd.FileName);
                        var solver = new CuttingPlaneSolver(model);
                        var result = solver.Solve();
                        DisplayResults(result);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Solver Error");
                    }
                }
            }
        }

        private void DisplayResults(CuttingPlaneResult result)
        {
            tabIterations.TabPages.Clear();

            foreach (var iterResult in result.Iterations)
            {
                var tabPage = new TabPage($"Iteration {iterResult.Iteration}");
                var grid = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                    RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
                };

                var simplexResult = iterResult.SimplexResult;
                if (simplexResult != null && simplexResult.Log.Snapshots.Any())
                {
                    var finalSnapshot = simplexResult.Log.Snapshots.Last();
                    var finalTableau = finalSnapshot.Tableau;
                    var expandedModel = iterResult.ExpandedModel;

                    grid.ColumnCount = expandedModel.VarNames.Length + 1;
                    for (int c = 0; c < expandedModel.VarNames.Length; c++)
                    {
                        grid.Columns[c].HeaderText = expandedModel.VarNames[c];
                    }
                    grid.Columns[expandedModel.VarNames.Length].HeaderText = "RHS";

                    grid.RowCount = finalTableau.GetLength(0);
                    for (int r = 0; r < finalTableau.GetLength(0); r++)
                    {
                        for (int c = 0; c < finalTableau.GetLength(1); c++)
                        {
                            grid.Rows[r].Cells[c].Value = finalTableau[r, c];
                        }
                    }

                    for (int r = 0; r < finalSnapshot.Basis.Length; r++)
                    {
                        if(r < grid.Rows.Count)
                        {
                            grid.Rows[r].HeaderCell.Value = $"C{r + 1}";
                        }
                    }
                    if(finalSnapshot.Basis.Length < grid.Rows.Count)
                        grid.Rows[finalSnapshot.Basis.Length].HeaderCell.Value = "Z";
                }
                
                var infoLabel = new Label
                {
                    Dock = DockStyle.Bottom,
                    Text = $"Objective: {iterResult.ObjectiveValue:F2} | Integer: {iterResult.IsInteger} | Cut: {iterResult.Cut ?? "N/A"} | Status: {iterResult.TerminationReason}",
                    AutoSize = true
                };

                tabPage.Controls.Add(grid);
                tabPage.Controls.Add(infoLabel);
                tabIterations.TabPages.Add(tabPage);
            }
        }
    }
}
