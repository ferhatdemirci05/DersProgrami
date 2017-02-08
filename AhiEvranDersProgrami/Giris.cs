using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;   
using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.IsolatedStorage;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Mail;

namespace AhiEvranDersProgrami
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        bool a = false, b = false, c = false, d = false, f = false, g=false, kayitedildimi=false,z=false,ogrenimDurum=false;
        int Bolum = 0, Sinif = 0, Sube = 0, Donem = 0, konum;
        BolumDersDonem bdd = new BolumDersDonem();
        BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
        DersDagilimVeritabani ddvt = new DersDagilimVeritabani();
        private void Form1_Load(object sender, EventArgs e)
        {
           radio_NO.Checked = radio_PHNO.Checked = true;
           konum = panel10.Left;
           panel10.Left = panel10.Left + 155;
           panel9.Left = panel9.Left + 158;
           yukle();
           groupBox_OE_el_programi.Location=
               groupBox_derslik_programı.Location=
               groupBox_Bolum_Ders_Programi.Location=
               new System.Drawing.Point(440,245);
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkSQL()
        {
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names
            //Eğer bu bilgisayarda SQL SERVER veya SQLSERVEREXPRESS sürümü yüklendi ise yukarıda regedit bölümünde yüklü SQL SERVER instance'leri yer alacaktır.           
            string[] yuklusqller = (string[])Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Microsoft SQL Server").GetSubKeyNames();
            //Eğer kullanıcının bilgisayarında SQLExpress yüklü değilse
            var yukluozellikler = (from s in yuklusqller where s.Contains("SQLEXPRESS") select s).FirstOrDefault();
            if (yukluozellikler == "SQLEXPRESS")
            {
                DialogResult sonuc = MessageBox.Show("Programı kullanabilmek için SQLEXPRESS gereklidir. Bu Programı Yüklemek istiyor musunuz?", "UYARI", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SQLEXPR_x64_ENU.exe";
                    Process pro = new Process();
                    pro.StartInfo.FileName = path;
                    //Aşağıdaki parametreleri SQLEXPRESS setup dosyama göndererek kurulumu başlatırsam kullanıcıya kurulum yeri v.s gibi bilgileri sormayacak ve doğrudan kuruluma geçecektir.
                    pro.StartInfo.Arguments = "/qb INSTANCENAME=\"SQLEXPRESS\" INSTALLSQLDIR=\"C:\\Program Files\\Microsoft SQL Server\" INSTALLSQLSHAREDDIR=\"C:\\Program Files\\Microsoft SQL Server\" INSTALLSQLDATADIR=\"C:\\Program Files\\Microsoft SQL Server\" ADDLOCAL=\"All\" SQLAUTOSTART=1 SQLBROWSERAUTOSTART=0 SQLBROWSERACCOUNT=\"NT AUTHORITY\\SYSTEM\" SQLACCOUNT=\"NT AUTHORITY\\SYSTEM\" SECURITYMODE=SQL SAPWD=\"\" SQLCOLLATION=\"SQL_Latin1_General_Cp1_CS_AS\" DISABLENETWORKPROTOCOLS=0 ERRORREPORTING=1 ENABLERANU=0";
                    //Process için pencere oluştur
                    pro.StartInfo.CreateNoWindow = true;
                    //Process arka planda çalışsın. 
                    pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    pro.Start();
                    //İSQL kurulumu bitene kadar bekle
                  //  p   ro.WaitForExit();
                }
                else
                {
                    //SQLEXPRESS'i kurmak istemiyorsa programı sonlandır
                    //this.Close();
                }
            }
        }
        private void yukle()
        {
            GunAdi = gvt.GunAdiListele();
            GunId = gvt.GunIdListele();
            SubeVeritabanni svt = new SubeVeritabanni();
            comboBox_Sube2.DataSource = svt.Listele();
            comboBox_Sube2.DisplayMember = "Sb_Adi";
            comboBox_Sube2.ValueMember = "Sb_Kodu";
            OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
            DerslikVeritabani dvd = new DerslikVeritabani();
            comboBox_OE.DataSource = oevt.Listele();
            comboBox_OE.ValueMember = "kodu";
            comboBox_OE.DisplayMember = "OE";
            comboBox_Derslik.DataSource = dvd.Listele();
            comboBox_Derslik.ValueMember = "Dk_Kodu";
            comboBox_Derslik.DisplayMember = "Dk_Adi";
            BolumVeritabani bvt = new BolumVeritabani();
            comboBox_Bolum2.DataSource = comboBox_Bolum.DataSource = bvt.Listele();
            comboBox_Bolum2.ValueMember = comboBox_Bolum.ValueMember = "B_Kodu";
            comboBox_Bolum2.DisplayMember = comboBox_Bolum.DisplayMember = "B_Adi";
            DonemiVeritabani dvt = new DonemiVeritabani();
            comboBox_Donem2.DataSource = dvt.Listele();
            comboBox_Donem2.DisplayMember = "Dm_Adi";
            comboBox_Donem2.ValueMember = "Dm_Kodu";
            a = true;
        }
        private void kayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Ogretim_elemani_ekle oee = new Ogretim_elemani_ekle();
            oee.ShowDialog();

        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            ogretim_elemani_guncelle oeg = new ogretim_elemani_guncelle();
            oeg.ShowDialog();
        }
        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            bolumekle be = new bolumekle();
            be.ShowDialog();
        }
        private void güncelleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            bolum_guncelle bg = new bolum_guncelle();
            bg.ShowDialog();
        }
        private void diğerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            diger_islemler di = new diger_islemler();
            di.ShowDialog();
        }
        private void yeniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            DersEkle de = new DersEkle();
            de.ShowDialog();
        }
        private void güncelleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            DersGuncelle dg = new DersGuncelle();
            dg.ShowDialog();
        }
        private void dönemSınıfŞubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            donemsinifyeni dsy = new donemsinifyeni();
            dsy.ShowDialog();
        }
        private void bölümDersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            bolumdersislemleri bd = new bolumdersislemleri();
            bd.ShowDialog();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode==Keys.B)
            {
                tabControl1.SelectedTab = tabPage3;
                bolumdersislemleri bd = new bolumdersislemleri();
                bd.ShowDialog();
            }
            else if (e.Control && e.KeyCode==Keys.D)
            {
                tabControl1.SelectedTab = tabPage3;
                donemsinifyeni d = new donemsinifyeni();
                d.ShowDialog();
            }
        }
        private void comboBox_Bolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (a)
            {
                if (kayitedildimi)
                {
                    DialogResult dr = MessageBox.Show("Yptığınız işlemi kaydetmek istiyormusunuz", "Bilgi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Dersprograminikaydet();
                        kayitedildimi  = false;

                    }
                    else if (dr==DialogResult.No)
                    {
                        DerssaatleriniAzalt();
                        kayitedildimi = false;
                        c = d = f =z= false;
                        bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                        comboBox_Sınıf.DataSource = bddvt.siniflistele(bdd);
                        comboBox_Sınıf.DisplayMember = "Sf_Adi";
                        comboBox_Sınıf.ValueMember = "Sf_Kodu";
                        comboBox_Sınıf.SelectedValue = 0;
                        comboBox_ADonem.SelectedValue = 0;
                        b = true;
                        label13.Text = comboBox_Bolum.Text;
                        label14.Text = "";
                        Bolum = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                    }
                }
                else
                {
                    c = d = f = z =  false;
                    bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                    comboBox_Sınıf.DataSource = bddvt.siniflistele(bdd);
                    comboBox_Sınıf.DisplayMember = "Sf_Adi";
                    comboBox_Sınıf.ValueMember = "Sf_Kodu";
                    comboBox_Sınıf.SelectedValue = 0;
                    comboBox_ADonem.SelectedValue = 0;
                    b = true;
                    label13.Text = comboBox_Bolum.Text;
                    label14.Text = "";
                    Bolum = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                }
            }
        }

        private void DerssaatleriniAzalt()
        {
            for (int i = 0; i < comboboxislem.Count; i++)
            {
                if (groupBox1.Controls[comboboxislem[i]].BackColor==Color.Green)
                {
                    BolumDersDonem bdd = new BolumDersDonem();
                    bdd.Bolumu.Kodu = Convert.ToInt32(Bolum);
                    bdd.Dersi.Kodu = Convert.ToInt32(derskodu[i]);
                    bdd.Donemi.Donemi.Kodu = Convert.ToInt32(Donem);
                    bdd.Donemi.Sinifi.Kodu = Convert.ToInt32(Sinif);
                    bdd.Donemi.Subesi.Kodu = Convert.ToInt32(Sube);
                    BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
                    bddvt.derssaatiazalt(bdd);
                }
            }
            comboboxislem.Clear();
            derskodu.Clear();
            groupBox1.Controls.Clear();
        }
        private void comboBox_Sınıf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (b)
            {
                if (kayitedildimi)
                {
                    DialogResult dr = MessageBox.Show("Yptığınız işlemi kaydetmek istiyormusunuz", "Bilgi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Dersprograminikaydet();
                        kayitedildimi = false;
                    }
                    else if (dr == DialogResult.No)
                    {
                        DerssaatleriniAzalt();
                        kayitedildimi = false;
                        d = f = z =  false;
                        bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                        bdd.Donemi.Sinifi.Kodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
                        comboBox_Sube.DataSource = bddvt.SubeListele(bdd);
                        comboBox_Sube.DisplayMember = "Sb_Adi";
                        comboBox_Sube.ValueMember = "Sb_Kodu";
                        comboBox_Sube.SelectedValue = 0;
                        c = true;
                        label14.Text = comboBox_Sınıf.Text + ". Sınıf ";
                        Sinif = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
                    }
                }
                else
                {
                    d = f = z = false;
                    bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                    bdd.Donemi.Sinifi.Kodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
                    comboBox_Sube.DataSource = bddvt.SubeListele(bdd);
                    comboBox_Sube.DisplayMember = "Sb_Adi";
                    comboBox_Sube.ValueMember = "Sb_Kodu";
                    comboBox_Sube.SelectedValue = 0;
                    c = true;
                    label14.Text = comboBox_Sınıf.Text + ". Sınıf ";
                    Sinif = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
                }
            }
        }
        private void comboBox_Sube_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c)
            {
                if (kayitedildimi)
                {
                    DialogResult dr = MessageBox.Show("Yptığınız işlemi kaydetmek istiyormusunuz", "Bilgi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Dersprograminikaydet();
                        kayitedildimi =  false;
                    }
                    else if (dr==DialogResult.No)
                    {
                        DerssaatleriniAzalt();
                        kayitedildimi = false;
                        d = z = false;
                        bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                        bdd.Donemi.Sinifi.Kodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
                        bdd.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube.SelectedValue);
                        comboBox_ADonem.DataSource = bddvt.DonemListele(bdd);
                        comboBox_ADonem.DisplayMember = "Dm_Adi";
                        comboBox_ADonem.ValueMember = "Dm_Kodu";
                        comboBox_ADonem.SelectedValue = 0;
                        d = true;
                        label14.Text = comboBox_Sınıf.Text + ". Sınıf " + comboBox_Sube.Text + " Şubesi ";
                        Sube = Convert.ToInt32(comboBox_Sube.SelectedValue);
                    }
                }
                else
                {
                    d = z =  false;
                    bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
                    bdd.Donemi.Sinifi.Kodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
                    bdd.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube.SelectedValue);
                    comboBox_ADonem.DataSource = bddvt.DonemListele(bdd);
                    comboBox_ADonem.DisplayMember = "Dm_Adi";
                    comboBox_ADonem.ValueMember = "Dm_Kodu";
                    comboBox_ADonem.SelectedValue = 0;
                    d = true;
                    label14.Text = comboBox_Sınıf.Text + ". Sınıf " + comboBox_Sube.Text + " Şubesi ";
                    Sube = Convert.ToInt32(comboBox_Sube.SelectedValue);
                }
            }
        }
        bool ogrenimTuru = false;
        List<string> SaatAdi = new List<string>();
        List<int> Saatid = new List<int>();
        List<string> DersId = new List<string>();
        List<string> DerslikId = new List<string>();
        SaatVeritabani svt = new SaatVeritabani();
        GunVeritabani gvt = new GunVeritabani();
        List<string> GunAdi = new List<string>();
        List<int> GunId = new List<int>();
        List<int> sinifId = new List<int>();
        List<string> SinifAdi = new List<string>();
        List<string> comboboxislem = new List<string>();
        List<string> derslikislem = new List<string>();
        List<int> derskodu = new List<int>();
        List<int> ogrenimSaatId = new List<int>();
        private void comboBox_ADonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (d)
            {
                bddvt.DSDSifirla();
                derslikislem.Clear();
                comboboxislem.Clear();
                if (kayitedildimi)
                {
                   DialogResult dr= MessageBox.Show("Yptığınız işlemi kaydetmek istiyormusunuz","Bilgi",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                   if (dr==DialogResult.Yes)
                   {
                       
                       Dersprograminikaydet();
                       ogrenimSaatId.Clear();
                       Dersprogramiasamasi();
                       z = false;
                       DersprogramiKontrolu();
                       kayitedildimi = false;
                      
                   }
                   else if (dr==DialogResult.No)
                   {
                       groupBox1.Visible = false;
                       DerssaatleriniAzalt();
                       ogrenimSaatId.Clear();
                       Dersprogramiasamasi();
                       z = false;
                       DersprogramiKontrolu();
                       kayitedildimi = false;
                       Donem = Convert.ToInt32(comboBox_ADonem.SelectedValue);
                   }
                }
                else
                {
                    groupBox1.Visible = false;
                    Donem = Convert.ToInt32(comboBox_ADonem.SelectedValue);
                    ogrenimSaatId.Clear();
                    Dersprogramiasamasi();
                    z = false;
                    DersprogramiKontrolu();
                }
            }
        }

        private void DersprogramiKontrolu()
        {
            DersDagilimi dd = DersProgramiIcinBilgileriAl();
            if (ddvt.DersprogramiKontrolu(dd))
            {
                button_DersProgramiGoster.Visible = true;
                derskodu.Clear();
                for (int j = 0; j < GunId.Count; j++)
                {
                    for (int i = 0; i < ogrenimSaatId.Count; i++)
                    {
                        dd.BolumDersDonemi.Dersi.Adi = "";
                        dd.BolumDersDonemi.Dersi.Kodu = 0;
                        dd.Derslik.Adi = "";
                        dd.Derslik.Kodu = 0;
                        dd = DersProgramiIcinBilgileriAl();
                        dd.Gunu.Kodu = GunId[j];
                        dd.Saati.Kodu = Saatid[i];
                        dd = ddvt.DersDagilimdanDersAl(dd);
                        if (dd.BolumDersDonemi.Dersi.Kodu != 0)
                        {
                            groupBox1.Controls["ComboBox_Ders" + ((j * Saatid.Count) + (i + 1))].Text = dd.BolumDersDonemi.Dersi.Adi;
                            DersId.Add(dd.BolumDersDonemi.Dersi.Adi);
                            groupBox1.Controls["ComboBox_Ders" + ((j * Saatid.Count) + (i + 1))].BackColor = Color.Green;
                            groupBox1.Controls["ComboBox_Ders" + ((j * Saatid.Count) + (i + 1))].ForeColor = Color.White;
                            derskodu.Add(dd.BolumDersDonemi.Dersi.Kodu);
                            derssaatiarttir((ComboBox)groupBox1.Controls["ComboBox_Ders" + ((j * Saatid.Count) + (i + 1))]);
                        }
                        else
                        {
                            groupBox1.Controls["ComboBox_Ders" + ((j * Saatid.Count) + (i + 1))].Text = "Ders Seçiniz";
                            DersId.Add("");
                            derskodu.Add(0);
                        }
                        if (dd.Derslik.Kodu != 0)
                        {
                            groupBox1.Controls["ComboBox_Derslik" + j + (Saatid.Count * (i + 1))].Text = dd.Derslik.Adi;
                            DerslikId.Add(dd.Derslik.Adi);
                            groupBox1.Controls["ComboBox_Derslik" + j + (Saatid.Count * (i + 1))].ForeColor = Color.White;
                            groupBox1.Controls["ComboBox_Derslik" + j + (Saatid.Count * (i + 1))].BackColor = Color.Green;
                        }
                        else
                        {
                            groupBox1.Controls["ComboBox_Derslik" + j + (Saatid.Count*(i+1))].Text = "Seç";
                            DerslikId.Add("");
                        }
                    }
                }
            }
            else
            {
                
                for (int j = 0; j < GunId.Count; j++)
                {
                    for (int i = 0; i < ogrenimSaatId.Count; i++)
                    {
                        groupBox1.Controls["ComboBox_Ders" + ((j * Saatid.Count) + (i + 1))].Text = "Ders Seçiniz";
                        groupBox1.Controls["ComboBox_Derslik" + j + (Saatid.Count*(i+1))].Text = "Seç";
                        DerslikId.Add("");
                        DersId.Add("");
                    }
                }
            }
            z = true;
        }

        private DersDagilimi DersProgramiIcinBilgileriAl()
        {
            DersDagilimi dd = new DersDagilimi();
            dd.BolumDersDonemi.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
            dd.BolumDersDonemi.Donemi.Sinifi.Kodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
            dd.BolumDersDonemi.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube.SelectedValue);
            dd.BolumDersDonemi.Donemi.Donemi.Kodu = Convert.ToInt32(comboBox_ADonem.SelectedValue);
            return dd;
        }
        private void Dersprogramiasamasi()
        {
            comboboxislem.Clear();
            derskodu.Clear();
            groupBox1.Controls.Clear();
            if (g)
            {
                this.groupBox1.Controls.Clear();
            }
            y = 15;
            x = 145;
            for (int i = 0; i < GunAdi.Count; i++)
            {
                Label l = new Label();
                l.Top = y;
                l.Left = x;
                l.Width = 100;
                l.Text = GunAdi[i].ToString();
                l.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                l.Name = "Label_" + GunAdi[i];
                this.groupBox1.Controls.Add(l);
                x += 220;
            }
            y = 42;
            x = 105;
            for (int i = 0; i < GunAdi.Count; i++)
            {
                Label l = new Label();
                l.Top = y;
                l.Left = x;
                l.Width = 100;
                l.Text = "Dersler";
                l.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.groupBox1.Controls.Add(l);
                x += 128;
                Label l2 = new Label();
                l2.Top = y;
                l2.Left = x;
                l2.Width = 100;
                l2.Text = "Derslik   |";
                l2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.groupBox1.Controls.Add(l2);
                x += 102;
            }

            DersDagilimVeritabani ddvt = new DersDagilimVeritabani();
            DersDagilimi dd = new DersDagilimi();
            Saat s = new Saat();
            s.OgrenimTuru = ogrenimTuru;
            SaatAdi = svt.saatadilistele(s);
            Saatid = svt.SaatIdListele(s);

            y = 70;
            x = 10;
            for (int i = 0; i < SaatAdi.Count; i++)
            {
                string[] saat = new string[2];
                saat =SaatAdi[i].Split(':');
                ogrenimSaatId.Add(Saatid[i]);
                Label l = new Label();
                l.Top = y;
                l.Left = x;
                l.Width = 50;
                l.Text = SaatAdi[i].ToString();
                l.Name = "Label_" + SaatAdi[i];
                l.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                     this.groupBox1.Controls.Add(l);
                        y += 30;
            }
            x += 60;
            y = 67;
            for (int j = 0; j < GunId.Count; j++)
            {
                for (int i = 0; i <ogrenimSaatId.Count; i++)
                {
                    ComboBox c = new ComboBox();
                    c.Top = y;
                    c.Left = x;
                    c.Width = 150;
                    c.Name = "ComboBox_Ders" + ((j * Saatid.Count) + (i + 1));
                    dd = DersProgramiIcinBilgileriAl();
                    c.DataSource = ddvt.DersListele(dd);
                    c.DisplayMember = "D_Adi";
                    c.ValueMember = "D_Kodu";
                    this.groupBox1.Controls.Add(c);
                    c.Text = "Ders Seçiniz...";
                    derskodu.Add(0);
                    comboboxislem.Add(c.Name);
                    c.Click += new EventHandler(sil);
                    c.SelectedValueChanged += new EventHandler(sec);
                    //c.Text = "Ders Seçiniz...";
                    y += 30;
                }
                x += 160;
                y = 67;
                for (int i = 0; i <ogrenimSaatId.Count; i++)
                {
                    ComboBox c = new ComboBox();
                    c.Top = y;
                    c.Left = x;
                    c.Width = 60;
                    c.Name = "ComboBox_Derslik" + j + (Saatid.Count * (i+1));
                    derslikislem.Add(c.Name);
                    dd.Gunu.Kodu = GunId[j];
                    dd.Saati.Kodu = Saatid[i];
                    c.SelectedValue = 0;
                    c.DataSource = ddvt.DerslikListele(dd);
                    c.ValueMember = "Dk_Kodu";
                    c.DisplayMember = "Dk_Adi";
                    this.groupBox1.Controls.Add(c);
                    //c.Text = "Seç";
                    c.Click += new EventHandler(sil);
                    c.SelectedValueChanged += new EventHandler(secderslik);
                    y += 30;
                }
                y = 67;
                x += 70;
            }
            g = true;
            label14.Text = comboBox_Sınıf.Text + ". Sınıf " + comboBox_Sube.Text + " Şubesi " + comboBox_ADonem.Text + " Dönemi ";
            this.groupBox1.Visible = button1.Visible = true;
        }

        private void secderslik(object sender, EventArgs e)
        {
            kayitedildimi = true;
            ComboBox c = (ComboBox)sender;
            c.BackColor = Color.Green;
            c.ForeColor = Color.White;
            for (int i = 0; i < derslikislem.Count; i++)
            {
                if (c.Name==groupBox1.Controls[derslikislem[i]].Name)
                {

                        DerslikId[i] = groupBox1.Controls[derslikislem[i]].Text;

                }
            }
        }
        private void sec(object sender, EventArgs e)
        {
            if (z)
            {
                kayitedildimi = true;
                ComboBox c = (ComboBox)sender;
                int[] derskodu2 = new int[comboboxislem.Count];
                for (int i = 0; i < comboboxislem.Count; i++)
                {
                    derskodu2[i] = derskodu[i];
                }
                for (int i = 0; i < comboboxislem.Count; i++)
                {
                    if (c.Name == comboboxislem[i])
                    {
                        if (DersId[i] != c.SelectedText)
                            DersId[i] = c.SelectedText;
                        if (derskodu2[i] == 0)
                        {
                            if (derssaatikontrolet(c))
                            {
                                derssaatiarttir(c);
                                derskodu2[i] = Convert.ToInt32(c.SelectedValue);
                                c.BackColor = Color.Green;
                                c.ForeColor = Color.White;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Seçtiğiniz ders haftalık ders saatini geçemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                c.BackColor = Color.Red;
                                c.ForeColor = Color.White;
                                break;
                            }
                        }
                        else
                        {
                            if (derssaatikontrolet(c))
                            {
                                derssaatiazalt(derskodu2[i]);
                                derssaatiarttir(c);
                                derskodu2[i] = Convert.ToInt32(c.SelectedValue);
                                c.BackColor = Color.Green;
                                c.ForeColor = Color.White;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Seçtiğiniz ders haftalık ders saatini geçemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                c.BackColor = Color.Red;
                                c.ForeColor = Color.White;
                                break;
                            }
                        }
                    }
                }
                derskodu.Clear();
                for (int i = 0; i < derskodu2.Length; i++)
                {
                    derskodu.Add(derskodu2[i]);
                }

            }
        }

        private bool derssaatikontrolet(ComboBox c)
        {
            BolumDersDonem bdd = new BolumDersDonem();
            bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
            bdd.Dersi.Kodu = Convert.ToInt32(c.SelectedValue);
            bdd.Donemi.Donemi.Kodu = Convert.ToInt32(comboBox_ADonem.SelectedValue);
            bdd.Donemi.Sinifi.Kodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
            bdd.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube.SelectedValue);
            BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
            return bddvt.derssaatikontrolet(bdd);
        }

        private void derssaatiazalt(int p)
        {
            BolumDersDonem bdd = new BolumDersDonem();
            bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
            bdd.Dersi.Kodu = Convert.ToInt32(p);
            bdd.Donemi.Donemi.Kodu = Convert.ToInt32(comboBox_ADonem.SelectedValue);
            bdd.Donemi.Sinifi.Kodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
            bdd.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube.SelectedValue);
            BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
            bddvt.derssaatiazalt(bdd);
        }

        private void derssaatiarttir(ComboBox c)
        {
            BolumDersDonem bdd = new BolumDersDonem();
            bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
            bdd.Dersi.Kodu = Convert.ToInt32(c.SelectedValue);
            bdd.Donemi.Donemi.Kodu = Convert.ToInt32(comboBox_ADonem.SelectedValue);
            bdd.Donemi.Sinifi.Kodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
            bdd.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube.SelectedValue);
            BolumDersDonemVeritabani bddvt = new BolumDersDonemVeritabani();
            bddvt.derssaatiarttir(bdd);
        }


        private void sil(object sender, EventArgs e)
        {
            kayitedildimi = true;
            ComboBox c = (ComboBox)sender;
            derssaatiazalt(Convert.ToInt32(c.SelectedValue));
            c.BackColor = Color.Red;
            c.ForeColor = Color.White;
            c.Text = "";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            kayitedildimi = false;
            Dersprograminikaydet();
           //Dersprogramiasamasi();
        }
        private void Dersprograminikaydet()
        {
            bool durum = false;
            List<string> DersId2 = new List<string>();
            List<string> DerslikId2 = new List<string>();
            for (int i = 0; i < comboboxislem.Count; i++)
            {
                if (groupBox1.Controls[comboboxislem[i].ToString()].BackColor!=Color.Green )
                {
                    DersId2.Add("");
                }
                else
                {
                    if (DersId[i] == "")
                        DersId2.Add(groupBox1.Controls[comboboxislem[i]].Text);
                    else
                        DersId2.Add(DersId[i]);
                }
                if (groupBox1.Controls[derslikislem[i]].BackColor != Color.Green)
                {
                    DerslikId2.Add("");
                }
                else if (groupBox1.Controls[derslikislem[i]].BackColor == Color.Red)
                    DerslikId2.Add("");
                else if(groupBox1.Controls[derslikislem[i]].BackColor==Color.Green)
                {
                    if (DerslikId[i] == "")
                        DerslikId2.Add("");
                    else
                        DerslikId2.Add(DerslikId[i]);
                }
            }
            DersDagilimi dd = new DersDagilimi();
            dd.BolumDersDonemi.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
            dd.BolumDersDonemi.Donemi.Donemi.Kodu = Convert.ToInt32(comboBox_ADonem.SelectedValue);
            dd.BolumDersDonemi.Donemi.Sinifi.Kodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
            dd.BolumDersDonemi.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube.SelectedValue);
            try
            {
                ddvt.DersDagilimiEkle(dd, DersId2, ogrenimSaatId, DerslikId2,GunId);
                durum = true;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                durum = false;
            }
            DerssaatleriniAzalt();
            if (durum)
            {
                DersId.Clear();
                DerslikId.Clear();
                DerslikId2.Clear();
                DersId2.Clear();
                MessageBox.Show("Ders Programı Başarılı Bir Şekilde Kaydedildi", "Bilgi", MessageBoxButtons.OK);
            }
        }
        int x=0,y=0;
        private void comboBox_Gun_SelectedIndexChanged(object sender, EventArgs e)
        {
                label14.Text =comboBox_Sınıf.Text + ". Sınıf " + comboBox_Sube.Text + " Şubesi " + comboBox_ADonem.Text + " Dönemi";
        }

        string []sutun=new string[26];
        private void button2_DP_Click(object sender, EventArgs e)
        {
            bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum2.SelectedValue);
            bdd.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube2.SelectedValue);
            bdd.Donemi.Donemi.Kodu = Convert.ToInt32(comboBox_Donem2.SelectedValue);
            sinifId = bddvt.KayıtliBolumSiniflariListele(bdd);
            SinifAdi = bddvt.KayıtliBolumSiniflariListele2(bdd);
            if (SinifAdi.Count!=0)
            {
                Excel.Application uygulama;
                Excel.Workbook kitap;
                Excel.Worksheet sayfa;
                BolumDersProgramiHazirla(out uygulama, out kitap, out sayfa);
                uygulama.Visible = true;
                uygulama.AlertBeforeOverwriting = true;
            }
            else
            {
                MessageBox.Show("Aradığınız kriterlere uygun hazırlanmış ders kaydı bulunamadı.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        bool programHazirlaOgrenimTuru = false;
        private void BolumDersProgramiHazirla(out Excel.Application uygulama, out Excel.Workbook kitap, out Excel.Worksheet sayfa)
        {
            Saat s = new Saat();
            s.OgrenimTuru = programHazirlaOgrenimTuru;
            bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum2.SelectedValue);
            bdd.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube2.SelectedValue);
            bdd.Donemi.Donemi.Kodu = Convert.ToInt32(comboBox_Donem2.SelectedValue);
            sinifId = bddvt.KayıtliBolumSiniflariListele(bdd);
            SinifAdi = bddvt.KayıtliBolumSiniflariListele2(bdd);
            label2.Text = "HAZIRLANIYOR...";
            button2_DP.Enabled = false;
            progressBar1.Value = 0;
            for (int i = 65; i < 91; i++)
            {
                sutun[i - 65] = Convert.ToChar(i).ToString();
            }
            Saatid = svt.SaatIdListele(s);
            GunAdi = gvt.GunListele();
            SaatAdi = svt.saatadilistele(s);
            object misValue = System.Reflection.Missing.Value;
            uygulama = new Excel.Application();
            kitap = uygulama.Workbooks.Add(misValue);
            sayfa = (Excel.Worksheet)kitap.Worksheets.get_Item(1);
            sayfa.Cells.Range["A1", "A3"].MergeCells = sayfa.Cells.Range["B1", "B3"].MergeCells = true;
            sayfa.Cells.Range["A1", "A3"].VerticalAlignment = Excel.XlVAlign.xlVAlignBottom;
            sayfa.Cells.Range["A1", "A3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            sayfa.Cells.Range["A1", "A3"].Value = "Gün";
            sayfa.Cells.Range["B1", "B3"].VerticalAlignment = Excel.XlVAlign.xlVAlignBottom;
            sayfa.Cells.Range["B1", "B3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            sayfa.Cells.Range["B1", "B3"].Value = "Saat";
            sayfa.Cells[1, 3] = comboBox_Bolum2.Text;
            sayfa.Cells.Range["A1", "A3"].RowHeight = 25;
            int k = -3;
            for (int i = 0; i <SinifAdi.Count; i++)
            {
                k += 3;
                sayfa.Cells.Range[(sutun[k + 2]) + "2", (sutun[k + 4]) + "2"].MergeCells = true;
                sayfa.Cells.Range[(sutun[k + 2]) + "2", (sutun[k + 4]) + "2"].Font.Bold = true;
                if(!programHazirlaOgrenimTuru)
                        sayfa.Cells.Range[(sutun[k + 2]) + "2", (sutun[k + 4]) + "2"].Value = SinifAdi[i] + "/" + comboBox_Sube2.Text + " Sınıfı N.Ö";
                else
                    sayfa.Cells.Range[(sutun[k + 2]) + "2", (sutun[k + 4]) + "2"].Value = SinifAdi[i] + "/" + comboBox_Sube2.Text + " Sınıfı İ.Ö";
                sayfa.Cells.Range[(sutun[k + 2]) + "2", (sutun[k + 5]) + "2"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                sayfa.Cells.Range[(sutun[k + 2]) + "2", (sutun[k + 5]) + "2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                sayfa.Cells.Range[(sutun[k + 2]) + "2", (sutun[k + 5]) + "2"].RowHeight = 25;
                sayfa.Cells.Range[(sutun[k + 2]) + "3", (sutun[k + 2] + "3")].Value = "DERS";
                sayfa.Cells.Range[(sutun[k + 3]) + "3", (sutun[k + 3] + "3")].Value = "ÖĞ.EL.";
                sayfa.Cells.Range[(sutun[k + 4]) + "3", (sutun[k + 4] + "3")].Value = "DERSLİK";
                sayfa.Cells.Range[(sutun[k + 2]) + "3", (sutun[k + 4] + "3")].VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                sayfa.Cells.Range[(sutun[k + 2]) + "3", (sutun[k + 4] + "3")].HorizontalAlignment =
                    Excel.XlHAlign.xlHAlignCenter;
                sayfa.Cells.Range[(sutun[k + 2]) + "3", (sutun[k + 4] + "3")].RowHeight = 25;
            }

            sayfa.Cells.Range["C1", (sutun[k + 4]) + "1"].Font.Bold = true;
            sayfa.Cells.Range["C1", (sutun[k + 4]) + "1"].MergeCells = true;
            sayfa.Cells.Range["C1", (sutun[k + 4]) + "1"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            sayfa.Cells.Range["C1", (sutun[k + 4]) + "1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            sayfa.Cells.Range["A1", (sutun[k + 4]) + ((Saatid.Count * GunAdi.Count) + 3)].Borders.LineStyle = Border3DStyle.RaisedOuter;
            for (int i = 0; i < GunAdi.Count; i++)
            {
                sayfa.Cells.Range["A" + (i * Saatid.Count + 4), "A" + ((i + 1) * Saatid.Count + 3)].MergeCells = true;
                sayfa.Cells[i * Saatid.Count + 4, 1].value = GunAdi[i].ToString().ToUpper();
                sayfa.Cells[i * Saatid.Count + 4, 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                sayfa.Cells[i * Saatid.Count + 4, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                sayfa.Cells[i * Saatid.Count + 4, 1].Orientation = Excel.XlOrientation.xlUpward;
                for (int j = 0; j < Saatid.Count; j++)
                {
                    sayfa.Cells[(i * Saatid.Count + 4) + j, 2].value = SaatAdi[j];
                    sayfa.Cells[(i * Saatid.Count + 4) + j, 2].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    sayfa.Cells[(i * Saatid.Count + 4) + j, 2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
            }
            bool renkver = true;
            sayfa.Cells.Range["A3", "B3"].EntireColumn.AutoFit();
            k = -3;
            string[] dersdagilimlari = new string[3];
            DersDagilimi dd = new DersDagilimi();
            DersDagilimVeritabani ddvt = new DersDagilimVeritabani();
            progressBar1.Value = 0;
            progressBar1.Maximum = SinifAdi.Count * GunAdi.Count * SaatAdi.Count;
            for (int i = 0; i < SinifAdi.Count; i++)
            {
                k += 3;
                bdd.Donemi.Sinifi.Kodu = sinifId[i];
                for (int j = 0; j < GunAdi.Count; j++)
                {
                    dd.Gunu.Kodu = GunId[j];
                    for (int l = 0; l < SaatAdi.Count; l++)
                    {
                        progressBar1.Value++;
                        dd.Saati.Kodu = Saatid[l];
                        dersdagilimlari = ddvt.dersdagilimigetir(dd, bdd);
                        sayfa.Cells.Range[(sutun[k + 2] + ((j * SaatAdi.Count) + l + 4)), (sutun[k + 2] + ((j * SaatAdi.Count) + l + 4))].Value = dersdagilimlari[0];
                        sayfa.Cells.Range[(sutun[k + 3] + ((j * SaatAdi.Count) + l + 4)), (sutun[k + 3] + ((j * SaatAdi.Count) + l + 4))].Value = dersdagilimlari[1];
                        sayfa.Cells.Range[(sutun[k + 4] + ((j * SaatAdi.Count) + l + 4)), (sutun[k + 4] + ((j * SaatAdi.Count) + l + 4))].Value = dersdagilimlari[2];
                        sayfa.Cells.Range[(sutun[k + 2] + ((j * SaatAdi.Count) + l + 4)), (sutun[k + 4] + ((j * SaatAdi.Count) + l + 4))].HorizontalAlignment =
                            Excel.XlHAlign.xlHAlignCenter;
                        sayfa.Cells.Range[(sutun[k + 2] + ((j * SaatAdi.Count) + l + 4)), (sutun[k + 4] + ((j * SaatAdi.Count) + l + 4))].VerticalAlignment =
                            Excel.XlVAlign.xlVAlignCenter;
                        sayfa.Cells.Range[(sutun[k + 2] + ((j * SaatAdi.Count) + l + 4)), (sutun[k + 4] + ((j * SaatAdi.Count) + l + 4))].EntireColumn.AutoFit();
                        if (renkver)
                        {
                            sayfa.Cells.Range[(sutun[k + 2] + ((j * SaatAdi.Count) + l + 4)), (sutun[k + 4] + ((j * SaatAdi.Count) + l + 4))].Interior.Color = Color.Gainsboro;
                        }
                        else
                        {
                            sayfa.Cells.Range[(sutun[k + 2] + ((j * SaatAdi.Count) + l + 4)), (sutun[k + 4] + ((j * SaatAdi.Count) + l + 4))].Interior.Color = Color.WhiteSmoke;
                        }
                    }
                    if (renkver)
                    {
                        renkver = false;
                    }
                    else
                    {
                        renkver = true;
                    }
                }
            }
            sayfa.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            sayfa.PageSetup.Zoom = 68;
            Bolum bolum = new Bolum();
            BolumVeritabani bvt = new BolumVeritabani();
            bolum.Kodu = Convert.ToInt32(comboBox_Bolum2.SelectedValue);
            bolum = bvt.bolumlistele(bolum);
            sayfa.Cells.Range["C" + (GunAdi.Count * Saatid.Count + 5), "C" + (GunAdi.Count * Saatid.Count + 5)].Value = bolum.Kadi + " Bölüm Başkanı";
            OgretimElemani oe = new OgretimElemani();
            OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
            oe.Kodu = bolum.Baskani;
            oe = oevt.Bİlgigetir(oe);
            Unvan u = new Unvan();
            UnvanVeritabani uvt = new UnvanVeritabani();
            u.Kodu = oe.Unvani.Kodu;
            u = uvt.UnvanListele(u);
            sayfa.Cells.Range["C" + (GunAdi.Count * Saatid.Count + 6), "C" + (GunAdi.Count * Saatid.Count + 6)].Value = u.Adi + " " + oe.Adi + " " + oe.Soyadi;
            sayfa.Cells.Range[sutun[3 + (sinifId.Count * 2)] + (GunAdi.Count * Saatid.Count + 5), sutun[3 + (sinifId.Count * 2)] + (GunAdi.Count * Saatid.Count + 5)].Value = ".... / ..../" + DateTime.Now.Year;
            sayfa.Cells.Range[sutun[3 + (sinifId.Count * 2)] + (GunAdi.Count * Saatid.Count + 6), sutun[3 + (sinifId.Count * 2)] + (GunAdi.Count * Saatid.Count + 6)].Value = comboBox_Unvan.Text + " " + textBox1.Text;
            sayfa.Cells.Range[sutun[3 + (sinifId.Count * 2)] + (GunAdi.Count * Saatid.Count + 7), sutun[3 + (sinifId.Count * 2)] + (GunAdi.Count * Saatid.Count + 7)].Value = comboBox_Dekanunvani.Text;
            button2_DP.Enabled = true;
            label2.Text = "HAZIR.";
        }
        private void comboBox_Dekanunvani_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_Okulmuduradi.Text = comboBox_Dekanunvani.Text;
            UnvanVeritabani uvt=new UnvanVeritabani();
            comboBox_Unvan.DataSource = uvt.Listele();
            comboBox_Unvan.DisplayMember = "U_Adi";
            comboBox_Unvan.ValueMember = "U_Kodu";
            label3.Visible = label_Okulmuduradi.Visible = comboBox_Unvan.Visible = textBox1.Visible=panel13.Visible=panel14.Visible = true;
        }
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            yukle();
        }
        private void tabControl1_Enter(object sender, EventArgs e)
        {
            yukle();
        }
        private void button_EP_Click(object sender, EventArgs e)
        {
            /****EL PROGRAMI ÇIKART*****/
            Excel.Application uygulama;
            Excel.Workbook kitap;
            Excel.Worksheet sayfa;
            ElprogramiHazirla(out uygulama, out kitap, out sayfa);
            uygulama.Visible = true;
            /****EL PROGRAMI ÇIKART****/
        }
        string yil;
        private void ElprogramiHazirla(out Excel.Application uygulama, out Excel.Workbook kitap, out Excel.Worksheet sayfa)
        {
            string donem = "";
            for (int i = 65; i < 91; i++)
            {
                sutun[i - 65] = Convert.ToChar(i).ToString();
            }
            GunAdi = gvt.GunListele();
            GunId = gvt.GunIdListele();
            SaatAdi = svt.saatadilistele();
            Saatid = svt.SaatIdListele();
            object misValue = System.Reflection.Missing.Value;
            uygulama = new Excel.Application();
            kitap = uygulama.Workbooks.Add(misValue);
            sayfa = (Excel.Worksheet)kitap.Worksheets.get_Item(1);
            sayfa.Cells.Range["D1", "D1"].Value = "Sayın   :";
            sayfa.Cells.Range["E1", "E1"].Value = comboBox_OE.Text;
            if (DateTime.Now.Month < 10)
            {
               
                yil = (DateTime.Now.Year - 1).ToString() + "-" + (DateTime.Now.Year).ToString();
            }
            else
            {
               
                yil = (DateTime.Now.Year).ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            }
            if ((DateTime.Now.Month > 8 && DateTime.Now.Month < 12) || (DateTime.Now.Month < 2)) donem = "Güz";
            else donem = "Bahar";
            sayfa.Cells.Range["A3", "I3"].MergeCells = true;
            sayfa.Cells.Range["A3", "I3"].Value = yil + " Eğitim-Öğretim "+ donem +" dönemi haftalık  ders  programınız  aşağıya çıkarılmıştır. 2547   sayılı   kanun  ve  diğer   mevzuat  ile akademik \n takvime  bağlı  olarak  eğitim-öğretim hususunda gerekli dikkat ve titizliğin gösterilmesini rica eder, başarılı bir eğitim-öğretim yılı dilerim.";
            sayfa.Cells.Range["A3", "I3"].RowHeight = 33;
            sayfa.Cells.Range["A3", "I3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            sayfa.Cells.Range["H4", "H4"].Value = comboBox_Unvan.Text + " " + textBox1.Text;
            sayfa.Cells.Range["H5", "H5"].Value = comboBox_Dekanunvani.Text;
            sayfa.Cells.Range["H4", "H4"].HorizontalAlignment = sayfa.Cells.Range["H5", "H5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            sayfa.Cells.Range["B7", "B7"].Value = "D.N.";
            sayfa.Cells.Range["C7", "C7"].Value = "Saat";
            sayfa.Cells.Range["A6", "A7"].MergeCells = sayfa.Cells.Range["B6", "B7"].MergeCells = sayfa.Cells.Range["C6", "C7"].MergeCells = true;
            sayfa.Cells.Range["D6", "D6"].Value = "GÜNLER";
            sayfa.Cells.Range["D7", "D7"].Value = "DERSİN";
            sayfa.Cells.Range["B6", "B7"].HorizontalAlignment = sayfa.Cells.Range["C6", "C7"].HorizontalAlignment =
                sayfa.Cells.Range["D6", "D7"].HorizontalAlignment = sayfa.Cells.Range["D7", "D7"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            sayfa.Cells.Range["B6", "B7"].VerticalAlignment = sayfa.Cells.Range["C6", "C7"].VerticalAlignment =
                  sayfa.Cells.Range["D6", "D6"].VerticalAlignment = sayfa.Cells.Range["D7", "D7"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            for (int i = 0; i < GunAdi.Count; i++)
            {
                sayfa.Cells.Range[sutun[4 + i] + "6", sutun[4 + i] + "6"].Value = GunAdi[i];
                sayfa.Cells.Range[sutun[4 + i] + "6", sutun[4 + i] + "6"].ColumnWidth = 25;
                sayfa.Cells.Range[sutun[4 + i] + "6", sutun[4 + i] + "6"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                sayfa.Cells.Range[sutun[4 + i] + "6", sutun[4 + i] + "7"].MergeCells = true;
                sayfa.Cells.Range[sutun[4 + i] + "6", sutun[4 + i] + "7"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            }
            sayfa.Cells.Range["A6", sutun[3 + GunAdi.Count] + "7"].Borders.LineStyle = Border3DStyle.RaisedOuter;
            sayfa.Cells.Range["D7"].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = false;
            sayfa.Cells.Range["A8", "A" + (SaatAdi.Count * 2 + 8)].MergeCells = true;
            sayfa.Cells.Range["A8", "A" + (SaatAdi.Count * 2 + 8)].Value = "N\nO\nR\nM\nA\nL\n\n\nÖ\nĞ\nR\nE\nT\nİ\nM";
            sayfa.Cells.Range["A8", "A" + (SaatAdi.Count * 2 + 8)].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            sayfa.Cells.Range["A8", "A" + (SaatAdi.Count * 2 + 8)].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            sayfa.Cells.Range["A8", sutun[GunAdi.Count + 3] + (SaatAdi.Count * 2 + 8)].Borders.LineStyle = Border3DStyle.RaisedOuter;
            for (int i = 0; i < SaatAdi.Count/2; i++)
            {
                sayfa.Cells.Range["C" + (2 * i + 8), "C" + (2 * i + 9)].MergeCells =
                   sayfa.Cells.Range["B" + (2 * i + 8), "B" + (2 * i + 9)].MergeCells = true;
                sayfa.Cells.Range["B" + (2 * i + 8), "B" + (2 * i + 9)].Value = i + 1;
                sayfa.Cells.Range["C" + (2 * i + 8), "C" + (2 * i + 9)].Value = SaatAdi[i];
                sayfa.Cells.Range["D" + (2 * i + 8), "D" + (2 * i + 8)].Value = "KODU";
                sayfa.Cells.Range["D" + (2 * i + 9), "D" + (2 * i + 9)].Value = "YERİ";
                sayfa.Cells.Range["D" + (2 * i + 9), sutun[3 + GunAdi.Count] + (2 * i + 9)].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = false;
            }
            for (int i = SaatAdi.Count / 2; i < SaatAdi.Count; i++)
            {
                sayfa.Cells.Range["C" + (2 * i + 9), "C" + (2 * i + 10)].MergeCells =
                    sayfa.Cells.Range["B" + (2 * i + 9), "B" + (2 * i + 10)].MergeCells = true;
                sayfa.Cells.Range["B" + (2 * i + 9), "B" + (2 * i + 10)].Value = i + 1;
                sayfa.Cells.Range["C" + (2 * i + 9), "C" + (2 * i + 10)].Value = SaatAdi[i];
                sayfa.Cells.Range["D" + (2 * i + 9), "D" + (2 * i + 9)].Value = "KODU";
                sayfa.Cells.Range["D" + (2 * i + 10), "D" + (2 * i + 10)].Value = "YERİ";
                sayfa.Cells.Range["D" + (2 * i + 10), sutun[3 + GunAdi.Count] + (2 * i + 10)].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = false;
            }
            sayfa.Cells.Range["C8", "C" + (SaatAdi.Count * 2 + 8)].HorizontalAlignment =
                sayfa.Cells.Range["B8", "B" + (SaatAdi.Count * 2 + 8)].HorizontalAlignment =
                sayfa.Cells.Range["D8", "D" + (SaatAdi.Count * 2 + 8)].HorizontalAlignment =
                Excel.XlHAlign.xlHAlignCenter;
            sayfa.Cells.Range["C8", "C" + (SaatAdi.Count * 2 + 8)].VerticalAlignment =
                sayfa.Cells.Range["B8", "B" + (SaatAdi.Count * 2 + 8)].VerticalAlignment =
                sayfa.Cells.Range["D8", "D" + (SaatAdi.Count * 2 + 8)].VerticalAlignment =
                Excel.XlVAlign.xlVAlignCenter;
            sayfa.Cells.Range["B" + (SaatAdi.Count + 8), sutun[3 + GunAdi.Count] + (SaatAdi.Count + 8)].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = false;
            sayfa.Cells.Range["B" + 8, sutun[3 + GunAdi.Count] + 8].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;
            sayfa.Cells.Range["B" + (SaatAdi.Count + 8), sutun[3 + GunAdi.Count] + (SaatAdi.Count + 8)].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;
            sayfa.Cells.Range["B" + (SaatAdi.Count + 8), sutun[3 + GunAdi.Count] + (SaatAdi.Count + 8)].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
            int maaskarsiligi = 0, dersyuku = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = GunAdi.Count * SaatAdi.Count;
            label2.Text = "HAZIRLANIYOR";
            for (int i = 0; i < GunAdi.Count; i++)
            {
                for (int j = 0; j < SaatAdi.Count / 2; j++)
                {
                    progressBar1.Value++;
                    DersDagilimi dd = new DersDagilimi();
                    dd.BolumDersDonemi.Ogretimelemani.Kodu = Convert.ToInt32(comboBox_OE.SelectedValue);
                    dd.Gunu.Kodu = GunId[i];
                    dd.Saati.Kodu = Saatid[j];
                    dd = ddvt.ElProgramiListele(dd);
                    if (dd.BolumDersDonemi.Dersi.Adi != "")
                    {
                        maaskarsiligi = dd.BolumDersDonemi.Ogretimelemani.Maasi;
                        sayfa.Cells.Range[sutun[4 + i] + (8 + 2 * j), sutun[4 + i] + (8 + 2 * j)].Value = dd.BolumDersDonemi.Dersi.Adi;
                        sayfa.Cells.Range[sutun[4 + i] + (9 + 2 * j), sutun[4 + i] + (9 + 2 * j)].Value = dd.BolumDersDonemi.Bolumu.Kadi + " " + dd.BolumDersDonemi.Donemi.Sinifi.Adi + "/" + dd.BolumDersDonemi.Donemi.Subesi.Adi + " SINIFI-" + dd.Derslik.Adi;
                        dersyuku++;
                        sayfa.Cells.Range[sutun[4 + i] + (8 + 2 * j), sutun[4 + i] + (8 + 2 * j)].HorizontalAlignment = sayfa.Cells.Range[sutun[4 + i] + (11 + 2 * j), sutun[4 + i] + (10 + 2 * j)].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sayfa.Cells.Range[sutun[4 + i] + (8 + 2 * j), sutun[4 + i] + (8 + 2 * j)].VerticalAlignment = sayfa.Cells.Range[sutun[4 + i] + (11 + 2 * j), sutun[4 + i] + (10 + 2 * j)].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    }
                }
                for (int j = SaatAdi.Count / 2; j < SaatAdi.Count; j++)
                {
                    progressBar1.Value++;
                    DersDagilimi dd = new DersDagilimi();
                    dd.BolumDersDonemi.Ogretimelemani.Kodu = Convert.ToInt32(comboBox_OE.SelectedValue);
                    dd.Gunu.Kodu = GunId[i];
                    dd.Saati.Kodu = Saatid[j];
                    dd = ddvt.ElProgramiListele(dd);
                    if (dd.BolumDersDonemi.Dersi.Adi != "")
                    {
                        sayfa.Cells.Range[sutun[4 + i] + (9 + 2 * j), sutun[4 + i] + (9 + 2 * j)].Value = dd.BolumDersDonemi.Dersi.Adi;
                        sayfa.Cells.Range[sutun[4 + i] + (10 + 2 * j), sutun[4 + i] + (10 + 2 * j)].Value = dd.BolumDersDonemi.Bolumu.Kadi + " " + dd.BolumDersDonemi.Donemi.Sinifi.Adi + "/" + dd.BolumDersDonemi.Donemi.Subesi.Adi + " SINIFI-" + dd.Derslik.Adi;
                        dersyuku++;
                        sayfa.Cells.Range[sutun[4 + i] + (9 + 2 * j), sutun[4 + i] + (9 + 2 * j)].HorizontalAlignment = sayfa.Cells.Range[sutun[4 + i] + (11 + 2 * j), sutun[4 + i] + (11 + 2 * j)].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sayfa.Cells.Range[sutun[4 + i] + (9 + 2 * j), sutun[4 + i] + (9 + 2 * j)].VerticalAlignment = sayfa.Cells.Range[sutun[4 + i] + (11 + 2 * j), sutun[4 + i] + (11 + 2 * j)].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    }
                }
                sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 9), "D" + (SaatAdi.Count * 2 + 9)].MergeCells = true;
                sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 10), "D" + (SaatAdi.Count * 2 + 10)].MergeCells = true;
                sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 9), "D" + (SaatAdi.Count * 2 + 9)].Value = "MAAŞ KARŞ.DERS YÜK:";
                sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 10), "D" + (SaatAdi.Count * 2 + 10)].Value = "NORMAL ÖĞRETİM ÜCRET KARŞILIĞI";
                sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 9), "I" + (SaatAdi.Count * 2 + 9)].Borders.LineStyle = sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 10), "E" + (SaatAdi.Count * 2 + 10)].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
                sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 9), "I" + (SaatAdi.Count * 2 + 9)].HorizontalAlignment = sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 10), "D" + (SaatAdi.Count * 2 + 10)].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 9), "I" + (SaatAdi.Count * 2 + 9)].VerticalAlignment = sayfa.Cells.Range["A" + (SaatAdi.Count * 2 + 10), "D" + (SaatAdi.Count * 2 + 10)].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                sayfa.Cells.Range["E" + (SaatAdi.Count * 2 + 9), "E" + (SaatAdi.Count * 2 + 9)].Value = maaskarsiligi;
                sayfa.Cells.Range["E" + (SaatAdi.Count * 2 + 9), "F" + (SaatAdi.Count * 2 + 9)].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
                sayfa.Cells.Range["E" + (SaatAdi.Count * 2 + 9), "F" + (SaatAdi.Count * 2 + 9)].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                sayfa.Cells.Range["F" + (SaatAdi.Count * 2 + 9), "F" + (SaatAdi.Count * 2 + 9)].Value = "ÜCR. DERSYÜK:";
                sayfa.Cells.Range["G" + (SaatAdi.Count * 2 + 9), "G" + (SaatAdi.Count * 2 + 9)].Value = dersyuku - maaskarsiligi;
                sayfa.Cells.Range["H" + (SaatAdi.Count * 2 + 9), "H" + (SaatAdi.Count * 2 + 9)].Value = "TOPLAM:";
                sayfa.Cells.Range["I" + (SaatAdi.Count * 2 + 9), "I" + (SaatAdi.Count * 2 + 9)].Value = "T/U:" + dersyuku;
                sayfa.Cells.Range["E" + (SaatAdi.Count * 2 + 10), "E" + (SaatAdi.Count * 2 + 10)].Value = dersyuku - maaskarsiligi;
                sayfa.Cells.Range["F" + (SaatAdi.Count * 2 + 9), "H" + (SaatAdi.Count * 2 + 9)].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = false;
                sayfa.Cells.Range["F" + (SaatAdi.Count * 2 + 9), "H" + (SaatAdi.Count * 2 + 9)].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = false;
                sayfa.Cells.Range["A6", "Z50"].RowHeight = 13;
                sayfa.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                sayfa.PageSetup.Zoom = 79;
                label2.Text = "HAZIR";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Excel.Application uygulama;
            Excel.Workbook kitap;
            Excel.Worksheet sayfa;
            ElprogramiHazirla(out uygulama, out kitap, out sayfa);
            if (File.Exists(@"" + Application.UserAppDataPath + "\\" + comboBox_OE.Text + " El programı.xls"))
            {
                File.Delete(@"" + Application.UserAppDataPath + "\\" + comboBox_OE.Text + " El programı.xls");
                sayfa.SaveAs(@"" + Application.UserAppDataPath + "\\" + comboBox_OE.Text + " El programı.xls", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive);
            }
            else
            {
                sayfa.SaveAs(@"" + Application.UserAppDataPath + "\\" + comboBox_OE.Text + " El programı.xls", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive);
            }
            uygulama.Quit();
            System.Diagnostics.Process.Start(Application.UserAppDataPath);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupboxislemlerigorunmezyap();
            groupBox_Bolum_Ders_Programi.Visible = true;
           
            
        }

        private void groupboxislemlerigorunmezyap()
        {
            groupBox_derslik_programı.Visible = groupBox_Bolum_Ders_Programi.Visible = groupBox_OE_el_programi.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupboxislemlerigorunmezyap();
            groupBox_OE_el_programi.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            groupboxislemlerigorunmezyap();
            groupBox_derslik_programı.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum2.SelectedValue);
            bdd.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube2.SelectedValue);
            bdd.Donemi.Donemi.Kodu = Convert.ToInt32(comboBox_Donem2.SelectedValue);
            sinifId = bddvt.KayıtliBolumSiniflariListele(bdd);
            SinifAdi = bddvt.KayıtliBolumSiniflariListele2(bdd);    
            if (SinifAdi.Count != 0)
            {
                Excel.Application uygulama;
                Excel.Workbook kitap;
                Excel.Worksheet sayfa;
                BolumDersProgramiHazirla(out uygulama, out kitap, out sayfa);
                if (File.Exists(@"" + Application.UserAppDataPath + "\\" + comboBox_Bolum2.Text +" programı.xls"))
                {
                    File.Delete(@"" + Application.UserAppDataPath + "\\" + comboBox_Bolum2.Text +" programı.xls");
                    sayfa.SaveAs(@"" + Application.UserAppDataPath + "\\" + comboBox_Bolum2.Text + " programı.xls", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive);
                }
                else
                {
                    sayfa.SaveAs(@"" + Application.UserAppDataPath + "\\" + comboBox_Bolum2.Text + " programı.xls", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive);
                }
                uygulama.Quit();
                System.Diagnostics.Process.Start(Application.UserAppDataPath);
            }
            else
            {
                MessageBox.Show("Aradığınız kriterlere uygun hazırlanmış ders kaydı bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excel.Application uygulama;
            Excel.Workbook kitap;
            Excel.Worksheet sayfa;
            ElprogramiHazirla(out uygulama, out kitap, out sayfa);
            uygulama.Visible = true;
            sayfa.PrintPreview();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bdd.Bolumu.Kodu = Convert.ToInt32(comboBox_Bolum2.SelectedValue);
            bdd.Donemi.Subesi.Kodu = Convert.ToInt32(comboBox_Sube2.SelectedValue);
            bdd.Donemi.Donemi.Kodu = Convert.ToInt32(comboBox_Donem2.SelectedValue);
            sinifId = bddvt.KayıtliBolumSiniflariListele(bdd);
            SinifAdi = bddvt.KayıtliBolumSiniflariListele2(bdd);
            if (SinifAdi.Count != 0)
            {
                Excel.Application uygulama;
                Excel.Workbook kitap;
                Excel.Worksheet sayfa;
                BolumDersProgramiHazirla(out uygulama, out kitap, out sayfa);
                uygulama.Visible = true;
                sayfa.PrintPreview();
            }
            else
            {
                MessageBox.Show("Aradığınız kriterlere uygun hazırlanmış ders kaydı bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            File.Delete(@"" + Application.UserAppDataPath + "\\" + comboBox_OE.Text + " El programı.xls");
            Ping ping = new Ping(); 
            PingReply pingDurumu = ping.Send(IPAddress.Parse("64.15.112.45"));
            if (pingDurumu.Status == IPStatus.Success)
            {
                MailMessage ePosta = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                Excel.Application uygulama;
                Excel.Workbook kitap;
                Excel.Worksheet sayfa;
                ElprogramiHazirla(out uygulama, out kitap, out sayfa);
                sayfa.SaveAs(@"" + Application.UserAppDataPath + "\\" + comboBox_OE.Text + " El programı.xls", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, Type.Missing, Excel.XlSaveAsAccessMode.xlShared);
                uygulama.Workbooks.Close();
                uygulama.Quit();
                label2.Text = "Mail Gönderiliyor";
                ePosta.From = new MailAddress("programmycourses@gmail.com");
                OgretimElemani oe = new OgretimElemani();
                oe.Kodu = Convert.ToInt32(comboBox_OE.SelectedValue);
                OgretimElemaniVeritabani oevt = new OgretimElemaniVeritabani();
                oe = oevt.Bİlgigetir(oe);
                ePosta.To.Add(oe.Mail);
                ePosta.Attachments.Add(new Attachment(Application.UserAppDataPath+"\\"+comboBox_OE.Text+" El programı.xls"));
                ePosta.Subject = yil+" El Programı";
                ePosta.Body = yil + " Eğitim-Öğretim  Yılı  II-VI.Y.Y  haftalık  ders  programınız  aşağıya çıkarılmıştır. 2547   sayılı   kanun  ve  diğer   mevzuat  ile akademik takvime  bağlı  olarak  eğitim-öğretim hususunda gerekli dikkat ve titizliğin gösterilmesini rica eder, başarılı bir eğitim-öğretim yılı dilerim.";
                smtp.Credentials = new System.Net.NetworkCredential("programmycourses@gmail.com", "mPy 2015");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                object userState = ePosta;
                try
                {
                    smtp.Send(ePosta);
                    label2.Text="Gönderildi";
                }
                catch (SmtpException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
                }
                ePosta.Dispose();
            }
            else
            {
                MessageBox.Show("İnternet bağlantınızı kontrol ederek tekrar deneyiniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void button2_DkP_Click(object sender, EventArgs e)
        {
            Excel.Application uygulama;
            Excel.Workbook kitap;
            Excel.Worksheet sayfa;
            DerslikProgramiHazirla(out uygulama, out kitap, out sayfa);
            uygulama.Visible = true;
        }

        private void DerslikProgramiHazirla(out Excel.Application uygulama, out Excel.Workbook kitap, out Excel.Worksheet sayfa)
        {
            for (int i = 65; i < 91; i++)
            {
                sutun[i - 65] = Convert.ToChar(i).ToString();
            }
            GunAdi = gvt.GunListele();
            GunId = gvt.GunIdListele();
            SaatAdi = svt.saatadilistele();
            Saatid = svt.SaatIdListele();
            object misValue = System.Reflection.Missing.Value;
            uygulama = new Excel.Application();
            kitap = uygulama.Workbooks.Add(misValue);
            sayfa = (Excel.Worksheet)kitap.Worksheets.get_Item(1);
            sayfa.Cells.Range["B4", "B4"].Value = "Derslik Adı: ";
            sayfa.Cells.Range["D4", "D4"].Value = comboBox_Derslik.Text;
            sayfa.Cells.Range["B6", "B7"].MergeCells = sayfa.Cells.Range["C6", "C7"].MergeCells = sayfa.Cells.Range["D6", "D7"].MergeCells = sayfa.Cells.Range["B8", "B" + (SaatAdi.Count * 2 + 7)].MergeCells = true;
            sayfa.Cells.Range["C6", "C7"].Value = "D.N";
            sayfa.Cells.Range["D6", "D7"].Value = "Saat";
            sayfa.Cells.Range["B8", "B" + (SaatAdi.Count * 2 + 7)].Value = "N\nO\nR\nM\nA\nL\n\n\nÖ\nĞ\nR\nE\nT\nİ\nM";
            sayfa.Cells.Range["A1", "AA100"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            sayfa.Cells.Range["A1", "AA100"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            for (int i = 0; i < SaatAdi.Count; i++)
            {
                sayfa.Cells.Range["C" + (i * 2 + 8), "C" + (i * 2 + 9)].MergeCells = sayfa.Cells.Range["D" + (i * 2 + 8), "D" + (i * 2 + 9)].MergeCells = true;
                sayfa.Cells.Range["C" + (i * 2 + 8), "C" + (i * 2 + 9)].Value = i + 1;
                sayfa.Cells.Range["D" + (i * 2 + 8), "D" + (i * 2 + 9)].Value = SaatAdi[i];
            }
            for (int i = 0; i < GunAdi.Count; i++)
            {
                sayfa.Cells.Range[sutun[i + 4] + 6, sutun[i + 4] + 7].MergeCells = true;
                sayfa.Cells.Range[sutun[i + 4] + 6, sutun[i + 4] + 7].Value = GunAdi[i];
                sayfa.Cells.Range[sutun[i + 4] + 6, sutun[i + 4] + 7].ColumnWidth = 31;
            }
            sayfa.Cells.Range["B6", sutun[GunAdi.Count + 3] + (SaatAdi.Count * 2 + 7)].Borders.LineStyle = Excel.XlLineStyle.xlDouble;
            for (int i = 0; i < GunAdi.Count; i++)
            {
                for (int j = 0; j < SaatAdi.Count; j++)
                {
                    sayfa.Cells.Range[sutun[i + 4] +(j*2+ 8), sutun[i + 4] +(j*2+9)].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = false;
                    DersDagilimi dd = new DersDagilimi();
                    dd.Derslik.Kodu = Convert.ToInt32(comboBox_Derslik.SelectedValue);
                    dd.Gunu.Kodu = GunId[i];
                    dd.Saati.Kodu = Saatid[j];
                    dd = ddvt.DerslikDagilimiListele(dd);
                    if (dd.BolumDersDonemi.Ogretimelemani.Kadi!="")
                    {
                        sayfa.Cells.Range[sutun[i + 4] + (j * 2 + 8), sutun[i + 4] + (j * 2 + 8)].Value = dd.BolumDersDonemi.Dersi.Adi;
                        sayfa.Cells.Range[sutun[i + 4] + (j * 2 + 9), sutun[i + 4] + (j * 2 + 9)].Value = dd.BolumDersDonemi.Bolumu.Kadi + " " + dd.BolumDersDonemi.Donemi.Sinifi.Adi + "/" + dd.BolumDersDonemi.Donemi.Subesi.Adi + " Sınıfı - " + dd.BolumDersDonemi.Ogretimelemani.Kadi;
                    }
                }
            }
            sayfa.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            sayfa.PageSetup.Zoom = 70;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Excel.Application uygulama;
            Excel.Workbook kitap;
            Excel.Worksheet sayfa;
            DerslikProgramiHazirla(out uygulama, out kitap, out sayfa);
            if (File.Exists(Application.UserAppDataPath + "\\" + comboBox_Derslik.Text +".xls"))
            {
                File.Delete(Application.UserAppDataPath + "\\" + comboBox_Derslik.Text +".xls");
                sayfa.SaveAs(@"" + Application.UserAppDataPath + "\\" + comboBox_Derslik.Text + ".xls", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive);
            }
            else
            {
                sayfa.SaveAs(@"" + Application.UserAppDataPath + "\\" + comboBox_Derslik.Text + ".xls", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive);
            }
            uygulama.Quit();
            System.Diagnostics.Process.Start(Application.UserAppDataPath);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Excel.Application uygulama;
            Excel.Workbook kitap;
            Excel.Worksheet sayfa;
            DerslikProgramiHazirla(out uygulama, out kitap, out sayfa);
            uygulama.Visible = true;
            sayfa.PrintPreview();
        }

        private void dışaAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yedekAl();
           
        }

        private void yedekAl()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                IslemlerVeritabani itv = new IslemlerVeritabani();
                try
                {
                    itv.YedekAl(folder.SelectedPath);
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void içeAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "programmycourses|*.pmc";
            if (open.ShowDialog()==DialogResult.OK)
            {
                IslemlerVeritabani itv = new IslemlerVeritabani();
                try
                {
                    itv.yedekekle(open.FileName);
                    MessageBox.Show("İçeri aktarma işlemi başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.None);
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel10_MouseMove(object sender, MouseEventArgs e)
        {
            
           panel10.Left = konum;
        }
        private void tabPage2_MouseLeave(object sender, MouseEventArgs e)
        {
            panel10.Left = konum + 155;
        }

        private void tabPage1_MouseLeave(object sender, EventArgs e)
        {     
        }
        private void tabPage1_MouseLeave(object sender, MouseEventArgs e)
        {
            panel9.Left = konum + 158;
        }
        private void panel9_MouseMove(object sender, MouseEventArgs e)
        {
            panel9.Left = konum;
        }
        private void button_DersprogramiSil_Click(object sender, EventArgs e)
        {
            DersDagilimi dd = DersProgramiIcinBilgileriAl();
            DialogResult cevap = MessageBox.Show("Belirtilen sınıfa ait ders programı kaldırılsın mı?\n\nBu işlem geri Alınamaz.","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (cevap ==DialogResult.Yes)
            {
                ddvt.Sil(dd);
                MessageBox.Show("Belirtilen sınıfa ait ders programı kaldırıldı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.None);
                //DersprogramiKontrolu();
                //Dersprogramiasamasi();  
                groupBox1.Controls.Clear();
            }
        }

        private void button_DersProgramiGoster_Click(object sender, EventArgs e)
        {
            DersProgramiGoster DPG = new DersProgramiGoster();
            DPG.BolumKodu = Convert.ToInt32(comboBox_Bolum.SelectedValue);
            DPG.SinifKodu = Convert.ToInt32(comboBox_Sınıf.SelectedValue);
            DPG.SubeKodu = Convert.ToInt32(comboBox_Sube.SelectedValue);
            DPG.DonemKodu = Convert.ToInt32(comboBox_ADonem.SelectedValue);
            DPG.GunAdi = GunAdi;
            DPG.GunID = GunId;
            DPG.SaatAdi = SaatAdi;
            DPG.SaatID = Saatid;
            DPG.Bilgi = label13.Text + " \t" + label14.Text;
            DPG.Show();
        }

        private void radio_no_CheckedChanged(object sender, EventArgs e)
        {
   
        }
        private void radio_io_CheckedChanged(object sender, EventArgs e)
        {
            ogrenimSaatId.Clear();
            ogrenimDurum = false;
            Dersprogramiasamasi();
            DersprogramiKontrolu();
        }
        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
        
            bddvt.DSDSifirla();

        }
        private void button_DDTemizle_Click(object sender, EventArgs e)
        {
            DialogResult d=MessageBox.Show("Hazırlamış olduğunuz programlar silinecek \nYedek almak istiyormusunuz","Uyarı",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (d == DialogResult.No)
                ddvt.tabloSifirla();
            else if (d == DialogResult.Yes)
            {
                yedekAl();
                ddvt.tabloSifirla();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void radio_NO_CheckedChanged_1(object sender, EventArgs e)
        {
            ogrenimTuru = false;
        }

        private void radio_IO_CheckedChanged_1(object sender, EventArgs e)
        {
            ogrenimTuru = true;
        }

        private void radio_PHIO_CheckedChanged(object sender, EventArgs e)
        {
            programHazirlaOgrenimTuru = true;
        }

        private void radio_PHNO_CheckedChanged(object sender, EventArgs e)
        {
            programHazirlaOgrenimTuru = false;
        }

        private void Giris_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            yardim y = new yardim();
            y.Show();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yardim y = new yardim();
            y.Show();
        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button_yardim_Click(object sender, EventArgs e)
        {
            yardim y = new yardim();
            y.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            yardim y = new yardim();
            y.Show();
        }
    }
}
