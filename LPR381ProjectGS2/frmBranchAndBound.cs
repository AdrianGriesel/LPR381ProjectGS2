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
using System.Xml.Linq;

namespace LPR381ProjectGS2
{
    public partial class frmBranchAndBound : Form
    {
        public frmBranchAndBound()
        {
            InitializeComponent();
        }
        private BranchAndBoundSolver solver;
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
                        solver = new BranchAndBoundSolver(model);
                        solver.Solve();
                        PopulateTree();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Parsing/Solver Error");
                    }
                }
            }
        }
        private void PopulateTree()
        {
            treeNodes.Nodes.Clear();
            foreach (var node in solver.AllNodes)
            {
                var tn = new TreeNode($"Node {node.Id} | Bound={node.Bound:F2}");
                tn.Tag = node;
                treeNodes.Nodes.Add(tn);
            }
        }

        private void treeNodes_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node?.Tag is Node node)
            {
                // Show solution variables
                var dtVars = new DataTable();
                dtVars.Columns.Add("Variable");
                dtVars.Columns.Add("Value");
                for (int i = 0; i < node.VariableAssignments.Length; i++)
                    dtVars.Rows.Add($"x{i + 1}", node.VariableAssignments[i]);
                gridSolution.DataSource = dtVars;

                // Show pivot iterations
                tabPivots.TabPages.Clear();
                if (node.Log != null && node.Model != null)
                {
                    int iter = 1;
                    foreach (var snapshot in node.Log.Snapshots)
                    {
                        var tab = new TabPage($"Pivot {iter++}");
                        var grid = new DataGridView
                        {
                            Dock = DockStyle.Fill,
                            ReadOnly = true,
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
                        };

                        var tableau = snapshot.Tableau;
                        var dt = new DataTable();

                        int numVars = node.Model.VarNames.Length;
                        int numColsInTableau = tableau.GetLength(1);

                        // Add columns
                        for (int c = 0; c < numVars; c++)
                        {
                            if (c < node.Model.VarNames.Length)
                                dt.Columns.Add(node.Model.VarNames[c]);
                            else
                                dt.Columns.Add("?");
                        }
                        if (numColsInTableau > numVars)
                        {
                            dt.Columns.Add("RHS");
                        }

                        // Add rows
                        for (int r = 0; r < tableau.GetLength(0); r++)
                        {
                            var row = dt.NewRow();
                            for (int c = 0; c < numColsInTableau; c++)
                            {
                                if (c < dt.Columns.Count)
                                    row[c] = tableau[r, c];
                            }
                            dt.Rows.Add(row);
                        }

                        grid.DataSource = dt;

                        // Set row headers
                        for (int r = 0; r < snapshot.Basis.Length; r++)
                        {
                            if (r < grid.Rows.Count)
                            {
                                int basisVarIndex = snapshot.Basis[r];
                                if (basisVarIndex >= 0 && basisVarIndex < numVars)
                                {
                                    grid.Rows[r].HeaderCell.Value = node.Model.VarNames[basisVarIndex];
                                }
                                else
                                {
                                    grid.Rows[r].HeaderCell.Value = "??";
                                }
                            }
                        }
                        if (snapshot.Basis.Length < grid.Rows.Count)
                        {
                            grid.Rows[snapshot.Basis.Length].HeaderCell.Value = "Z";
                        }

                        tab.Controls.Add(grid);
                        tabPivots.TabPages.Add(tab);
                    }
                }
            }
        }

        private void gridSolution_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

