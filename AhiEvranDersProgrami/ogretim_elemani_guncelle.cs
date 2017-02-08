using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AhiEvranDersProgrami
{
    public partial class ogretim_elemani_guncelle : Form
    {
        public ogretim_elemani_guncelle()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ywni_Click(object sender, EventArgs e)
        {
            textBox_kadi.Text = textBox_maas.Text=textBox_mail.Text=textBox_oeadi.Text=textBox_soyadi.Text= "";
            maskedTextBox_ct.Text = maskedTextBox_stel.Text = "";
            comboBox_unvani.SelectedValue = comboBox_oe.SelectedValue= 1;
            dateTimePicker_dt.Value = DateTime.Now;
            textBox_kadi.Enabled = textBox_maas.Enabled = textBox_mail.Enabled = textBox_oeadi.Enabled = textBox_soyadi.Enabled = comboBox_unvani.Enabled = maskedTextBox_ct.Enabled = maskedTextBox_stel.Enabled = dateTimePicker_dt.Enabled = false;
        }

        private void ogretim_elemani_guncelle_Load(object sender, EventArgs e)
        {
            comboBox_oe.Text="Öğretim Elemanı Seçiniz";
        }

        private void OgretimelemaniListele()
        {
            OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
            comboBox_oe.DataSource = oevt.Listele();
            comboBox_oe.DisplayMember = "OE";
            comboBox_oe.ValueMember = "kodu";
            UnvanVeritabani uvt = new UnvanVeritabani();
            comboBox_unvani.DataSource = uvt.Listele();
            comboBox_unvani.DisplayMember = "U_Adi";
            comboBox_unvani.ValueMember = "U_Kodu";
        }
        private void comboBox_oe_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox_oe_MouseClick(object sender, MouseEventArgs e)
        {
            OgretimelemaniListele();
        }

        private void comboBox_oe_Leave(object sender, EventArgs e)
        {

            if (comboBox_oe.Text != "Öğretim Elemanı Seçiniz")
            {
                string[] deger;
                OgretimElemani oe2 = new OgretimElemani();
                OgretimElemaniVeritabani oevt2 = new OgretimElemaniVeritabani();
                deger = comboBox_oe.Text.Split(' ');
                for (int i = 1; i < deger.Length; i++)
                {
                    oe2.Adi += deger[i];
                    if (deger.Length-1!=i)
                    {
                        oe2.Adi +=" ";
                    }
                }
                oe2.Unvani.Adi = deger[0];
                try
                {
                    if (oevt2.kontrolet(oe2))
                    {
                        comboBox_unvani.Enabled = textBox_kadi.Enabled = textBox_maas.Enabled = textBox_mail.Enabled = textBox_oeadi.Enabled = textBox_soyadi.Enabled = maskedTextBox_ct.Enabled = maskedTextBox_stel.Enabled = dateTimePicker_dt.Enabled = true;
                        OgretimElemani oe = new OgretimElemani();
                        oe.Kodu = Convert.ToInt32(comboBox_oe.SelectedValue);
                        OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
                        oe = oevt.Bİlgigetir(oe);
                        textBox_kadi.Text = oe.Kadi;
                        textBox_maas.Text = oe.Maasi.ToString();
                        textBox_mail.Text = oe.Mail;
                        textBox_oeadi.Text = oe.Adi;
                        textBox_soyadi.Text = oe.Soyadi;
                        maskedTextBox_ct.Text = oe.CTel;
                        maskedTextBox_stel.Text = oe.STel;
                        comboBox_unvani.SelectedValue = oe.Unvani.Kodu;
                        dateTimePicker_dt.Value = oe.DTarihi;
                    }
                    else
                    {
                        comboBox_oe.Text = "Öğretim Elemanı Seçiniz";
                        MessageBox.Show("Seçtiğiniz değeri bulamadık...","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        comboBox_unvani.SelectedValue = 1;
                        textBox_kadi.Text = textBox_maas.Text = textBox_mail.Text = textBox_oeadi.Text = textBox_soyadi.Text = maskedTextBox_ct.Text = maskedTextBox_stel.Text = "";
                        comboBox_unvani.Enabled = textBox_kadi.Enabled = textBox_maas.Enabled = textBox_mail.Enabled = textBox_oeadi.Enabled = textBox_soyadi.Enabled = maskedTextBox_ct.Enabled = maskedTextBox_stel.Enabled = dateTimePicker_dt.Enabled = false;
                        
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
               
            }
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {

            OgretimElemani oe = new OgretimElemani();
            OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
            oe.Adi =textBox_oeadi.Text;
            oe.CTel = maskedTextBox_ct.Text;
            oe.DTarihi = Convert.ToDateTime(dateTimePicker_dt.Text);
            oe.Kadi = textBox_kadi.Text;
            oe.Kodu=Convert.ToInt32(comboBox_oe.SelectedValue);
            oe.Maasi = Convert.ToInt32(textBox_maas.Text);
            oe.Mail = textBox_mail.Text;
            oe.Soyadi = textBox_soyadi.Text;
            oe.STel = maskedTextBox_stel.Text;
            Unvan u = new Unvan();
            UnvanVeritabani uvt = new UnvanVeritabani();
            u.Adi = comboBox_unvani.Text;
            if (uvt.unvankontrol(u))
            {
                oe.Unvani.Kodu = Convert.ToInt32(comboBox_unvani.SelectedValue);
                try
                {
                    DialogResult d = MessageBox.Show(comboBox_oe.SelectedText + "\nÖğretim elemanı'nı Güncellemek İstiyormusunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        oevt.Guncelle(oe);
                        MessageBox.Show(comboBox_oe.SelectedText + "\nBaşarılı bir şekilde güncellendi", "Bilgi", MessageBoxButtons.OK);

                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ünvan seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void textBox_soyadi_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.Coral;
            tb.ForeColor = Color.White;
        }

        private void textBox_maas_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
        }

        private void maskedTextBox_stel_Enter(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            mtb.BackColor = Color.Coral;
            mtb.ForeColor = Color.White;
        }

        private void maskedTextBox_ct_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            mtb.BackColor = Color.White;
            mtb.ForeColor = Color.Black;
        }

        private void ogretim_elemani_guncelle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
