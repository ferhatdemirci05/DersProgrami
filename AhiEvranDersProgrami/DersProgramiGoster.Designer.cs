namespace AhiEvranDersProgrami
{
    partial class DersProgramiGoster
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
            this.label_Bilgi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Bilgi
            // 
            this.label_Bilgi.AutoSize = true;
            this.label_Bilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Bilgi.Location = new System.Drawing.Point(12, 9);
            this.label_Bilgi.Name = "label_Bilgi";
            this.label_Bilgi.Size = new System.Drawing.Size(0, 16);
            this.label_Bilgi.TabIndex = 0;
            // 
            // DersProgramiGoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1243, 537);
            this.Controls.Add(this.label_Bilgi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1263, 577);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1263, 577);
            this.Name = "DersProgramiGoster";
            this.Text = "DersProgramiGoster";
            this.Load += new System.EventHandler(this.DersProgramiGoster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Bilgi;

    }
}