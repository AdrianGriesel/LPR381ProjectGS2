using LinearProgrammingSolver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LPR381ProjectGS2
{
    public partial class frmSimplex : Form
    {
        private double[,] tableau;
        private List<string> basicVars;
        private List<string> nonBasicVars;

        public frmSimplex()
        {
            InitializeComponent();
        }

        private void frmSimplex_Load(object sender, EventArgs e)
        {

        }

        public frmSimplex(LPInputParser.LPModel model)
        {
            InitializeComponent();
            DisplayModel(model);
        }

        private void DisplayModel(LPInputParser.LPModel model)
        {
            // Objective function 
            StringBuilder sbObjective = new StringBuilder();
            sbObjective.Append(model.IsMaximization ? "max " : "min ");
            for (int i = 0; i < model.ObjectiveCoefficients.Count; i++)
            {
                sbObjective.Append(string.Format("{0:+0.###;-0.###}x{1}", model.ObjectiveCoefficients[i], i + 1));
                if (i < model.ObjectiveCoefficients.Count - 1)
                    sbObjective.Append(" ");
            }
            txtObjective.Text = sbObjective.ToString();

            //Constraints
            StringBuilder sbConstraints = new StringBuilder();
            foreach (var constraint in model.Constraints)
            {
                for (int j = 0; j < constraint.Coefficients.Count; j++)
                {
                    sbConstraints.Append(string.Format("{0:+0.###;-0.###}x{1}", constraint.Coefficients[j], j + 1));
                    if (j < constraint.Coefficients.Count - 1)
                        sbConstraints.Append(" ");
                }

                string relation = "?";
                if (constraint.Type == LPInputParser.ConstraintType.LessOrEqual)
                    relation = "<=";
                else if (constraint.Type == LPInputParser.ConstraintType.GreaterOrEqual)
                    relation = ">=";
                else if (constraint.Type == LPInputParser.ConstraintType.Equal)
                    relation = "=";

                sbConstraints.AppendLine(" " + relation + " " + constraint.RightHandSide);
            }
            txtConstraints.Text = sbConstraints.ToString();

            //Sign restrictions
            StringBuilder sbSign = new StringBuilder();
            for (int i = 0; i < model.SignRestrictions.Count; i++)
            {
                string restriction = "?";
                var type = model.SignRestrictions[i];
                if (type == LPInputParser.VariableType.Positive)
                    restriction = "+";
                else if (type == LPInputParser.VariableType.Negative)
                    restriction = "-";
                else if (type == LPInputParser.VariableType.Unrestricted)
                    restriction = "urs";
                else if (type == LPInputParser.VariableType.Integer)
                    restriction = "int";
                else if (type == LPInputParser.VariableType.Binary)
                    restriction = "bin";

                sbSign.Append(string.Format("x{0}: {1}  ", i + 1, restriction));
            }
            txtSignRestrictions.Text = sbSign.ToString();

            // Initialize tableau for Simplex
            InitializeSimplex(model);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Title = "Select LP Input File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var model = LPInputParser.ParseInputFile(ofd.FileName);
                    DisplayModel(model);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeSimplex(LPInputParser.LPModel model)
        {
            int numVars = model.NumberOfVariables;
            int numConstraints = model.Constraints.Count;

            tableau = new double[numConstraints + 1, numVars + numConstraints + 1];
            basicVars = new List<string>();
            nonBasicVars = new List<string>();

            // Fill non-basic vars x1..xn
            for (int i = 0; i < numVars; i++)
                nonBasicVars.Add("x" + (i + 1));

            // Fill basic vars s1..sm
            for (int i = 0; i < numConstraints; i++)
                basicVars.Add("s" + (i + 1));

            // Fill tableau coefficients
            for (int i = 0; i < numConstraints; i++)
            {
                for (int j = 0; j < numVars; j++)
                    tableau[i, j] = model.Constraints[i].Coefficients[j];

                tableau[i, numVars + i] = 1; // slack variable
                tableau[i, numVars + numConstraints] = model.Constraints[i].RightHandSide;
            }

           

            UpdateTableauGrid();
       
        }

        private void btnNextIteration_Click(object sender, EventArgs e)
        {
            if (tableau == null) return;
            RunSimplexIteration();
        }

        private void RunSimplexIteration()
        {
            int rows = tableau.GetLength(0);
            int cols = tableau.GetLength(1);


            UpdateTableauGrid();
         
        }

        

        private void UpdateTableauGrid()//heavy work in progress you dont have to do it this was jsut for me to test if it good enough to diplay in tablua format
        {
            int rows = tableau.GetLength(0);
            int cols = tableau.GetLength(1);

            if (dgvTableau.Columns.Count != cols)
            {
                dgvTableau.Columns.Clear();
                for (int j = 0; j < cols; j++)
                {
                    string header;
                    if (j == cols - 1)
                        header = "RHS";
                    else if (j < nonBasicVars.Count)
                        header = nonBasicVars[j];
                    else
                        header = basicVars[j - nonBasicVars.Count];
                    dgvTableau.Columns.Add("col" + j, header);
                }
            }

            dgvTableau.Rows.Clear();
            for (int i = 0; i < rows; i++)
            {
                object[] rowVals = new object[cols];
                for (int j = 0; j < cols; j++)
                    rowVals[j] = tableau[i, j].ToString("0.###");
                dgvTableau.Rows.Add(rowVals);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
