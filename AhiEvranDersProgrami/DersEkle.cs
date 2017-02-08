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
    public partial class DersEkle : Form
    {
        public DersEkle()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void Temizle()
        {
            textBox_adi.Text = textBox_k.Text = textBox_kodu.Text = textBox_t.Text = textBox_u.Text = textBox_akts.Text="";
        }

        private void textBox_akts_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.Coral;
            tb.ForeColor = Color.White;
        }

        private void textBox_akts_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
            string deger = tb.Text;
            bool sart=false;
           
         for ( int i = 0; i < deger.Length; i++)
            {
                    if (deger[i].ToString()=="0" ||deger[i].ToString()=="1" || deger[i].ToString()=="2" || deger[i].ToString()=="3" || deger[i].ToString()=="4" || deger[i].ToString()=="5" || deger[i].ToString()=="6" || deger[i].ToString()=="7" || deger[i].ToString()=="8" || deger[i].ToString()=="9" || deger[i].ToString()=="0")
                    {
                        sart = true;
                    }
                    else
                    {
                        sart = false;
                        break;
                    }
            }
         if (tb.Text=="")
         {
             sart = true;
         }
            if (!sart)
            {
                MessageBox.Show("Lütfen sayısal değer girişi yapınız.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                tb.Text = "";
                tb.Focus();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_adi.Text !="" && textBox_akts.Text!=""&&textBox_k.Text!=""&&textBox_kodu.Text!=""&&textBox_t.Text!=""&&textBox_u.Text!="")
            {
                Ders d = new Ders();
                DersVeritabani dvt = new DersVeritabani();
                d.Kodu=Convert.ToInt32(textBox_kodu.Text);
                if (!dvt.kontrolet(d))
                {
                    d.Adi = textBox_adi.Text;
                    d.Akts = Convert.ToInt32(textBox_akts.Text);
                    d.Kredi = Convert.ToInt32(textBox_k.Text);
                    d.Teori = Convert.ToInt32(textBox_t.Text);
                    d.Uygulama = Convert.ToInt32(textBox_u.Text);
                    dvt.Ekle(d);
                    MessageBox.Show(d.Kodu+" - "+d.Adi+" | dersi başarılı bir şekilde eklendi","Bilgi",MessageBoxButtons.OK);
                    Temizle();
                    textBox_kodu.Focus();
                }
                else
                {
                    MessageBox.Show("Ders kodu bulunmaktadır. Kayıt yapılamadı","Hata",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız...","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            DersListele();
        }

        private void textBox_adi_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.Coral;
            tb.ForeColor = Color.White;
        }

        private void textBox_adi_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
        }

        private void DersEkle_Load(object sender, EventArgs e)
        {
            DersListele();
        }

        private void DersListele()
        {
            DersVeritabani DVT = new DersVeritabani();
            dataGridView_Ders.DataSource = DVT.Listele();
            dataGridView_Ders.Columns[0].Visible = false;
            dataGridView_Ders.Columns[1].HeaderText = "Ders Adı";
            dataGridView_Ders.Columns[1].Width = 230;
            dataGridView_Ders.Columns[2].HeaderText = "T";
            dataGridView_Ders.Columns[3].HeaderText = "U";
            dataGridView_Ders.Columns[4].HeaderText = "K";
            dataGridView_Ders.Columns[5].HeaderText = "AKTS";
            dataGridView_Ders.Columns[2].Width = dataGridView_Ders.Columns[3].Width = dataGridView_Ders.Columns[4].Width = 15;
            dataGridView_Ders.Columns[5].Width = 45;

        }

        private void DersEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void textBox_Ders_Ara_TextChanged(object sender, EventArgs e)
        {
            DersListele(textBox_Ders_Ara.Text);
        }

        private void DersListele(string DersAdi)
        {
            Ders D = new Ders();
            D.Adi = DersAdi;
            DersVeritabani DVT = new DersVeritabani();
            dataGridView_Ders.DataSource = DVT.Listele(D);
        }

        private void button_Ara_Click(object sender, EventArgs e)
        {
            DersListele(textBox_Ders_Ara.Text);
        }
    }
}
