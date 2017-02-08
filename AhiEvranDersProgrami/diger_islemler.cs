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
    public partial class diger_islemler : Form
    {
        Saat s = new Saat();
        SaatVeritabani svt = new SaatVeritabani();
        char islem;
        string AlanAdi,TabloAdi;
        public diger_islemler()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_derslik.Text!="")
            {
                Derslik d = new Derslik();
                DerslikVeritabani dvt = new DerslikVeritabani();
                d.Adi = textBox_derslik.Text;

                try
                {
                    dvt.Ekle(d);
                    MessageBox.Show(d.Adi + " Başarılı bir şekilde kayıt edilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
                    textBox_derslik.Text = "";
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                } 
            }
            else
            {
                MessageBox.Show("Boş Değer Girdiniz","Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox_derslik.BackColor = Color.Red;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_donem.Text!="")
            {
                Donemi d = new Donemi();
                DonemiVeritabani dvt = new DonemiVeritabani();
                d.Adi = textBox_donem.Text;

                try
                {
                    dvt.Ekle(d);
                    MessageBox.Show(d.Adi + " Başarılı bir şekilde kayıt edilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
                    textBox_donem.Text = "";
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                } 
            }
            else
            {
                MessageBox.Show("Boş Değer Girdiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_donem.BackColor = Color.Red;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox_sinif.Text!="")
            {
                Sinif s = new Sinif();
                SinifVeritabani svt = new SinifVeritabani();
                s.Adi = textBox_sinif.Text;
                try
                {
                    svt.Ekle(s);
                    MessageBox.Show(s.Adi + " Başarılı bir şekilde kayıt edilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
                    textBox_sinif.Text = "";
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                } 
            }
            else
            {
                MessageBox.Show("Boş Değer Girdiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_sinif.BackColor = Color.Red;
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox_sube.Text!="")
            {
                Sube s = new Sube();
                SubeVeritabanni svt = new SubeVeritabanni();
                s.Adi = textBox_sube.Text;
                try
                {
                    svt.Ekle(s);
                    MessageBox.Show(s.Adi + " Başarılı bir şekilde kayıt edilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
                    textBox_sube.Text = "";
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                } 
            }
            else
            {
                MessageBox.Show("Boş Değer Girdiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_sube.BackColor = Color.Red;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox_gun.Text!="")
            {
                Gun g = new Gun();
                GunVeritabani gvt = new GunVeritabani();
                g.Adi = textBox_gun.Text;
                try
                {
                    gvt.Ekle(g);
                    MessageBox.Show(g.Adi + " Başarılı bir şekilde kayıt edilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
                    textBox_gun.Text = "";
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                
            }
            else
            {
                MessageBox.Show("Boş Değer Girdiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_gun.BackColor = Color.Red;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox_saat.Text!="")
            {
                s.Araligi = textBox_saat.Text;
                try
                {
                    svt.Ekle(s);
                    MessageBox.Show(s.Araligi + " Başarılı bir şekilde kayıt edilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
                    textBox_saat.Text = "";
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                } 

            }
            else
            {
                MessageBox.Show("Boş Değer Girdiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_saat.BackColor = Color.Red;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox_derslik.Text = "";
            textBox_derslik.BackColor = Color.White;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox_donem.Text = "";
            textBox_donem.BackColor = Color.White;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox_sinif.Text = "";
            textBox_sinif.BackColor = Color.White;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox_sube.Text = "";
            textBox_sube.BackColor = Color.White;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox_gun.Text = "";
            textBox_gun.BackColor = Color.White;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox_saat.Text = "";
            textBox_saat.BackColor = Color.White;
        }

        private void textBox_donem_Enter(object sender, EventArgs e)
        {
            textBox_Enter(sender);
            DonemiVeritabani DVT=new DonemiVeritabani();
            dataGridView_Liste.DataSource = DVT.Listele();
            dataGridView_Liste.Columns[0].HeaderText = "Dönem Adı";
            dataGridView_Liste.Columns[0].Width = 250;
            dataGridView_Liste.Columns[1].Visible = false;
        }

        private static void textBox_Enter(object sender)
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.Coral;
            t.ForeColor = Color.White;
        }

        private void textBox_saat_Leave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.White;
            t.ForeColor = Color.Black;
        }

        private void diger_islemler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void diger_islemler_Load(object sender, EventArgs e)
        {
            radio_NO.Checked=true;
        }

        private void textBox_derslik_Enter(object sender, EventArgs e)
        {
            textBox_Enter(sender);
            DerslikVeritabani DVT = new DerslikVeritabani();
            dataGridView_Liste.DataSource = DVT.Listele();
            dataGridView_Liste.Columns[0].HeaderText = "Derslikler";
            dataGridView_Liste.Columns[0].Width = 250;
            dataGridView_Liste.Columns[1].Visible = false;

        }
        private void textBox_sinif_Enter(object sender, EventArgs e)
        {
            textBox_Enter(sender);
            SinifVeritabani SVT = new SinifVeritabani();
            dataGridView_Liste.DataSource = SVT.Listele();
            dataGridView_Liste.Columns[0].HeaderText = "Sınıflar";
            dataGridView_Liste.Columns[0].Width = 250;
            dataGridView_Liste.Columns[1].Visible = false;
        }

        private void textBox_sube_Enter(object sender, EventArgs e)
        {
            textBox_Enter(sender);
            SubeVeritabanni SVT = new SubeVeritabanni();
            dataGridView_Liste.DataSource = SVT.Listele();
            dataGridView_Liste.Columns[0].HeaderText = "Şubeler";
            dataGridView_Liste.Columns[0].Width = 250;
            dataGridView_Liste.Columns[1].Visible = false;
        }

        private void textBox_gun_Enter(object sender, EventArgs e)
        {
            textBox_Enter(sender);
            GunVeritabani GVT = new GunVeritabani();
            dataGridView_Liste.DataSource = GVT.Listele();
            dataGridView_Liste.Columns[0].HeaderText = "Günler";
            dataGridView_Liste.Columns[0].Width = 250;
            dataGridView_Liste.Columns[1].Visible = false;

        }

        private void textBox_derslik_TextChanged(object sender, EventArgs e)
        {
            Derslik D = new Derslik();
            DerslikVeritabani DVT = new DerslikVeritabani();
            D.Adi = textBox_derslik.Text;
            dataGridView_Liste.DataSource = DVT.Listele(D);
        }

        private void textBox_donem_TextChanged(object sender, EventArgs e)
        {
            Donemi D = new Donemi();
            D.Adi = textBox_donem.Text;
            DonemiVeritabani DVT = new DonemiVeritabani();
            dataGridView_Liste.DataSource = DVT.Listele(D);
        }

        private void textBox_sinif_TextChanged(object sender, EventArgs e)
        {
            Sinif S = new Sinif();
            S.Adi = textBox_sinif.Text;
            SinifVeritabani SVT = new SinifVeritabani();
            dataGridView_Liste.DataSource = SVT.Listele(S);
        }

        private void textBox_sube_TextChanged(object sender, EventArgs e)
        {
            Sube S = new Sube();
            S.Adi = textBox_sube.Text;
            SubeVeritabanni SVT = new SubeVeritabanni();
            dataGridView_Liste.DataSource = SVT.Listele(S);
        }

        private void textBox_gun_TextChanged(object sender, EventArgs e)
        {
            Gun G = new Gun();
            G.Adi = textBox_gun.Text;
            GunVeritabani GVT = new GunVeritabani();
            dataGridView_Liste.DataSource = GVT.Listele(G);
        }

        private void textBox_saat_TextChanged(object sender, EventArgs e)
        {
            Saat S = new Saat();
            S.Araligi = textBox_saat.Text;
            SaatVeritabani SVT = new SaatVeritabani();
            dataGridView_Liste.DataSource = SVT.Listele(S);
        }

        private void textBox_saat_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox_saat_Leave_1(object sender, EventArgs e)
        {
            textBox_saat.BackColor = Color.White;
            textBox_saat.ForeColor = Color.Black;
        }

        private void textBox_saat_Enter_1(object sender, EventArgs e)
        {
            textBox_saat.BackColor = Color.Coral;
            textBox_saat.ForeColor = Color.White;
            SaatVeritabani SVT = new SaatVeritabani();
            dataGridView_Liste.DataSource = SVT.Listele();
            dataGridView_Liste.Columns[0].HeaderText = "Saat Aralıkları";
            dataGridView_Liste.Columns[0].Width = 250;
            dataGridView_Liste.Columns[1].Visible = false;
        }

        private void radio_NO_CheckedChanged(object sender, EventArgs e)
        {
            s.OgrenimTuru = false;
        }

        private void radio_IO_CheckedChanged(object sender, EventArgs e)
        {
            s.OgrenimTuru = true;
        }

        private void dataGridView_Liste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
