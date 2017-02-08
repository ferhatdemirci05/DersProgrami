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
    public partial class donemsinifyeni : Form
    {
        public donemsinifyeni()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void donemsinifyeni_Load(object sender, EventArgs e)
        {
            SinifVeritabani svt = new SinifVeritabani();
            SubeVeritabanni sbvt = new SubeVeritabanni();
            DonemiVeritabani dvt = new DonemiVeritabani();
            comboBox_sinif.DataSource = svt.Listele();
            comboBox_sube.DataSource = sbvt.Listele();
            comboBox_donem.DataSource = dvt.Listele();
            comboBox_sinif.DisplayMember = "Sf_Adi";
            comboBox_sube.DisplayMember = "Sb_Adi";
            comboBox_donem.DisplayMember = "Dm_Adi";
            comboBox_sinif.ValueMember = "Sf_Kodu";
            comboBox_sube.ValueMember = "Sb_Kodu";
            comboBox_donem.ValueMember = "Dm_Kodu";
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Donem d = new Donem();
            d.Donemi.Kodu = Convert.ToInt32(comboBox_donem.SelectedValue);
            d.Sinifi.Kodu = Convert.ToInt32(comboBox_sinif.SelectedValue);
            d.Subesi.Kodu = Convert.ToInt32(comboBox_sube.SelectedValue);
            DonemVeritabani dvt=new DonemVeritabani();
            if (!dvt.kontrolet(d))
            {
                try
                {
                    dvt.Ekle(d);
                    listele();
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }
            else
            {
                    MessageBox.Show("Eklemek İstediğiniz bilgiler mevcut","Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void listele()
        {
            DonemVeritabani dvt = new DonemVeritabani();
            dataGridView1.DataSource = dvt.Listele();
            dataGridView1.Columns["Dnm_Kodu"].Visible = false;
            dataGridView1.Columns["Sinif"].HeaderText = "Sınıf";
            dataGridView1.Columns["Sb_Adi"].HeaderText = "Şube";
            dataGridView1.Columns["Dm_Adi"].HeaderText = "Dönem";
        }
        
        private void listele(Donem d)
        {
            DonemVeritabani dvt = new DonemVeritabani();
            dataGridView1.DataSource = dvt.Listele(d);
        }

        private void comboBox_sinif_ValueMemberChanged(object sender, EventArgs e)
        {
            Donem d = new Donem();
            d.Sinifi.Kodu = Convert.ToInt32(comboBox_sinif.SelectedValue);
            listele(d);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {

                Donem d = new Donem();
                d.Sinifi.Adi =textBox1.Text;
                listele(d);
            }
            else if (radioButton2.Checked==true)
            {
                Donem d = new Donem();
                d.Subesi.Adi = textBox1.Text;
                listele(d);
            }
            else if (radioButton3.Checked==true)
            {
                Donem d = new Donem();
                d.Donemi.Adi = textBox1.Text;
                listele(d);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Donem d = new Donem();
                d.Kodu = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Dnm_Kodu"].Value.ToString());
                DonemVeritabani dvt = new DonemVeritabani();
                DialogResult dr = MessageBox.Show("Kayıt kalıcı olarak silinecektir onaylıyormusunuz", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    dvt.Sil(d);
                    MessageBox.Show("Kayıt başarılı bir şekilde silinmiştir", "Bilgi", MessageBoxButtons.OK);
                    listele();
                } 
            
        }

        private void donemsinifyeni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
