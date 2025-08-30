using LinearProgrammingSolver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPR381ProjectGS2
{
    public partial class frmCuttingPlane : Form
    {
        private CuttingPlaneSolver solver;

        public frmCuttingPlane()
        {
            InitializeComponent();
        }

        private void frmCuttingPlane_Load(object sender, EventArgs e)
        {

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
                        solver = new CuttingPlaneSolver(model);
                        solver.Solve();
                        PopulateTabs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Solver Error");
                    }
                }
            }
        }

        private void PopulateTabs()
        {
            tabIterations.TabPages.Clear();

            int iter = 0;
            foreach (var tableau in solver.Iterations)
            {
                var tab = new TabPage(iter == 0 ? "Canonical Form" : $"Iteration {iter}");

                var grid = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                };

                var dt = new DataTable();

                // Add column headers
                dt.Columns.Add("Row");
                foreach (var colName in solver.ColumnNames)
                    dt.Columns.Add(colName);

                // Fill rows
                for (int r = 0; r < tableau.GetLength(0); r++)
                {
                    var row = dt.NewRow();
                    row[0] = solver.RowNames[r];
                    for (int c = 0; c < tableau.GetLength(1); c++)
                        row[c + 1] = tableau[r, c];
                    dt.Rows.Add(row);
                }

                grid.DataSource = dt;
                tab.Controls.Add(grid);
                tabIterations.TabPages.Add(tab);

                iter++;
            }
        }
    }
}
