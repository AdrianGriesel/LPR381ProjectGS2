namespace LPR381ProjectGS2
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSimplex = new System.Windows.Forms.Button();
            this.btnPrimalSolver = new System.Windows.Forms.Button();
            this.btnKnapsackBnb = new System.Windows.Forms.Button();
            this.btnBranchAndBound = new System.Windows.Forms.Button();
            this.btnCuttingPlane = new System.Windows.Forms.Button();

            this.btnSensitivityAnalysis = new System.Windows.Forms.Button();
            this.btnSensitvityAnalysis = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMethods = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSimplex
            // 
            this.btnSimplex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimplex.Location = new System.Drawing.Point(37, 78);
            this.btnSimplex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSimplex.Name = "btnSimplex";
            this.btnSimplex.Size = new System.Drawing.Size(580, 58);
            this.btnSimplex.TabIndex = 0;
            this.btnSimplex.Text = "Go To Simplex Solver";
            this.btnSimplex.UseVisualStyleBackColor = true;
            this.btnSimplex.Click += new System.EventHandler(this.btnPrimal_Click);
            // 
            // btnPrimalSolver
            // 
            this.btnPrimalSolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimalSolver.Location = new System.Drawing.Point(37, 142);
            this.btnPrimalSolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrimalSolver.Name = "btnPrimalSolver";
            this.btnPrimalSolver.Size = new System.Drawing.Size(580, 58);
            this.btnPrimalSolver.TabIndex = 1;
            this.btnPrimalSolver.Text = "Go To Primal Simplex Solver";
            this.btnPrimalSolver.UseVisualStyleBackColor = true;
            this.btnPrimalSolver.Click += new System.EventHandler(this.btnPrimalSolver_Click);
            // 
            // btnKnapsackBnb
            // 
            this.btnKnapsackBnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKnapsackBnb.Location = new System.Drawing.Point(37, 274);
            this.btnKnapsackBnb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKnapsackBnb.Name = "btnKnapsackBnb";
            this.btnKnapsackBnb.Size = new System.Drawing.Size(580, 58);
            this.btnKnapsackBnb.TabIndex = 2;
            this.btnKnapsackBnb.Text = "Go To Knapsack and Branch and Bound";
            this.btnKnapsackBnb.UseVisualStyleBackColor = true;
            this.btnKnapsackBnb.Click += new System.EventHandler(this.btnKnapsackBnb_Click);
            // 
            // btnBranchAndBound
            // 
            this.btnBranchAndBound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBranchAndBound.Location = new System.Drawing.Point(37, 340);
            this.btnBranchAndBound.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBranchAndBound.Name = "btnBranchAndBound";
            this.btnBranchAndBound.Size = new System.Drawing.Size(580, 58);
            this.btnBranchAndBound.TabIndex = 3;
            this.btnBranchAndBound.Text = "Go to Branch and Bound";
            this.btnBranchAndBound.UseVisualStyleBackColor = true;
            this.btnBranchAndBound.Click += new System.EventHandler(this.btnBranchAndBound_Click);
            // 
            // btnCuttingPlane
            // 
            this.btnCuttingPlane.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuttingPlane.Location = new System.Drawing.Point(37, 208);
            this.btnCuttingPlane.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCuttingPlane.Name = "btnCuttingPlane";
            this.btnCuttingPlane.Size = new System.Drawing.Size(580, 58);
            this.btnCuttingPlane.TabIndex = 4;
            this.btnCuttingPlane.Text = "Go to Cutting Plane";
            this.btnCuttingPlane.UseVisualStyleBackColor = true;
            this.btnCuttingPlane.Click += new System.EventHandler(this.btnCuttingPlane_Click);
            // 
            // btnSensitivityAnalysis
            // 
            this.btnSensitivityAnalysis.Location = new System.Drawing.Point(10, 96);
            this.btnSensitivityAnalysis.Name = "btnSensitivityAnalysis";
            this.btnSensitivityAnalysis.Size = new System.Drawing.Size(155, 42);
            this.btnSensitivityAnalysis.TabIndex = 2;
            this.btnSensitivityAnalysis.Text = "Go To Sensitivity Analysis";
            this.btnSensitivityAnalysis.UseVisualStyleBackColor = true;
            this.btnSensitivityAnalysis.Click += new System.EventHandler(this.btnSensitivityAnalysis_Click);
            // 
            // btnSensitvityAnalysis
            // 
            this.btnSensitvityAnalysis.Location = new System.Drawing.Point(12, 240);
            this.btnSensitvityAnalysis.Name = "btnSensitvityAnalysis";
            this.btnSensitvityAnalysis.Size = new System.Drawing.Size(153, 40);
            this.btnSensitvityAnalysis.TabIndex = 5;
            this.btnSensitvityAnalysis.Text = "Go to Sensitivity Analysis";
            this.btnSensitvityAnalysis.UseVisualStyleBackColor = true;
            this.btnSensitvityAnalysis.Click += new System.EventHandler(this.btnSensitvityAnalysis_Click);
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblMethods);
            this.panel1.Controls.Add(this.btnSimplex);
            this.panel1.Controls.Add(this.btnBranchAndBound);
            this.panel1.Controls.Add(this.btnCuttingPlane);
            this.panel1.Controls.Add(this.btnPrimalSolver);
            this.panel1.Controls.Add(this.btnKnapsackBnb);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 426);
            this.panel1.TabIndex = 5;
            // 
            // lblMethods
            // 
            this.lblMethods.AutoSize = true;
            this.lblMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethods.Location = new System.Drawing.Point(271, 23);
            this.lblMethods.Name = "lblMethods";
            this.lblMethods.Size = new System.Drawing.Size(127, 29);
            this.lblMethods.TabIndex = 5;
            this.lblMethods.Text = "Methods :";
            this.lblMethods.Click += new System.EventHandler(this.label1_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSensitvityAnalysis);
            this.Controls.Add(this.btnCuttingPlane);
            this.Controls.Add(this.btnBranchAndBound);
            this.Controls.Add(this.btnKnapsackBnb);
            this.Controls.Add(this.btnSensitivityAnalysis);
            this.Controls.Add(this.btnPrimalSolver);
            this.Controls.Add(this.btnSimplex);
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(685, 454);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main_Form";
            this.Text = "Main_Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSimplex;
        private System.Windows.Forms.Button btnPrimalSolver;
        private System.Windows.Forms.Button btnKnapsackBnb;
        private System.Windows.Forms.Button btnBranchAndBound;
        private System.Windows.Forms.Button btnCuttingPlane;
        private System.Windows.Forms.Button btnSensitivityAnalysis;
        private System.Windows.Forms.Button btnSensitvityAnalysis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMethods;

    }
}