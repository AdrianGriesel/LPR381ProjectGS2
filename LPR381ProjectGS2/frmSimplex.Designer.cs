namespace LPR381ProjectGS2
{
    partial class frmSimplex
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtSignRestrictions = new System.Windows.Forms.TextBox();
            this.txtConstraints = new System.Windows.Forms.TextBox();
            this.txtObjective = new System.Windows.Forms.TextBox();
            this.dgvTableau = new System.Windows.Forms.DataGridView();
            this.lblPivotInfo = new System.Windows.Forms.Label();
            this.txtIterationDetails = new System.Windows.Forms.TextBox();
            this.btnNextIteration = new System.Windows.Forms.Button();
            this.txtVariableValues = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableau)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(350, 45);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(56, 19);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Load LP File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSignRestrictions
            // 
            this.txtSignRestrictions.Location = new System.Drawing.Point(98, 125);
            this.txtSignRestrictions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSignRestrictions.Name = "txtSignRestrictions";
            this.txtSignRestrictions.Size = new System.Drawing.Size(192, 20);
            this.txtSignRestrictions.TabIndex = 2;
            // 
            // txtConstraints
            // 
            this.txtConstraints.Location = new System.Drawing.Point(98, 69);
            this.txtConstraints.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConstraints.Multiline = true;
            this.txtConstraints.Name = "txtConstraints";
            this.txtConstraints.Size = new System.Drawing.Size(246, 50);
            this.txtConstraints.TabIndex = 3;
            // 
            // txtObjective
            // 
            this.txtObjective.Location = new System.Drawing.Point(98, 45);
            this.txtObjective.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtObjective.Name = "txtObjective";
            this.txtObjective.Size = new System.Drawing.Size(210, 20);
            this.txtObjective.TabIndex = 4;
            // 
            // dgvTableau
            // 
            this.dgvTableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableau.Location = new System.Drawing.Point(12, 194);
            this.dgvTableau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvTableau.Name = "dgvTableau";
            this.dgvTableau.RowHeadersWidth = 51;
            this.dgvTableau.RowTemplate.Height = 24;
            this.dgvTableau.Size = new System.Drawing.Size(418, 152);
            this.dgvTableau.TabIndex = 5;
            // 
            // lblPivotInfo
            // 
            this.lblPivotInfo.AutoSize = true;
            this.lblPivotInfo.Location = new System.Drawing.Point(9, 178);
            this.lblPivotInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPivotInfo.Name = "lblPivotInfo";
            this.lblPivotInfo.Size = new System.Drawing.Size(34, 13);
            this.lblPivotInfo.TabIndex = 6;
            this.lblPivotInfo.Text = "Pivot ";
            // 
            // txtIterationDetails
            // 
            this.txtIterationDetails.Location = new System.Drawing.Point(12, 415);
            this.txtIterationDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIterationDetails.Multiline = true;
            this.txtIterationDetails.Name = "txtIterationDetails";
            this.txtIterationDetails.Size = new System.Drawing.Size(420, 109);
            this.txtIterationDetails.TabIndex = 7;
            // 
            // btnNextIteration
            // 
            this.btnNextIteration.Location = new System.Drawing.Point(12, 350);
            this.btnNextIteration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNextIteration.Name = "btnNextIteration";
            this.btnNextIteration.Size = new System.Drawing.Size(75, 51);
            this.btnNextIteration.TabIndex = 8;
            this.btnNextIteration.Text = "next itteration";
            this.btnNextIteration.UseVisualStyleBackColor = true;
            this.btnNextIteration.Click += new System.EventHandler(this.btnNextIteration_Click);
            // 
            // txtVariableValues
            // 
            this.txtVariableValues.Location = new System.Drawing.Point(476, 194);
            this.txtVariableValues.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVariableValues.Multiline = true;
            this.txtVariableValues.Name = "txtVariableValues";
            this.txtVariableValues.Size = new System.Drawing.Size(249, 152);
            this.txtVariableValues.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "LP Objective";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Constraints";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sign Restrictions";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Optimal Sulotion";
            // 
            // frmSimplex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 559);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVariableValues);
            this.Controls.Add(this.btnNextIteration);
            this.Controls.Add(this.txtIterationDetails);
            this.Controls.Add(this.lblPivotInfo);
            this.Controls.Add(this.dgvTableau);
            this.Controls.Add(this.txtObjective);
            this.Controls.Add(this.txtConstraints);
            this.Controls.Add(this.txtSignRestrictions);
            this.Controls.Add(this.btnBrowse);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmSimplex";
            this.Text = "frmSimplex";
            this.Load += new System.EventHandler(this.frmSimplex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtSignRestrictions;
        private System.Windows.Forms.TextBox txtConstraints;
        private System.Windows.Forms.TextBox txtObjective;
        private System.Windows.Forms.DataGridView dgvTableau;
        private System.Windows.Forms.Label lblPivotInfo;
        private System.Windows.Forms.TextBox txtIterationDetails;
        private System.Windows.Forms.Button btnNextIteration;
        private System.Windows.Forms.TextBox txtVariableValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}