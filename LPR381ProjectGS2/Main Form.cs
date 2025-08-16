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
    }
}
