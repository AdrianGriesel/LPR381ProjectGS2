using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPR381ProjectGS2.Presentation;

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

        private void btnSensitivityAnalysis_Click(object sender, EventArgs e)
        {
            frmSensitivity frmSensitivity = new frmSensitivity();

            frmSensitivity.ShowDialog();
        }
    }
}
