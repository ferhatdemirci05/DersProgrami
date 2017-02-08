namespace AhiEvranDersProgrami
{
    partial class Ogretim_elemani_ekle
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_kadi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_adi = new System.Windows.Forms.TextBox();
            this.textBox_soyadi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_unavni = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_dt = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_stel = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox_ctel = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_mail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_kaydet = new System.Windows.Forms.Button();
            this.button_yeni = new System.Windows.Forms.Button();
            this.button_iptal = new System.Windows.Forms.Button();
            this.label_Oe_Bilgiler = new System.Windows.Forms.Label();
            this.textBox_OE_Ara = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_maas = new System.Windows.Forms.TextBox();
            this.button_Ara = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(40, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Öğretim Elemanı Kısa Adı ";
            // 
            // textBox_kadi
            // 
            this.textBox_kadi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_kadi.Location = new System.Drawing.Point(278, 24);
            this.textBox_kadi.Name = "textBox_kadi";
            this.textBox_kadi.Size = new System.Drawing.Size(189, 26);
            this.textBox_kadi.TabIndex = 0;
            this.textBox_kadi.Tag = "";
            this.textBox_kadi.Enter += new System.EventHandler(this.textBox_maas_Enter);
            this.textBox_kadi.Leave += new System.EventHandler(this.textBox_maas_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(40, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Öğretim Elemanı Adı";
            // 
            // textBox_adi
            // 
            this.textBox_adi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_adi.Location = new System.Drawing.Point(278, 61);
            this.textBox_adi.Name = "textBox_adi";
            this.textBox_adi.Size = new System.Drawing.Size(189, 26);
            this.textBox_adi.TabIndex = 1;
            this.textBox_adi.Enter += new System.EventHandler(this.textBox_maas_Enter);
            this.textBox_adi.Leave += new System.EventHandler(this.textBox_maas_Leave);
            // 
            // textBox_soyadi
            // 
            this.textBox_soyadi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_soyadi.Location = new System.Drawing.Point(278, 98);
            this.textBox_soyadi.Name = "textBox_soyadi";
            this.textBox_soyadi.Size = new System.Drawing.Size(189, 26);
            this.textBox_soyadi.TabIndex = 2;
            this.textBox_soyadi.Enter += new System.EventHandler(this.textBox_maas_Enter);
            this.textBox_soyadi.Leave += new System.EventHandler(this.textBox_maas_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(40, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Öğretim Elemanı Soyadı";
            // 
            // comboBox_unavni
            // 
            this.comboBox_unavni.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_unavni.FormattingEnabled = true;
            this.comboBox_unavni.Location = new System.Drawing.Point(278, 135);
            this.comboBox_unavni.Name = "comboBox_unavni";
            this.comboBox_unavni.Size = new System.Drawing.Size(189, 27);
            this.comboBox_unavni.TabIndex = 3;
            this.comboBox_unavni.Enter += new System.EventHandler(this.comboBox_unavni_Enter);
            this.comboBox_unavni.Leave += new System.EventHandler(this.comboBox_unavni_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(40, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Öğretim Elemanı Ünvanı";
            // 
            // dateTimePicker_dt
            // 
            this.dateTimePicker_dt.Checked = false;
            this.dateTimePicker_dt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker_dt.Location = new System.Drawing.Point(278, 173);
            this.dateTimePicker_dt.Name = "dateTimePicker_dt";
            this.dateTimePicker_dt.Size = new System.Drawing.Size(189, 26);
            this.dateTimePicker_dt.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(40, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Öğretim Elemanı Doğum Tarihi";
            // 
            // maskedTextBox_stel
            // 
            this.maskedTextBox_stel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedTextBox_stel.Location = new System.Drawing.Point(278, 210);
            this.maskedTextBox_stel.Mask = "0(000)-999-0000";
            this.maskedTextBox_stel.Name = "maskedTextBox_stel";
            this.maskedTextBox_stel.Size = new System.Drawing.Size(189, 26);
            this.maskedTextBox_stel.TabIndex = 5;
            this.maskedTextBox_stel.Enter += new System.EventHandler(this.maskedTextBox_ctel_Enter);
            this.maskedTextBox_stel.Leave += new System.EventHandler(this.maskedTextBox_ctel_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(40, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Öğretim Elemanı Sabit Telefon";
            // 
            // maskedTextBox_ctel
            // 
            this.maskedTextBox_ctel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedTextBox_ctel.Location = new System.Drawing.Point(278, 247);
            this.maskedTextBox_ctel.Mask = "0(000)-999-0000";
            this.maskedTextBox_ctel.Name = "maskedTextBox_ctel";
            this.maskedTextBox_ctel.Size = new System.Drawing.Size(189, 26);
            this.maskedTextBox_ctel.TabIndex = 6;
            this.maskedTextBox_ctel.Enter += new System.EventHandler(this.maskedTextBox_ctel_Enter);
            this.maskedTextBox_ctel.Leave += new System.EventHandler(this.maskedTextBox_ctel_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(40, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Öğretim Elemanı Cep Telefonu";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBox_mail
            // 
            this.textBox_mail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_mail.Location = new System.Drawing.Point(278, 284);
            this.textBox_mail.Name = "textBox_mail";
            this.textBox_mail.Size = new System.Drawing.Size(189, 26);
            this.textBox_mail.TabIndex = 7;
            this.textBox_mail.Enter += new System.EventHandler(this.textBox_maas_Enter);
            this.textBox_mail.Leave += new System.EventHandler(this.textBox_maas_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(40, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Öğretim Elemanı Mail Adresi";
            this.label8.Click += new System.EventHandler(this.label7_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(40, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(226, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Öğretim Elemanı Maaş Karşılığı";
            this.label9.Click += new System.EventHandler(this.label7_Click);
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
            this.button_kaydet.Location = new System.Drawing.Point(216, 381);
            this.button_kaydet.Name = "button_kaydet";
            this.button_kaydet.Size = new System.Drawing.Size(50, 50);
            this.button_kaydet.TabIndex = 9;
            this.button_kaydet.UseVisualStyleBackColor = false;
            this.button_kaydet.Click += new System.EventHandler(this.button1_Click);
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
            this.button_yeni.Location = new System.Drawing.Point(149, 381);
            this.button_yeni.Name = "button_yeni";
            this.button_yeni.Size = new System.Drawing.Size(50, 50);
            this.button_yeni.TabIndex = 10;
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
            this.button_iptal.Location = new System.Drawing.Point(278, 381);
            this.button_iptal.Name = "button_iptal";
            this.button_iptal.Size = new System.Drawing.Size(50, 50);
            this.button_iptal.TabIndex = 11;
            this.button_iptal.UseVisualStyleBackColor = false;
            this.button_iptal.Click += new System.EventHandler(this.button_iptal_Click);
            // 
            // label_Oe_Bilgiler
            // 
            this.label_Oe_Bilgiler.AutoSize = true;
            this.label_Oe_Bilgiler.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Oe_Bilgiler.Location = new System.Drawing.Point(506, 73);
            this.label_Oe_Bilgiler.Name = "label_Oe_Bilgiler";
            this.label_Oe_Bilgiler.Size = new System.Drawing.Size(0, 19);
            this.label_Oe_Bilgiler.TabIndex = 0;
            // 
            // textBox_OE_Ara
            // 
            this.textBox_OE_Ara.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_OE_Ara.Location = new System.Drawing.Point(505, 24);
            this.textBox_OE_Ara.Name = "textBox_OE_Ara";
            this.textBox_OE_Ara.Size = new System.Drawing.Size(338, 26);
            this.textBox_OE_Ara.TabIndex = 12;
            this.textBox_OE_Ara.TextChanged += new System.EventHandler(this.textBox_OE_Ara_TextChanged);
            this.textBox_OE_Ara.Enter += new System.EventHandler(this.textBox_maas_Enter);
            this.textBox_OE_Ara.Leave += new System.EventHandler(this.textBox_maas_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(510, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(584, 327);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // textBox_maas
            // 
            this.textBox_maas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_maas.Location = new System.Drawing.Point(278, 321);
            this.textBox_maas.Name = "textBox_maas";
            this.textBox_maas.Size = new System.Drawing.Size(189, 26);
            this.textBox_maas.TabIndex = 38;
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
            this.button_Ara.Location = new System.Drawing.Point(843, 25);
            this.button_Ara.Name = "button_Ara";
            this.button_Ara.Size = new System.Drawing.Size(26, 25);
            this.button_Ara.TabIndex = 13;
            this.button_Ara.TabStop = false;
            this.button_Ara.UseVisualStyleBackColor = false;
            this.button_Ara.Click += new System.EventHandler(this.button3_Click);
            // 
            // Ogretim_elemani_ekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1108, 477);
            this.Controls.Add(this.button_Ara);
            this.Controls.Add(this.textBox_OE_Ara);
            this.Controls.Add(this.textBox_kadi);
            this.Controls.Add(this.textBox_adi);
            this.Controls.Add(this.textBox_soyadi);
            this.Controls.Add(this.comboBox_unavni);
            this.Controls.Add(this.dateTimePicker_dt);
            this.Controls.Add(this.maskedTextBox_stel);
            this.Controls.Add(this.maskedTextBox_ctel);
            this.Controls.Add(this.textBox_mail);
            this.Controls.Add(this.textBox_maas);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_yeni);
            this.Controls.Add(this.button_iptal);
            this.Controls.Add(this.button_kaydet);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_Oe_Bilgiler);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Ogretim_elemani_ekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğretim Elemanı        ";
            this.Load += new System.EventHandler(this.Ogretim_elemani_ekle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ogretim_elemani_ekle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_kadi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_adi;
        private System.Windows.Forms.TextBox textBox_soyadi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_unavni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_stel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ctel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_mail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_kaydet;
        private System.Windows.Forms.Button button_yeni;
        private System.Windows.Forms.Button button_iptal;
        private System.Windows.Forms.Label label_Oe_Bilgiler;
        private System.Windows.Forms.TextBox textBox_OE_Ara;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_maas;
        private System.Windows.Forms.Button button_Ara;
    }
}