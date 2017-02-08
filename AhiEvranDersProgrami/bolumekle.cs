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
    public partial class bolumekle : Form
    {
        public bolumekle()
        {
            InitializeComponent();
        }

        private void button_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_yeni_Click(object sender, EventArgs e)
        {
            textBox_adi.Text = textBox_kadi.Text = textBox_kod.Text = "";
        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            Bolum b = new Bolum();
            BolumVeritabani bvt = new BolumVeritabani();
            b.Adi = textBox_adi.Text;
            b.Kadi = textBox_kadi.Text;
            b.Kodu = Convert.ToInt32(textBox_kod.Text);
            b.Baskani = Convert.ToInt32(comboBox_baskani.SelectedValue);
            try
            {
                DialogResult d = MessageBox.Show("\""+textBox_kadi.Text+"\" bölümü kayıt etmek istiyormusunuz?","Bilgi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (d==DialogResult.Yes)
                {
                    bvt.Ekle(b);
                    MessageBox.Show("\""+textBox_kadi.Text+"\" başarılı bir şekilde kayıt edildi", "Bilgi", MessageBoxButtons.OK);

                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            BolumListele();
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

        private void bolumekle_Load(object sender, EventArgs e)
        {
            OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
            comboBox_baskani.DataSource = oevt.Listele();
            comboBox_baskani.DisplayMember = "OE";
            comboBox_baskani.ValueMember = "kodu";
            BolumListele();
        }

        private void BolumListele()
        {
            BolumVeritabani BVT = new BolumVeritabani();
            dataGridView_Bolum.DataSource = BVT.Listele();
            dataGridView_Bolum.Columns[0].HeaderText = "Bölüm Kodu";
            dataGridView_Bolum.Columns[1].HeaderText = "B. Kısa Adı";
            dataGridView_Bolum.Columns[2].HeaderText = "Bölm Adı";
            dataGridView_Bolum.Columns[2].Width = 150;
            dataGridView_Bolum.Columns[3].HeaderText = "Bölüm Başkanı";
            dataGridView_Bolum.Columns[3].Width = 150;  
        }

        private void bolumekle_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void bolumekle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void textBox_Bolum_Ara_TextChanged(object sender, EventArgs e)
        {
            BolumAra();
        }

        private void BolumAra()
        {
            Bolum B = new Bolum();
            B.Adi = textBox_Bolum_Ara.Text;
            BolumVeritabani BVT = new BolumVeritabani();
            dataGridView_Bolum.DataSource = BVT.Listele(B);
        }
    }
}
