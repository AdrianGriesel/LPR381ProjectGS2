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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridIterations)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.Location = new System.Drawing.Point(30, 26);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(82, 20);
            this.lblCapacity.TabIndex = 0;
            this.lblCapacity.Text = "Capacity";
            // 
            // lblBest
            // 
            this.lblBest.AutoSize = true;
            this.lblBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBest.Location = new System.Drawing.Point(30, 74);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(113, 20);
            this.lblBest.TabIndex = 1;
            this.lblBest.Text = "Best Value: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Items Taken:";
            // 
            // gridIterations
            // 
            this.gridIterations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridIterations.Location = new System.Drawing.Point(33, 182);
            this.gridIterations.Name = "gridIterations";
            this.gridIterations.RowHeadersWidth = 51;
            this.gridIterations.RowTemplate.Height = 24;
            this.gridIterations.Size = new System.Drawing.Size(528, 243);
            this.gridIterations.TabIndex = 3;
            // 
            // btnSolve
            // 
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.Location = new System.Drawing.Point(33, 470);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(153, 35);
            this.btnSolve.TabIndex = 4;
            this.btnSolve.Text = "Solve ";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(210, 470);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(164, 35);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(396, 470);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(165, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCapacity
            // 
            this.txtCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacity.Location = new System.Drawing.Point(154, 20);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.ReadOnly = true;
            this.txtCapacity.Size = new System.Drawing.Size(407, 27);
            this.txtCapacity.TabIndex = 7;
            // 
            // txtBestValue
            // 
            this.txtBestValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBestValue.Location = new System.Drawing.Point(154, 74);
            this.txtBestValue.Name = "txtBestValue";
            this.txtBestValue.ReadOnly = true;
            this.txtBestValue.Size = new System.Drawing.Size(407, 27);
            this.txtBestValue.TabIndex = 8;
            // 
            // txtItemsTaken
            // 
            this.txtItemsTaken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemsTaken.Location = new System.Drawing.Point(154, 124);
            this.txtItemsTaken.Name = "txtItemsTaken";
            this.txtItemsTaken.ReadOnly = true;
            this.txtItemsTaken.Size = new System.Drawing.Size(407, 27);
            this.txtItemsTaken.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.txtItemsTaken);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnSolve);
            this.panel1.Controls.Add(this.gridIterations);
            this.panel1.Controls.Add(this.txtBestValue);
            this.panel1.Controls.Add(this.txtCapacity);
            this.panel1.Controls.Add(this.lblCapacity);
            this.panel1.Controls.Add(this.lblBest);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 538);
            this.panel1.TabIndex = 15;
            // 
            // FrmKnapsackBnb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(680, 559);
            this.Controls.Add(this.panel1);
            this.Name = "FrmKnapsackBnb";
            this.Text = "FrmKnapsackBnb";
            this.Load += new System.EventHandler(this.FrmKnapsackBnb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridIterations)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel1;
    }
}