namespace AhiEvranDersProgrami
{
    partial class DersEkle
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
            this.textBox_kodu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_adi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_t = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_u = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_k = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_akts = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_Ara = new System.Windows.Forms.Button();
            this.textBox_Ders_Ara = new System.Windows.Forms.TextBox();
            this.dataGridView_Ders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ders)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_kodu
            // 
            this.textBox_kodu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_kodu.Location = new System.Drawing.Point(162, 30);
            this.textBox_kodu.Name = "textBox_kodu";
            this.textBox_kodu.Size = new System.Drawing.Size(174, 26);
            this.textBox_kodu.TabIndex = 0;
            this.textBox_kodu.Enter += new System.EventHandler(this.textBox_akts_Enter);
            this.textBox_kodu.Leave += new System.EventHandler(this.textBox_akts_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ders Kodu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(37, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ders Adı";
            // 
            // textBox_adi
            // 
            this.textBox_adi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_adi.Location = new System.Drawing.Point(162, 67);
            this.textBox_adi.Name = "textBox_adi";
            this.textBox_adi.Size = new System.Drawing.Size(174, 26);
            this.textBox_adi.TabIndex = 1;
            this.textBox_adi.Enter += new System.EventHandler(this.textBox_adi_Enter);
            this.textBox_adi.Leave += new System.EventHandler(this.textBox_adi_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(37, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Teori Saati";
            // 
            // textBox_t
            // 
            this.textBox_t.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_t.Location = new System.Drawing.Point(162, 104);
            this.textBox_t.Name = "textBox_t";
            this.textBox_t.Size = new System.Drawing.Size(174, 26);
            this.textBox_t.TabIndex = 2;
            this.textBox_t.Enter += new System.EventHandler(this.textBox_akts_Enter);
            this.textBox_t.Leave += new System.EventHandler(this.textBox_akts_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(37, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Uygulama Saati";
            // 
            // textBox_u
            // 
            this.textBox_u.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_u.Location = new System.Drawing.Point(162, 141);
            this.textBox_u.Name = "textBox_u";
            this.textBox_u.Size = new System.Drawing.Size(174, 26);
            this.textBox_u.TabIndex = 3;
            this.textBox_u.Enter += new System.EventHandler(this.textBox_akts_Enter);
            this.textBox_u.Leave += new System.EventHandler(this.textBox_akts_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(37, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ders Kredisi";
            // 
            // textBox_k
            // 
            this.textBox_k.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_k.Location = new System.Drawing.Point(162, 178);
            this.textBox_k.Name = "textBox_k";
            this.textBox_k.Size = new System.Drawing.Size(174, 26);
            this.textBox_k.TabIndex = 4;
            this.textBox_k.Enter += new System.EventHandler(this.textBox_akts_Enter);
            this.textBox_k.Leave += new System.EventHandler(this.textBox_akts_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(37, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "AKTS";
            // 
            // textBox_akts
            // 
            this.textBox_akts.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_akts.Location = new System.Drawing.Point(162, 215);
            this.textBox_akts.Name = "textBox_akts";
            this.textBox_akts.Size = new System.Drawing.Size(174, 26);
            this.textBox_akts.TabIndex = 5;
            this.textBox_akts.Enter += new System.EventHandler(this.textBox_akts_Enter);
            this.textBox_akts.Leave += new System.EventHandler(this.textBox_akts_Leave);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.BackgroundImage = global::AhiEvranDersProgrami.Properties.Resources.cancel;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button12.ForeColor = System.Drawing.Color.Transparent;
            this.button12.Location = new System.Drawing.Point(218, 274);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(50, 50);
            this.button12.TabIndex = 8;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::AhiEvranDersProgrami.Properties.Resources.save;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(153, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::AhiEvranDersProgrami.Properties.Resources.clear_master_for_android_Qtcrk4Y;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(86, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.button_Ara.Location = new System.Drawing.Point(711, 28);
            this.button_Ara.Name = "button_Ara";
            this.button_Ara.Size = new System.Drawing.Size(26, 25);
            this.button_Ara.TabIndex = 39;
            this.button_Ara.TabStop = false;
            this.button_Ara.UseVisualStyleBackColor = false;
            this.button_Ara.Click += new System.EventHandler(this.button_Ara_Click);
            // 
            // textBox_Ders_Ara
            // 
            this.textBox_Ders_Ara.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_Ders_Ara.Location = new System.Drawing.Point(373, 27);
            this.textBox_Ders_Ara.Name = "textBox_Ders_Ara";
            this.textBox_Ders_Ara.Size = new System.Drawing.Size(338, 26);
            this.textBox_Ders_Ara.TabIndex = 38;
            this.textBox_Ders_Ara.TextChanged += new System.EventHandler(this.textBox_Ders_Ara_TextChanged);
            // 
            // dataGridView_Ders
            // 
            this.dataGridView_Ders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Ders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Ders.Location = new System.Drawing.Point(373, 79);
            this.dataGridView_Ders.Name = "dataGridView_Ders";
            this.dataGridView_Ders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Ders.Size = new System.Drawing.Size(410, 245);
            this.dataGridView_Ders.TabIndex = 40;
            this.dataGridView_Ders.TabStop = false;
            // 
            // DersEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(806, 345);
            this.Controls.Add(this.button_Ara);
            this.Controls.Add(this.textBox_Ders_Ara);
            this.Controls.Add(this.dataGridView_Ders);
            this.Controls.Add(this.textBox_kodu);
            this.Controls.Add(this.textBox_adi);
            this.Controls.Add(this.textBox_t);
            this.Controls.Add(this.textBox_u);
            this.Controls.Add(this.textBox_k);
            this.Controls.Add(this.textBox_akts);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "DersEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DersEkle";
            this.Load += new System.EventHandler(this.DersEkle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DersEkle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_kodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_adi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_t;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_u;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_k;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_akts;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_Ara;
        private System.Windows.Forms.TextBox textBox_Ders_Ara;
        private System.Windows.Forms.DataGridView dataGridView_Ders;
    }
}