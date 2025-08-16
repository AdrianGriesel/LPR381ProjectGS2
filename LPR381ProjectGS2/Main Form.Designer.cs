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
            this.btnPrimal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrimal
            // 
            this.btnPrimal.Location = new System.Drawing.Point(13, 13);
            this.btnPrimal.Name = "btnPrimal";
            this.btnPrimal.Size = new System.Drawing.Size(155, 23);
            this.btnPrimal.TabIndex = 0;
            this.btnPrimal.Text = "Go To Primal Simplex";
            this.btnPrimal.UseVisualStyleBackColor = true;
            this.btnPrimal.Click += new System.EventHandler(this.btnPrimal_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrimal);
            this.Name = "Main_Form";
            this.Text = "Main_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrimal;
    }
}