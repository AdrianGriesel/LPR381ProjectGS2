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
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableau)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(381, 59);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Load LP File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSignRestrictions
            // 
            this.txtSignRestrictions.Location = new System.Drawing.Point(76, 154);
            this.txtSignRestrictions.Name = "txtSignRestrictions";
            this.txtSignRestrictions.Size = new System.Drawing.Size(278, 22);
            this.txtSignRestrictions.TabIndex = 2;
            // 
            // txtConstraints
            // 
            this.txtConstraints.Location = new System.Drawing.Point(76, 88);
            this.txtConstraints.Multiline = true;
            this.txtConstraints.Name = "txtConstraints";
            this.txtConstraints.Size = new System.Drawing.Size(350, 60);
            this.txtConstraints.TabIndex = 3;
            // 
            // txtObjective
            // 
            this.txtObjective.Location = new System.Drawing.Point(76, 60);
            this.txtObjective.Name = "txtObjective";
            this.txtObjective.Size = new System.Drawing.Size(299, 22);
            this.txtObjective.TabIndex = 4;
            // 
            // dgvTableau
            // 
            this.dgvTableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableau.Location = new System.Drawing.Point(220, 253);
            this.dgvTableau.Name = "dgvTableau";
            this.dgvTableau.RowHeadersWidth = 51;
            this.dgvTableau.RowTemplate.Height = 24;
            this.dgvTableau.Size = new System.Drawing.Size(558, 187);
            this.dgvTableau.TabIndex = 5;
            // 
            // lblPivotInfo
            // 
            this.lblPivotInfo.AutoSize = true;
            this.lblPivotInfo.Location = new System.Drawing.Point(217, 234);
            this.lblPivotInfo.Name = "lblPivotInfo";
            this.lblPivotInfo.Size = new System.Drawing.Size(40, 16);
            this.lblPivotInfo.TabIndex = 6;
            this.lblPivotInfo.Text = "Pivot ";
            // 
            // txtIterationDetails
            // 
            this.txtIterationDetails.Location = new System.Drawing.Point(220, 446);
            this.txtIterationDetails.Multiline = true;
            this.txtIterationDetails.Name = "txtIterationDetails";
            this.txtIterationDetails.Size = new System.Drawing.Size(558, 133);
            this.txtIterationDetails.TabIndex = 7;
            // 
            // btnNextIteration
            // 
            this.btnNextIteration.Location = new System.Drawing.Point(114, 281);
            this.btnNextIteration.Name = "btnNextIteration";
            this.btnNextIteration.Size = new System.Drawing.Size(100, 63);
            this.btnNextIteration.TabIndex = 8;
            this.btnNextIteration.Text = "next itteration";
            this.btnNextIteration.UseVisualStyleBackColor = true;
            this.btnNextIteration.Click += new System.EventHandler(this.btnNextIteration_Click);
            // 
            // txtVariableValues
            // 
            this.txtVariableValues.Location = new System.Drawing.Point(784, 263);
            this.txtVariableValues.Multiline = true;
            this.txtVariableValues.Name = "txtVariableValues";
            this.txtVariableValues.Size = new System.Drawing.Size(271, 150);
            this.txtVariableValues.TabIndex = 9;
            // 
            // frmSimplex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 688);
            this.Controls.Add(this.txtVariableValues);
            this.Controls.Add(this.btnNextIteration);
            this.Controls.Add(this.txtIterationDetails);
            this.Controls.Add(this.lblPivotInfo);
            this.Controls.Add(this.dgvTableau);
            this.Controls.Add(this.txtObjective);
            this.Controls.Add(this.txtConstraints);
            this.Controls.Add(this.txtSignRestrictions);
            this.Controls.Add(this.btnBrowse);
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
    }
}