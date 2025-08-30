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
            this.SuspendLayout();
            // 
            // btnSimplex
            // 
            this.btnSimplex.Location = new System.Drawing.Point(10, 11);
            this.btnSimplex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSimplex.Name = "btnSimplex";
            this.btnSimplex.Size = new System.Drawing.Size(155, 34);
            this.btnSimplex.TabIndex = 0;
            this.btnSimplex.Text = "Go To Simplex Solver";
            this.btnSimplex.UseVisualStyleBackColor = true;
            this.btnSimplex.Click += new System.EventHandler(this.btnPrimal_Click);
            // 
            // btnPrimalSolver
            // 
            this.btnPrimalSolver.Location = new System.Drawing.Point(10, 51);
            this.btnPrimalSolver.Name = "btnPrimalSolver";
            this.btnPrimalSolver.Size = new System.Drawing.Size(155, 38);
            this.btnPrimalSolver.TabIndex = 1;
            this.btnPrimalSolver.Text = "Go To Primal Simplex Solver";
            this.btnPrimalSolver.UseVisualStyleBackColor = true;
            this.btnPrimalSolver.Click += new System.EventHandler(this.btnPrimalSolver_Click);
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
            // btnKnapsackBnb
            // 
            this.btnKnapsackBnb.Location = new System.Drawing.Point(10, 96);
            this.btnKnapsackBnb.Name = "btnKnapsackBnb";
            this.btnKnapsackBnb.Size = new System.Drawing.Size(155, 46);
            this.btnKnapsackBnb.TabIndex = 2;
            this.btnKnapsackBnb.Text = "Go To Knapsack and Branch and Bound";
            this.btnKnapsackBnb.UseVisualStyleBackColor = true;
            this.btnKnapsackBnb.Click += new System.EventHandler(this.btnKnapsackBnb_Click);
            // 
            // btnBranchAndBound
            // 
            this.btnBranchAndBound.Location = new System.Drawing.Point(12, 148);
            this.btnBranchAndBound.Name = "btnBranchAndBound";
            this.btnBranchAndBound.Size = new System.Drawing.Size(153, 40);
            this.btnBranchAndBound.TabIndex = 3;
            this.btnBranchAndBound.Text = "Go to Branch and Bound";
            this.btnBranchAndBound.UseVisualStyleBackColor = true;
            this.btnBranchAndBound.Click += new System.EventHandler(this.btnBranchAndBound_Click);
            // 
            // btnCuttingPlane
            // 
            this.btnCuttingPlane.Location = new System.Drawing.Point(12, 194);
            this.btnCuttingPlane.Name = "btnCuttingPlane";
            this.btnCuttingPlane.Size = new System.Drawing.Size(153, 40);
            this.btnCuttingPlane.TabIndex = 4;
            this.btnCuttingPlane.Text = "Go to Cutting Plane";
            this.btnCuttingPlane.UseVisualStyleBackColor = true;
            this.btnCuttingPlane.Click += new System.EventHandler(this.btnCuttingPlane_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnCuttingPlane);
            this.Controls.Add(this.btnBranchAndBound);
            this.Controls.Add(this.btnKnapsackBnb);
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnSensitivityAnalysis);
            this.Controls.Add(this.btnPrimalSolver);
            this.Controls.Add(this.btnSimplex);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Main_Form";
            this.Text = "Main_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSimplex;
        private System.Windows.Forms.Button btnPrimalSolver;
        private System.Windows.Forms.Button btnKnapsackBnb;
        private System.Windows.Forms.Button btnBranchAndBound;
        private System.Windows.Forms.Button btnCuttingPlane;
        private System.Windows.Forms.Button btnSensitivityAnalysis;
    }
}