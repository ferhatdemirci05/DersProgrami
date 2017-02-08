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
    public partial class bolumdersislemleri : Form
    {
        public bolumdersislemleri()
        {
            InitializeComponent();
        }
        bool sart = false;
        private void bolumdersislemleri_Load(object sender, EventArgs e)
        {
            BolumVeritabani bvt = new BolumVeritabani();
            comboBox_Bolum.DataSource = bvt.Listele();
            comboBox_Bolum.ValueMember = "B_Kodu";
            comboBox_Bolum.DisplayMember = "B_KAdi";
            OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
            comboBox_OE.DataSource = oevt.Listele();
            comboBox_OE.ValueMember = "kodu";
            comboBox_OE.DisplayMember = "OE";
            DersVeritabani dvt=new DersVeritabani();
            comboBox_Ders.DataSource = dvt.Listele();
            comboBox_Ders.DisplayMember = "Ders";
            comboBox_Ders.ValueMember = "ID";
            DonemVeritabani dmvt=new DonemVeritabani();
            comboBox_Donem.DataSource = dmvt.DonemListeleListele();
            comboBox_Donem.ValueMember = "Dnm_Kodu";
            comboBox_Donem.DisplayMember = "Donem";   
            comboBox_Bolum.SelectedValue = 0;
            comboBox_Ders.SelectedValue = 0;
            comboBox_Donem.SelectedValue = 0;
            comboBox_OE.SelectedValue = 0;
            sart = true;
            listele();
        }

        private void listele()
        {
            BolumDersDonemVeritabani bddvt=new BolumDersDonemVeritabani();
            dataGridView1.DataSource = bddvt.Listele();
            dataGridView1.Columns["BDDnm_Kodu"].Visible = false;
            dataGridView1.Columns["Dönem"].Width = 60;
            dataGridView1.Columns["Bölüm"].Width = 75;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bolumdersislemleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void comboBox_Bolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sart)
            {
                Bolum b = new Bolum();
                b.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                BolumVeritabani bvt = new BolumVeritabani();
                b = bvt.bolumlistele(b);
                label5.Visible = true;
                label5.Text = "Bölüm "+b.Adi;
                BolumDersDonem bdd = new BolumDersDonem();
                bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
               BolumDersDonemVeritabani bddvt=new BolumDersDonemVeritabani();
               dataGridView1.DataSource = bddvt.Listele(bdd);
            }
            else
            {
                label5.Visible = false;
            }

        }

        private void comboBox_Donem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sart)
            {
                Donem d = new Donem();
                DonemVeritabani dvt = new DonemVeritabani();
                d.Kodu = Convert.ToInt32(comboBox_Donem.SelectedValue);
                d = dvt.DonemListele(d);
                label6.Visible = true;
                label6.Text = "Dönem: "+d.Donemi.Adi+"\nSınıf: "+d.Sinifi.Adi+"/"+d.Subesi.Adi;
                BolumDersDonem bdd = new BolumDersDonem();
                BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
                bdd.Donemi.Kodu = Convert.ToInt32(comboBox_Donem.SelectedValue);
                dataGridView1.DataSource = bddvt.Listele(bdd);
            }
            else
            {
                label6.Visible = false;
            }
        }

        private void comboBox_Ders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sart)
            {
                Ders d = new Ders();
                DersVeritabani dvt = new DersVeritabani();
                d.Kodu = Convert.ToInt32(comboBox_Ders.SelectedValue);
                d = dvt.bilgigetir(d);
                label7.Visible = true;
                label7.Text = "Ders: "+d.Adi;
                BolumDersDonem bdd = new BolumDersDonem();
                BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
                bdd.Dersi.Kodu = Convert.ToInt32(comboBox_Ders.SelectedValue);
                dataGridView1.DataSource = bddvt.Listele(bdd);
            }
            else
            {
                label7.Visible = false;
            }
        }

        private void comboBox_OE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sart)
            {
                OgretimElemani oe = new OgretimElemani();
                OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
                oe.Kodu = Convert.ToInt32(comboBox_OE.SelectedValue);
                oe = oevt.Bİlgigetir(oe);
                label8.Visible = true;
                label8.Text = "Öğretim Elemanı: "+oe.Adi+" "+oe.Soyadi;
                BolumDersDonem bdd = new BolumDersDonem();
                BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
                bdd.Ogretimelemani.Kodu = Convert.ToInt32(comboBox_OE.SelectedValue);
                dataGridView1.DataSource = bddvt.Listele(bdd);
            }
            else
            {
                label8.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_Bolum.SelectedValue!=null && comboBox_Ders.SelectedValue!=null && comboBox_Donem.SelectedValue!=null && comboBox_OE.SelectedValue!=null)
            {
                BolumDersDonem bdd = new BolumDersDonem();
                bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                bdd.Dersi.Kodu = Convert.ToInt32(comboBox_Ders.SelectedValue);
                bdd.Donemi.Kodu = Convert.ToInt32(comboBox_Donem.SelectedValue);
                bdd.Ogretimelemani.Kodu = Convert.ToInt32(comboBox_OE.SelectedValue);
                BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
                if (!bddvt.kontrolet(bdd))
                {
                    try
                    {
                        bddvt.Ekle(bdd);
                        listele();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("Eklemek İstediğiniz bilgiler mevcut", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
            }
            else
            {
                MessageBox.Show("Seçilmemiş alan. Bütün alanlar seçildiği takdirde ekleme gerçekleşecektir.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BolumDersDonem bdd = new BolumDersDonem();
            bdd.Kodu = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["BDDnm_Kodu"].Value.ToString());
            BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
            DialogResult d = MessageBox.Show("Kayıt kalıcı olarak silinecektir onaylıyormusunuz", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                bddvt.Sil(bdd);
                MessageBox.Show("Kayıt başarılı bir şekilde silinmiştir", "Bilgi", MessageBoxButtons.OK);
                listele();
            }
        }
    }
}
