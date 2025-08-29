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
                int iter = 1;
                foreach (var tableau in node.Tableaus)
                {
                    var tab = new TabPage($"Pivot {iter++}");
                    var grid = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    };
                    var dt = new DataTable();
                    for (int c = 0; c < tableau.GetLength(1); c++)
                        dt.Columns.Add($"C{c}");
                    for (int r = 0; r < tableau.GetLength(0); r++)
                    {
                        var row = dt.NewRow();
                        for (int c = 0; c < tableau.GetLength(1); c++)
                            row[c] = tableau[r, c];
                        dt.Rows.Add(row);
                    }
                    grid.DataSource = dt;
                    tab.Controls.Add(grid);
                    tabPivots.TabPages.Add(tab);
                }
            }
        }
    }
}

