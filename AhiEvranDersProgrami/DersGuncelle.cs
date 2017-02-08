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
    public partial class DersGuncelle : Form
    {
        public DersGuncelle()
        {
            InitializeComponent();
        }

        private void DersGuncelle_Load(object sender, EventArgs e)
        {
            comboBox_d.Text = "Lütfen Ders Seçiniz";
        }

        private void button_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button_temizle_Click(object sender, EventArgs e)
        {
            comboBox_d.Items.Clear();
            comboBox_d.Text = "Lütfen Ders Seçiniz";
            textBox_u.Text = textBox_t.Text = textBox_adi.Text = textBox_akts.Text = textBox_k.Text = textBox_kodu.Text = "";
            textBox_adi.Enabled = textBox_akts.Enabled = textBox_k.Enabled = textBox_kodu.Enabled = textBox_t.Enabled = textBox_u.Enabled = false;
        }

        private void comboBox_d_MouseClick(object sender, MouseEventArgs e)
        {
            DersVeritabani dvt=new DersVeritabani();
            comboBox_d.DataSource = dvt.Listele();
            comboBox_d.DisplayMember = "Ders";
            comboBox_d.ValueMember = "ID";
        }

        private void comboBox_d_Leave(object sender, EventArgs e)
        {
            if (comboBox_d.Text != "Lütfen Ders Seçiniz")
            {
                string[] deger;
                Ders d = new Ders();
                DersVeritabani dvt = new DersVeritabani();
                deger = comboBox_d.Text.Split(' ');
                for (int i = 1; i < deger.Length; i++)
                {
                    d.Adi += deger[i];
                    if (deger.Length - 1 != 1)
                    {
                        d.Adi += " ";
                    }
                }
                bool sart = false;
                for (int i = 0; i < deger[0].Length; i++)
                {
                    if (deger[0][i].ToString() == "0" || deger[0][i].ToString() == "1" || deger[0][i].ToString() == "2" || deger[0][i].ToString() == "3" || deger[0][i].ToString() == "4" || deger[0][i].ToString() == "5" || deger[0][i].ToString() == "6" || deger[0][i].ToString() == "7" || deger[0][i].ToString() == "8" || deger[0][i].ToString() == "9" || deger[0][i].ToString() == "0")
                    {
                        sart = true;
                    }
                    else
                    {
                        sart = false;
                        break;
                    }
                }
                if (deger[0] == "")
                {
                    sart = true;
                }
                if (!sart)
                {
                    MessageBox.Show("Yanlış giriş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_d.Text = "Lütfen Ders Seçiniz";
                    textBox_adi.Text = textBox_k.Text = textBox_akts.Text = textBox_kodu.Text = textBox_t.Text = textBox_u.Text = "";
                    textBox_adi.Enabled = textBox_akts.Enabled = textBox_k.Enabled = textBox_kodu.Enabled = textBox_t.Enabled = textBox_u.Enabled = false;
                }
                else
                {
                    d.Kodu = Convert.ToInt32(deger[0]);
                }
                try
                {
                    if (dvt.kontrolet(d))
                    {
                        textBox_adi.Enabled = textBox_akts.Enabled = textBox_k.Enabled = textBox_t.Enabled = textBox_u.Enabled = true;
                        Ders d2 = new Ders();
                        d2.Kodu = Convert.ToInt32(comboBox_d.SelectedValue);
                        d2 = dvt.bilgigetir(d2);
                        textBox_adi.Text = d2.Adi;
                        textBox_akts.Text = d2.Akts.ToString();
                        textBox_k.Text = d2.Kredi.ToString();
                        textBox_kodu.Text = d2.Kodu.ToString();
                        textBox_t.Text = d2.Teori.ToString();
                        textBox_u.Text = d2.Uygulama.ToString();
                        textBox_adi.Focus();
                        ComboBox cb = (ComboBox)sender;
                        cb.ForeColor = Color.Black;
                        cb.BackColor = Color.White;
                    }
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            Ders d = new Ders();
            DersVeritabani dvt = new DersVeritabani();
            d.Adi = textBox_adi.Text;
            d.Akts =Convert.ToInt32(textBox_akts.Text);
            d.Kodu = Convert.ToInt32(textBox_kodu.Text);
            d.Kredi = Convert.ToInt32(textBox_k.Text);
            d.Teori = Convert.ToInt32(textBox_t.Text);
            d.Uygulama = Convert.ToInt32(textBox_u.Text);
          
            try
            {
                DialogResult dr = MessageBox.Show(d.Kodu+" Kodlu ders bilgileri güncellenecek oanylıyormusunuz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (dr==DialogResult.Yes)
                {
                    dvt.Guncelle(d);
                    MessageBox.Show("Güncelleme işlemi başarılı bir şekilde gerçekleştirildi.","Bilgi",MessageBoxButtons.OK);
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
        }

        private void DersGuncelle_Enter(object sender, EventArgs e)
        {
            Renkdegistir(sender);
        }

        private static void Renkdegistir(object sender)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.Coral;
            tb.ForeColor = Color.White;
        }

        private void textBox_adi_Enter(object sender, EventArgs e)
        {
            Renkdegistir(sender);
        }

        private void textBox_adi_Leave(object sender, EventArgs e)
        {
            Renkdegistir2(sender);
        }

        private void Renkdegistir2(object sender)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
        }

        private void textBox_kodu_Leave(object sender, EventArgs e)
        {
            Renkdegistir2(sender);
            TextBox tb = (TextBox)sender;
            string deger = tb.Text;
            bool sart = false;

            for (int i = 0; i < deger.Length; i++)
            {
                if (deger[i].ToString() == "0" || deger[i].ToString() == "1" || deger[i].ToString() == "2" || deger[i].ToString() == "3" || deger[i].ToString() == "4" || deger[i].ToString() == "5" || deger[i].ToString() == "6" || deger[i].ToString() == "7" || deger[i].ToString() == "8" || deger[i].ToString() == "9" || deger[i].ToString() == "0")
                {
                    sart = true;
                }
                else
                {
                    sart = false;
                    break;
                }
            }
            if (tb.Text == "")
            {
                sart = true;
            }
            if (!sart)
            {
                MessageBox.Show("Lütfen sayısal değer girişi yapınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                tb.Text = "";
                tb.Focus();
            }
        }

        private void comboBox_d_Enter(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.BackColor = Color.Coral;
            cb.ForeColor = Color.White;
        }

        private void DersGuncelle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
