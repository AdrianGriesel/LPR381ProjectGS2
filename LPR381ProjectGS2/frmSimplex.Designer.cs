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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableau)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(520, 14);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 27);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Load LP File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSignRestrictions
            // 
            this.txtSignRestrictions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSignRestrictions.Location = new System.Drawing.Point(199, 115);
            this.txtSignRestrictions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSignRestrictions.Name = "txtSignRestrictions";
            this.txtSignRestrictions.Size = new System.Drawing.Size(304, 27);
            this.txtSignRestrictions.TabIndex = 2;
            // 
            // txtConstraints
            // 
            this.txtConstraints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConstraints.Location = new System.Drawing.Point(199, 47);
            this.txtConstraints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConstraints.Multiline = true;
            this.txtConstraints.Name = "txtConstraints";
            this.txtConstraints.Size = new System.Drawing.Size(304, 61);
            this.txtConstraints.TabIndex = 3;
            // 
            // txtObjective
            // 
            this.txtObjective.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjective.Location = new System.Drawing.Point(199, 14);
            this.txtObjective.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObjective.Name = "txtObjective";
            this.txtObjective.Size = new System.Drawing.Size(304, 27);
            this.txtObjective.TabIndex = 4;
            // 
            // dgvTableau
            // 
            this.dgvTableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableau.Location = new System.Drawing.Point(20, 177);
            this.dgvTableau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTableau.Name = "dgvTableau";
            this.dgvTableau.RowHeadersWidth = 51;
            this.dgvTableau.RowTemplate.Height = 24;
            this.dgvTableau.Size = new System.Drawing.Size(575, 187);
            this.dgvTableau.TabIndex = 5;
            // 
            // lblPivotInfo
            // 
            this.lblPivotInfo.AutoSize = true;
            this.lblPivotInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPivotInfo.Location = new System.Drawing.Point(16, 155);
            this.lblPivotInfo.Name = "lblPivotInfo";
            this.lblPivotInfo.Size = new System.Drawing.Size(57, 20);
            this.lblPivotInfo.TabIndex = 6;
            this.lblPivotInfo.Text = "Pivot ";
            // 
            // txtIterationDetails
            // 
            this.txtIterationDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIterationDetails.Location = new System.Drawing.Point(19, 422);
            this.txtIterationDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIterationDetails.Multiline = true;
            this.txtIterationDetails.Name = "txtIterationDetails";
            this.txtIterationDetails.Size = new System.Drawing.Size(576, 133);
            this.txtIterationDetails.TabIndex = 7;
            // 
            // btnNextIteration
            // 
            this.btnNextIteration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextIteration.Location = new System.Drawing.Point(20, 391);
            this.btnNextIteration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNextIteration.Name = "btnNextIteration";
            this.btnNextIteration.Size = new System.Drawing.Size(150, 27);
            this.btnNextIteration.TabIndex = 8;
            this.btnNextIteration.Text = "Next iteration";
            this.btnNextIteration.UseVisualStyleBackColor = true;
            this.btnNextIteration.Click += new System.EventHandler(this.btnNextIteration_Click);
            // 
            // txtVariableValues
            // 
            this.txtVariableValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVariableValues.Location = new System.Drawing.Point(651, 178);
            this.txtVariableValues.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVariableValues.Multiline = true;
            this.txtVariableValues.Name = "txtVariableValues";
            this.txtVariableValues.Size = new System.Drawing.Size(399, 377);
            this.txtVariableValues.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "LP Objective";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Constraints";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sign Restrictions";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(784, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Optimal Sulotion";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnNextIteration);
            this.panel1.Controls.Add(this.txtVariableValues);
            this.panel1.Controls.Add(this.dgvTableau);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtIterationDetails);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtConstraints);
            this.panel1.Controls.Add(this.lblPivotInfo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSignRestrictions);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtObjective);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 562);
            this.panel1.TabIndex = 14;
            // 
            // frmSimplex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 586);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSimplex";
            this.Text = "frmSimplex";
            this.Load += new System.EventHandler(this.frmSimplex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableau)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel1;
    }
}