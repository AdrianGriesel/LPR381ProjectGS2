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
            this.btnPrimalSolver = new System.Windows.Forms.Button();
            this.btnKnapsackBnb = new System.Windows.Forms.Button();
            this.btnBranchAndBound = new System.Windows.Forms.Button();
            this.btnCuttingPlane = new System.Windows.Forms.Button();
            this.btnSensitivityAnalysis = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMethods = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrimalSolver
            // 
            this.btnPrimalSolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimalSolver.Location = new System.Drawing.Point(28, 78);
            this.btnPrimalSolver.Name = "btnPrimalSolver";
            this.btnPrimalSolver.Size = new System.Drawing.Size(435, 47);
            this.btnPrimalSolver.TabIndex = 1;
            this.btnPrimalSolver.Text = "Go To Primal Simplex Solver";
            this.btnPrimalSolver.UseVisualStyleBackColor = true;
            this.btnPrimalSolver.Click += new System.EventHandler(this.btnPrimalSolver_Click);
            // 
            // btnKnapsackBnb
            // 
            this.btnKnapsackBnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKnapsackBnb.Location = new System.Drawing.Point(28, 186);
            this.btnKnapsackBnb.Name = "btnKnapsackBnb";
            this.btnKnapsackBnb.Size = new System.Drawing.Size(435, 47);
            this.btnKnapsackBnb.TabIndex = 2;
            this.btnKnapsackBnb.Text = "Go To Knapsack and Branch and Bound";
            this.btnKnapsackBnb.UseVisualStyleBackColor = true;
            this.btnKnapsackBnb.Click += new System.EventHandler(this.btnKnapsackBnb_Click);
            // 
            // btnBranchAndBound
            // 
            this.btnBranchAndBound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBranchAndBound.Location = new System.Drawing.Point(28, 239);
            this.btnBranchAndBound.Name = "btnBranchAndBound";
            this.btnBranchAndBound.Size = new System.Drawing.Size(435, 47);
            this.btnBranchAndBound.TabIndex = 3;
            this.btnBranchAndBound.Text = "Go to Branch and Bound";
            this.btnBranchAndBound.UseVisualStyleBackColor = true;
            this.btnBranchAndBound.Click += new System.EventHandler(this.btnBranchAndBound_Click);
            // 
            // btnCuttingPlane
            // 
            this.btnCuttingPlane.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuttingPlane.Location = new System.Drawing.Point(28, 132);
            this.btnCuttingPlane.Name = "btnCuttingPlane";
            this.btnCuttingPlane.Size = new System.Drawing.Size(435, 47);
            this.btnCuttingPlane.TabIndex = 4;
            this.btnCuttingPlane.Text = "Go to Cutting Plane";
            this.btnCuttingPlane.UseVisualStyleBackColor = true;
            this.btnCuttingPlane.Click += new System.EventHandler(this.btnCuttingPlane_Click);
            // 
            // btnSensitivityAnalysis
            // 
            this.btnSensitivityAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSensitivityAnalysis.Location = new System.Drawing.Point(19, 281);
            this.btnSensitivityAnalysis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSensitivityAnalysis.Name = "btnSensitivityAnalysis";
            this.btnSensitivityAnalysis.Size = new System.Drawing.Size(435, 47);
            this.btnSensitivityAnalysis.TabIndex = 2;
            this.btnSensitivityAnalysis.Text = "Go To Sensitivity Analysis";
            this.btnSensitivityAnalysis.UseVisualStyleBackColor = true;
            this.btnSensitivityAnalysis.Click += new System.EventHandler(this.btnSensitivityAnalysis_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblMethods);
            this.panel1.Controls.Add(this.btnSensitivityAnalysis);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 377);
            this.panel1.TabIndex = 5;
            // 
            // lblMethods
            // 
            this.lblMethods.AutoSize = true;
            this.lblMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethods.Location = new System.Drawing.Point(15, 41);
            this.lblMethods.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMethods.Name = "lblMethods";
            this.lblMethods.Size = new System.Drawing.Size(96, 24);
            this.lblMethods.TabIndex = 5;
            this.lblMethods.Text = "Methods:";
            this.lblMethods.Click += new System.EventHandler(this.label1_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(514, 408);
            this.Controls.Add(this.btnCuttingPlane);
            this.Controls.Add(this.btnBranchAndBound);
            this.Controls.Add(this.btnKnapsackBnb);
            this.Controls.Add(this.btnPrimalSolver);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Main_Form";
            this.Text = "Main_Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrimalSolver;
        private System.Windows.Forms.Button btnKnapsackBnb;
        private System.Windows.Forms.Button btnBranchAndBound;
        private System.Windows.Forms.Button btnCuttingPlane;
        private System.Windows.Forms.Button btnSensitivityAnalysis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMethods;

    }
}