namespace LPR381ProjectGS2
{
    partial class frmPrimal
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lstIterations = new System.Windows.Forms.ListBox();
            this.gridTableau = new System.Windows.Forms.DataGridView();
            this.gridOptimal = new System.Windows.Forms.DataGridView();
            this.lblIterations = new System.Windows.Forms.Label();
            this.lblOptimal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTableau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOptimal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(39, 393);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(115, 50);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open LP";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(174, 393);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(136, 50);
            this.btnSolve.TabIndex = 1;
            this.btnSolve.Text = "Solve (Primal)";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(336, 393);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(106, 50);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export Output";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(36, 368);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            // 
            // lstIterations
            // 
            this.lstIterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstIterations.FormattingEnabled = true;
            this.lstIterations.IntegralHeight = false;
            this.lstIterations.Location = new System.Drawing.Point(490, 99);
            this.lstIterations.Name = "lstIterations";
            this.lstIterations.Size = new System.Drawing.Size(240, 168);
            this.lstIterations.TabIndex = 4;
            this.lstIterations.SelectedIndexChanged += new System.EventHandler(this.lstIterations_SelectedIndexChanged);
            // 
            // gridTableau
            // 
            this.gridTableau.AllowUserToAddRows = false;
            this.gridTableau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridTableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTableau.Location = new System.Drawing.Point(39, 28);
            this.gridTableau.Name = "gridTableau";
            this.gridTableau.ReadOnly = true;
            this.gridTableau.RowHeadersVisible = false;
            this.gridTableau.Size = new System.Drawing.Size(376, 150);
            this.gridTableau.TabIndex = 5;
            this.gridTableau.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTableau_CellContentClick);
            // 
            // gridOptimal
            // 
            this.gridOptimal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOptimal.Location = new System.Drawing.Point(39, 203);
            this.gridOptimal.Name = "gridOptimal";
            this.gridOptimal.Size = new System.Drawing.Size(376, 150);
            this.gridOptimal.TabIndex = 6;
            this.gridOptimal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOptimal_CellContentClick);
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(39, 12);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(53, 13);
            this.lblIterations.TabIndex = 7;
            this.lblIterations.Text = "Iterations:";
            // 
            // lblOptimal
            // 
            this.lblOptimal.AutoSize = true;
            this.lblOptimal.Location = new System.Drawing.Point(39, 187);
            this.lblOptimal.Name = "lblOptimal";
            this.lblOptimal.Size = new System.Drawing.Size(86, 13);
            this.lblOptimal.TabIndex = 8;
            this.lblOptimal.Text = "Optimal Solution:";
            // 
            // frmPrimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 468);
            this.Controls.Add(this.lblOptimal);
            this.Controls.Add(this.lblIterations);
            this.Controls.Add(this.gridOptimal);
            this.Controls.Add(this.gridTableau);
            this.Controls.Add(this.lstIterations);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.btnOpen);
            this.Name = "frmPrimal";
            this.Text = "Primal Simplex Solver";
            this.Load += new System.EventHandler(this.frmPrimal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTableau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOptimal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lstIterations;
        private System.Windows.Forms.DataGridView gridTableau;
        private System.Windows.Forms.DataGridView gridOptimal;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.Label lblOptimal;
    }
}