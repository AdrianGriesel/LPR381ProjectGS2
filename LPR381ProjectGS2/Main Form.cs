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
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void btnPrimal_Click(object sender, EventArgs e)
        {
            frmSimplex frmSimplex = new frmSimplex();
            frmSimplex.ShowDialog();

        }

        private void btnPrimalSolver_Click(object sender, EventArgs e)
        {
            frmPrimal frmPrimal = new frmPrimal();
            frmPrimal.ShowDialog();

        }

        private void btnKnapsackBnb_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Title = "Select Binary IP (Knapsack) Input File",
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            })
            {
                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    var model = LinearProgrammingSolver.LPInputParser.ParseInputFile(ofd.FileName);

                    // Guard: knapsack expects all variables to be binary
                    if (!model.SignRestrictions.TrueForAll(t => t == LinearProgrammingSolver.LPInputParser.VariableType.Binary))
                    {
                        MessageBox.Show(this,
                            "Knapsack expects all decision variables to be 'bin' in the sign restrictions line.",
                            "Not a valid knapsack model",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    using (var f = new FrmKnapsackBnb(model))
                    {
                        f.ShowDialog(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        "Could not load/parse the file:\n\n" + ex.Message,
                        "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBranchAndBound_Click(object sender, EventArgs e)
        {
            //open branch and boudn form
            frmBranchAndBound frmBranchAndBound = new frmBranchAndBound();
            frmBranchAndBound.ShowDialog();
        }

        private void btnCuttingPlane_Click(object sender, EventArgs e)
        {
            //open cutting plane form
            frmCuttingPlane frmCuttingPlane = new frmCuttingPlane();
            frmCuttingPlane.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
