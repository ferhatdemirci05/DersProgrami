namespace AhiEvranDersProgrami
{
    partial class bolumekle
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
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_adi = new System.Windows.Forms.TextBox();
            this.textBox_kod = new System.Windows.Forms.TextBox();
            this.textBox_kadi = new System.Windows.Forms.TextBox();
            this.button_yeni = new System.Windows.Forms.Button();
            this.button_iptal = new System.Windows.Forms.Button();
            this.button_kaydet = new System.Windows.Forms.Button();
            this.comboBox_baskani = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_Bolum = new System.Windows.Forms.DataGridView();
            this.textBox_Bolum_Ara = new System.Windows.Forms.TextBox();
            this.button_Ara = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bolum)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(23, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 19);
            this.label10.TabIndex = 31;
            this.label10.Text = "Bölüm Kodu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(23, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "Bölüm Kısa Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(23, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 30;
            this.label1.Text = "Bölüm Adı";
            // 
            // textBox_adi
            // 
            this.textBox_adi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_adi.Location = new System.Drawing.Point(141, 91);
            this.textBox_adi.Name = "textBox_adi";
            this.textBox_adi.Size = new System.Drawing.Size(184, 26);
            this.textBox_adi.TabIndex = 3;
            this.textBox_adi.Enter += new System.EventHandler(this.textBox_adi_Enter);
            this.textBox_adi.Leave += new System.EventHandler(this.textBox_adi_Leave);
            // 
            // textBox_kod
            // 
            this.textBox_kod.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_kod.Location = new System.Drawing.Point(141, 17);
            this.textBox_kod.Name = "textBox_kod";
            this.textBox_kod.Size = new System.Drawing.Size(184, 26);
            this.textBox_kod.TabIndex = 1;
            this.textBox_kod.Enter += new System.EventHandler(this.textBox_adi_Enter);
            this.textBox_kod.Leave += new System.EventHandler(this.textBox_adi_Leave);
            // 
            // textBox_kadi
            // 
            this.textBox_kadi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_kadi.Location = new System.Drawing.Point(141, 54);
            this.textBox_kadi.Name = "textBox_kadi";
            this.textBox_kadi.Size = new System.Drawing.Size(184, 26);
            this.textBox_kadi.TabIndex = 2;
            this.textBox_kadi.Enter += new System.EventHandler(this.textBox_adi_Enter);
            this.textBox_kadi.Leave += new System.EventHandler(this.textBox_adi_Leave);
            // 
            // button_yeni
            // 
            this.button_yeni.BackColor = System.Drawing.Color.Transparent;
            this.button_yeni.BackgroundImage = global::AhiEvranDersProgrami.Properties.Resources.clear_master_for_android_Qtcrk4Y;
            this.button_yeni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_yeni.FlatAppearance.BorderSize = 0;
            this.button_yeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_yeni.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_yeni.ForeColor = System.Drawing.Color.Transparent;
            this.button_yeni.Location = new System.Drawing.Point(71, 189);
            this.button_yeni.Name = "button_yeni";
            this.button_yeni.Size = new System.Drawing.Size(50, 50);
            this.button_yeni.TabIndex = 5;
            this.button_yeni.UseVisualStyleBackColor = false;
            this.button_yeni.Click += new System.EventHandler(this.button_yeni_Click);
            // 
            // button_iptal
            // 
            this.button_iptal.BackColor = System.Drawing.Color.Transparent;
            this.button_iptal.BackgroundImage = global::AhiEvranDersProgrami.Properties.Resources.cancel;
            this.button_iptal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_iptal.FlatAppearance.BorderSize = 0;
            this.button_iptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_iptal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_iptal.ForeColor = System.Drawing.Color.Transparent;
            this.button_iptal.Location = new System.Drawing.Point(204, 189);
            this.button_iptal.Name = "button_iptal";
            this.button_iptal.Size = new System.Drawing.Size(50, 50);
            this.button_iptal.TabIndex = 6;
            this.button_iptal.UseVisualStyleBackColor = false;
            this.button_iptal.Click += new System.EventHandler(this.button_iptal_Click);
            // 
            // button_kaydet
            // 
            this.button_kaydet.BackColor = System.Drawing.Color.Transparent;
            this.button_kaydet.BackgroundImage = global::AhiEvranDersProgrami.Properties.Resources.save;
            this.button_kaydet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_kaydet.FlatAppearance.BorderSize = 0;
            this.button_kaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_kaydet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_kaydet.ForeColor = System.Drawing.Color.Transparent;
            this.button_kaydet.Location = new System.Drawing.Point(138, 189);
            this.button_kaydet.Name = "button_kaydet";
            this.button_kaydet.Size = new System.Drawing.Size(50, 50);
            this.button_kaydet.TabIndex = 4;
            this.button_kaydet.UseVisualStyleBackColor = false;
            this.button_kaydet.Click += new System.EventHandler(this.button_kaydet_Click);
            // 
            // comboBox_baskani
            // 
            this.comboBox_baskani.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_baskani.FormattingEnabled = true;
            this.comboBox_baskani.Location = new System.Drawing.Point(141, 128);
            this.comboBox_baskani.Name = "comboBox_baskani";
            this.comboBox_baskani.Size = new System.Drawing.Size(184, 27);
            this.comboBox_baskani.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(23, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "Bölüm Başkanı";
            // 
            // dataGridView_Bolum
            // 
            this.dataGridView_Bolum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Bolum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Bolum.Location = new System.Drawing.Point(367, 54);
            this.dataGridView_Bolum.Name = "dataGridView_Bolum";
            this.dataGridView_Bolum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Bolum.Size = new System.Drawing.Size(542, 209);
            this.dataGridView_Bolum.TabIndex = 40;
            // 
            // textBox_Bolum_Ara
            // 
            this.textBox_Bolum_Ara.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_Bolum_Ara.Location = new System.Drawing.Point(367, 17);
            this.textBox_Bolum_Ara.Name = "textBox_Bolum_Ara";
            this.textBox_Bolum_Ara.Size = new System.Drawing.Size(513, 26);
            this.textBox_Bolum_Ara.TabIndex = 1;
            this.textBox_Bolum_Ara.TextChanged += new System.EventHandler(this.textBox_Bolum_Ara_TextChanged);
            // 
            // button_Ara
            // 
            this.button_Ara.BackColor = System.Drawing.Color.White;
            this.button_Ara.BackgroundImage = global::AhiEvranDersProgrami.Properties.Resources.search;
            this.button_Ara.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Ara.FlatAppearance.BorderSize = 0;
            this.button_Ara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Ara.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Ara.ForeColor = System.Drawing.Color.Transparent;
            this.button_Ara.Location = new System.Drawing.Point(880, 17);
            this.button_Ara.Name = "button_Ara";
            this.button_Ara.Size = new System.Drawing.Size(25, 26);
            this.button_Ara.TabIndex = 12;
            this.button_Ara.UseVisualStyleBackColor = false;
            // 
            // bolumekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(921, 283);
            this.Controls.Add(this.button_Ara);
            this.Controls.Add(this.textBox_Bolum_Ara);
            this.Controls.Add(this.textBox_kod);
            this.Controls.Add(this.textBox_kadi);
            this.Controls.Add(this.textBox_adi);
            this.Controls.Add(this.comboBox_baskani);
            this.Controls.Add(this.dataGridView_Bolum);
            this.Controls.Add(this.button_yeni);
            this.Controls.Add(this.button_iptal);
            this.Controls.Add(this.button_kaydet);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "bolumekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bolumekle";
            this.Load += new System.EventHandler(this.bolumekle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bolumekle_KeyDown);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.bolumekle_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bolum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_adi;
        private System.Windows.Forms.TextBox textBox_kod;
        private System.Windows.Forms.TextBox textBox_kadi;
        private System.Windows.Forms.Button button_yeni;
        private System.Windows.Forms.Button button_iptal;
        private System.Windows.Forms.Button button_kaydet;
        private System.Windows.Forms.ComboBox comboBox_baskani;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_Bolum;
        private System.Windows.Forms.TextBox textBox_Bolum_Ara;
        private System.Windows.Forms.Button button_Ara;
    }
}