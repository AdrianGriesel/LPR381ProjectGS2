namespace LPR381ProjectGS2
{
    partial class frmCuttingPlane
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TabControl tabIterations;
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
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.tabIterations = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadFile.Location = new System.Drawing.Point(0, 0);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(800, 40);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load LP File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // tabIterations
            // 
            this.tabIterations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIterations.Location = new System.Drawing.Point(0, 40);
            this.tabIterations.Name = "tabIterations";
            this.tabIterations.SelectedIndex = 0;
            this.tabIterations.Size = new System.Drawing.Size(800, 410);
            this.tabIterations.TabIndex = 1;
            // 
            // frmCuttingPlane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabIterations);
            this.Controls.Add(this.btnLoadFile);
            this.Name = "frmCuttingPlane";
            this.Text = "Cutting Plane Solver";
            this.ResumeLayout(false);


        }

        #endregion
    }
}