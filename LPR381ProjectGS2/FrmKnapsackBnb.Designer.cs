namespace LPR381ProjectGS2
{
    partial class FrmKnapsackBnb
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
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblBest = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gridIterations = new System.Windows.Forms.DataGridView();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.txtBestValue = new System.Windows.Forms.TextBox();
            this.txtItemsTaken = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(95, 153);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(60, 16);
            this.lblCapacity.TabIndex = 0;
            this.lblCapacity.Text = "Capacity";
            // 
            // lblBest
            // 
            this.lblBest.AutoSize = true;
            this.lblBest.Location = new System.Drawing.Point(95, 201);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(78, 16);
            this.lblBest.TabIndex = 1;
            this.lblBest.Text = "Best Value: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Items Taken:";
            // 
            // gridIterations
            // 
            this.gridIterations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridIterations.Location = new System.Drawing.Point(809, 121);
            this.gridIterations.Name = "gridIterations";
            this.gridIterations.RowHeadersWidth = 51;
            this.gridIterations.RowTemplate.Height = 24;
            this.gridIterations.Size = new System.Drawing.Size(528, 243);
            this.gridIterations.TabIndex = 3;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(809, 384);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 4;
            this.btnSolve.Text = "Solve ";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(921, 384);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1045, 384);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(219, 147);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.ReadOnly = true;
            this.txtCapacity.Size = new System.Drawing.Size(176, 22);
            this.txtCapacity.TabIndex = 7;
            // 
            // txtBestValue
            // 
            this.txtBestValue.Location = new System.Drawing.Point(219, 201);
            this.txtBestValue.Name = "txtBestValue";
            this.txtBestValue.ReadOnly = true;
            this.txtBestValue.Size = new System.Drawing.Size(176, 22);
            this.txtBestValue.TabIndex = 8;
            // 
            // txtItemsTaken
            // 
            this.txtItemsTaken.Location = new System.Drawing.Point(219, 251);
            this.txtItemsTaken.Name = "txtItemsTaken";
            this.txtItemsTaken.ReadOnly = true;
            this.txtItemsTaken.Size = new System.Drawing.Size(176, 22);
            this.txtItemsTaken.TabIndex = 9;
            // 
            // FrmKnapsackBnb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 562);
            this.Controls.Add(this.txtItemsTaken);
            this.Controls.Add(this.txtBestValue);
            this.Controls.Add(this.txtCapacity);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.gridIterations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBest);
            this.Controls.Add(this.lblCapacity);
            this.Name = "FrmKnapsackBnb";
            this.Text = "FrmKnapsackBnb";
            this.Load += new System.EventHandler(this.FrmKnapsackBnb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridIterations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblBest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridIterations;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.TextBox txtBestValue;
        private System.Windows.Forms.TextBox txtItemsTaken;
    }
}