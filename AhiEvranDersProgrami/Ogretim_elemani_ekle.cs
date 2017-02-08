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
    public partial class Ogretim_elemani_ekle : Form
    {
        public Ogretim_elemani_ekle()
        {
            InitializeComponent();
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OgretimElemani OE = new OgretimElemani();
            OE.Adi = textBox_OE_Ara.Text;
            OgretimElemaniVeritabani OEVT = new OgretimElemaniVeritabani();
            dataGridView1.DataSource = OEVT.Listele(OE);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgretimElemani oe = new OgretimElemani();
            OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
            oe.Adi = textBox_adi.Text;
            oe.CTel = maskedTextBox_ctel.Text;
            oe.DTarihi = DateTime.Parse(dateTimePicker_dt.Text);
            oe.Kadi = textBox_kadi.Text;
            oe.Maasi = int.Parse(textBox_maas.Text);
            oe.Mail = textBox_mail.Text;
            oe.Soyadi = textBox_soyadi.Text;
            oe.STel = maskedTextBox_stel.Text;
            Unvan u = new Unvan();
            UnvanVeritabani uvt = new UnvanVeritabani();
            u.Adi = comboBox_unavni.Text;
            if (uvt.unvankontrol(u))
            {
                oe.Unvani.Kodu = Convert.ToInt16(comboBox_unavni.SelectedValue);
                try
                {
                    DialogResult d = MessageBox.Show("Kaydı gerçekleştirmek istermisiniz", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        oevt.Ekle(oe);
                        MessageBox.Show("Kayıt işlemi başarılı bir şekilde gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK);
                        Temizle();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ünvan seçiniz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }

        }

        private void button_yeni_Click(object sender, EventArgs e)
        {
            Temizle();
         
        }

        private void Temizle()
        {
            textBox_kadi.Text = textBox_maas.Text = textBox_mail.Text = textBox_adi.Text = textBox_soyadi.Text = "";
            maskedTextBox_ctel.Text = maskedTextBox_stel.Text = "";
            comboBox_unavni.SelectedValue = 1;
            dateTimePicker_dt.Value = DateTime.Now;
        }

        private void Ogretim_elemani_ekle_Load(object sender, EventArgs e)
        {
            OgretimElemaniListele();
            UnvanVeritabani uvt = new UnvanVeritabani();
            comboBox_unavni.DataSource = uvt.Listele();
            comboBox_unavni.DisplayMember = "U_Adi";
            comboBox_unavni.ValueMember = "U_Kodu";
        }

        private void OgretimElemaniListele()
        {
            OgretimElemaniVeritabani oevt=new OgretimElemaniVeritabani();
            dataGridView1.DataSource = oevt.Listele();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ad Soyad";
            dataGridView1.Columns[2].HeaderText = "Mail Adres";
            dataGridView1.Columns[3].HeaderText = "Cep Telefon";
            dataGridView1.Columns[4].HeaderText = "Sabit Telefon";
            dataGridView1.Columns[5].HeaderText = "Doğum Tarihi";

        }

        private void textBox_maas_Enter(object sender, EventArgs e)
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

        private void maskedTextBox_ctel_Enter(object sender, EventArgs e)
        {
            MaskedTextBox tb = (MaskedTextBox)sender;
            tb.BackColor = Color.Coral;
            tb.ForeColor = Color.White;
        }

        private void maskedTextBox_ctel_Leave(object sender, EventArgs e)
        {
            MaskedTextBox tb = (MaskedTextBox)sender;
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
        }

        private void comboBox_unavni_Leave(object sender, EventArgs e)
        {
            ComboBox tb = (ComboBox)sender;
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
        }

        private void comboBox_unavni_Enter(object sender, EventArgs e)
        {
            ComboBox tb = (ComboBox )sender;
            tb.BackColor = Color.Coral;
            tb.ForeColor = Color.White;
        }

        private void Ogretim_elemani_ekle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();   
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label_Oe_Bilgiler.Text = "Ad Soyad: " + dataGridView1.SelectedRows[0].Cells[1].Value + "   |    Mail Adres: " + dataGridView1.SelectedRows[0].Cells[2].Value+"\nCep Telefon: "+dataGridView1.SelectedRows[0].Cells[3].Value+"    |    Sabit Telefon: "+dataGridView1.SelectedRows[0].Cells[4].Value+"\nDoğum Tarihi: "+dataGridView1.SelectedRows[0].Cells[5].Value;

        }

        private void textBox_OE_Ara_TextChanged(object sender, EventArgs e)
        {
            OgretimElemani OE = new OgretimElemani();
            OE.Adi = textBox_OE_Ara.Text;
            OgretimElemaniVeritabani OEVT = new OgretimElemaniVeritabani();
            dataGridView1.DataSource = OEVT.Listele(OE);
        }

        private void button_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    