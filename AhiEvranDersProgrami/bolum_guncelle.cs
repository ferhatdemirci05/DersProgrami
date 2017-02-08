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
    public partial class bolum_guncelle : Form
    {
        public bolum_guncelle()
        {
            InitializeComponent();
        }

        private void button_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bolum_guncelle_Load(object sender, EventArgs e)
        {
            comboBox_bolum.Text = "Lütfen Bölüm Seçiniz";
            OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
            comboBox_baskani.DataSource = oevt.Listele();
            comboBox_baskani.DisplayMember = "OE";
            comboBox_baskani.ValueMember = "kodu";
        }

        private void comboBox_bolum_MouseClick(object sender, MouseEventArgs e)
        {
            BolumVeritabani bvt = new BolumVeritabani();
            comboBox_bolum.DataSource = bvt.Listele();
            comboBox_bolum.DisplayMember = "B_KAdi";
            comboBox_bolum.ValueMember = "B_Kodu";
        }

        private void comboBox_bolum_Leave(object sender, EventArgs e)
        {
            if (comboBox_bolum.Text!="Lütfen Bölüm Seçiniz")
            {
                Bolum b = new Bolum();
                b.Kadi = comboBox_bolum.Text;
                BolumVeritabani bvt = new BolumVeritabani();
                if (bvt.bolumkontrolet(b))
                {
                    textBox_adi.Enabled = textBox_kadi.Enabled = true;
                    comboBox_baskani.Enabled = true;
                    b.Kodu = Convert.ToInt32(comboBox_bolum.SelectedValue);
                    b = bvt.bolumlistele(b);
                    textBox_adi.Text = b.Adi;
                    textBox_kadi.Text = b.Kadi;
                    comboBox_baskani.SelectedValue = b.Baskani;
                }
                else
                {
                    textBox_adi.Enabled = textBox_kadi.Enabled = false;
                    comboBox_baskani.Enabled = false;
                    MessageBox.Show("Aradığınız bölümü kayıtlarımızda bulamadık","Hata",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                    textBox_adi.Text = textBox_kadi.Text = "";
                }
                comboBox_bolum.BackColor=Color.White;
                comboBox_bolum.ForeColor=Color.Black;
            }
        }

        private void comboBox_bolum_Enter(object sender, EventArgs e)
        {
            comboBox_bolum.BackColor = Color.Coral;
            comboBox_bolum.ForeColor = Color.White;
        }

        private void textBox_kadi_Enter(object sender, EventArgs e)
        {
            TextBox tb=(TextBox)sender;
            tb.BackColor = Color.Coral;
            tb.ForeColor = Color.White;
        }
        private void textBox_adi_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
        }

        private void bolum_guncelle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            Bolum b = new Bolum();
            b.Kadi = comboBox_bolum.Text;
            b.Kodu = Convert.ToInt32(comboBox_bolum.SelectedValue);
            BolumVeritabani bvt = new BolumVeritabani();
            if (bvt.bolumkontrolet(b))
            {
                b.Adi = textBox_adi.Text;
                b.Kadi = textBox_kadi.Text;
                b.Baskani =Convert.ToInt32(comboBox_baskani.SelectedValue);
                try
                {
                    bvt.Guncelle(b);
                    MessageBox.Show("Güncelleme İşlemi Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.None);
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Aradığınız bölümü kayıtlarımızda bulamadık", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void button_yeni_Click(object sender, EventArgs e)
        {
            textBox_adi.Enabled = textBox_kadi.Enabled = comboBox_baskani.Enabled  = false;
            textBox_adi.Text = textBox_kadi.Text = "";
            comboBox_baskani.SelectedIndex = 0;
            comboBox_bolum.SelectedIndex = 0;
        }
    }
}
