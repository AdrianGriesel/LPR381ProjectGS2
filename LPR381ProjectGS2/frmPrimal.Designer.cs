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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridTableau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOptimal)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(52, 484);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(241, 62);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open LP";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.Location = new System.Drawing.Point(332, 472);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(245, 62);
            this.btnSolve.TabIndex = 1;
            this.btnSolve.Text = "Solve (Primal)";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(634, 472);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(319, 62);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export Output";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(630, 3);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 20);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            // 
            // lstIterations
            // 
            this.lstIterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstIterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIterations.FormattingEnabled = true;
            this.lstIterations.IntegralHeight = false;
            this.lstIterations.ItemHeight = 20;
            this.lstIterations.Location = new System.Drawing.Point(634, 27);
            this.lstIterations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstIterations.Name = "lstIterations";
            this.lstIterations.Size = new System.Drawing.Size(319, 396);
            this.lstIterations.TabIndex = 4;
            this.lstIterations.SelectedIndexChanged += new System.EventHandler(this.lstIterations_SelectedIndexChanged);
            // 
            // gridTableau
            // 
            this.gridTableau.AllowUserToAddRows = false;
            this.gridTableau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridTableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTableau.Location = new System.Drawing.Point(52, 39);
            this.gridTableau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridTableau.Name = "gridTableau";
            this.gridTableau.ReadOnly = true;
            this.gridTableau.RowHeadersVisible = false;
            this.gridTableau.RowHeadersWidth = 51;
            this.gridTableau.Size = new System.Drawing.Size(537, 180);
            this.gridTableau.TabIndex = 5;
            this.gridTableau.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTableau_CellContentClick);
            // 
            // gridOptimal
            // 
            this.gridOptimal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOptimal.Location = new System.Drawing.Point(52, 254);
            this.gridOptimal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridOptimal.Name = "gridOptimal";
            this.gridOptimal.RowHeadersWidth = 51;
            this.gridOptimal.Size = new System.Drawing.Size(537, 181);
            this.gridOptimal.TabIndex = 6;
            this.gridOptimal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOptimal_CellContentClick);
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIterations.Location = new System.Drawing.Point(52, 15);
            this.lblIterations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(94, 20);
            this.lblIterations.TabIndex = 7;
            this.lblIterations.Text = "Iterations:";
            // 
            // lblOptimal
            // 
            this.lblOptimal.AutoSize = true;
            this.lblOptimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptimal.Location = new System.Drawing.Point(52, 230);
            this.lblOptimal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptimal.Name = "lblOptimal";
            this.lblOptimal.Size = new System.Drawing.Size(154, 20);
            this.lblOptimal.TabIndex = 8;
            this.lblOptimal.Text = "Optimal Solution:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lstIterations);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnSolve);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 552);
            this.panel1.TabIndex = 15;
            // 
            // frmPrimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1015, 576);
            this.Controls.Add(this.lblOptimal);
            this.Controls.Add(this.lblIterations);
            this.Controls.Add(this.gridOptimal);
            this.Controls.Add(this.gridTableau);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPrimal";
            this.Text = "Primal Simplex Solver";
            this.Load += new System.EventHandler(this.frmPrimal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTableau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOptimal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
    }
}