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
    public partial class DersProgramiGoster : Form
    {
        public DersProgramiGoster()
        {
            InitializeComponent();
        }
        public int BolumKodu, SinifKodu, SubeKodu, DonemKodu;
        public string Bilgi;
        public List<string> GunAdi = new List<string>();
        public List<int> GunID = new List<int>();
        public List<string> SaatAdi = new List<string>();
        public List<int> SaatID = new List<int>();
        List<string> DersAdi = new List<string>();
        List<string> DerslikAdi = new List<string>();
       
        DersDagilimVeritabani ddvt = new DersDagilimVeritabani();
        private void DersProgramiGoster_Load(object sender, EventArgs e)
        {
            
            label_Bilgi.Text = Bilgi+" Ders Programı ön izlemesi";
            int x, y;
            x = 145; y = 30;
            for (int i = 0; i < GunAdi.Count; i++)
            {
                Label l = new Label();
                l.Top = y;
                l.Left = x;
                l.Width = 100;
                l.Text = GunAdi[i].ToString();
                l.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                l.Name = "Label_" + GunAdi[i];
                this.Controls.Add(l);
                x += 220;
            }
            x = 105; y = 57;
            for (int i = 0; i < GunAdi.Count; i++)
            {
                Label l = new Label();
                l.Top = y;
                l.Left = x;
                l.Width = 100;
                l.Text = "Dersler";
                l.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.Controls.Add(l);
                x += 128;
                Label l2 = new Label();
                l2.Top = y;
                l2.Left = x;
                l2.Width = 90;
                l2.Text = "Derslik   |";
                l2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.Controls.Add(l2);
                x += 102;
            }
            x = 10; y = 85;
            for (int i = 0; i < SaatAdi.Count; i++)
            {
                Label l = new Label();
                l.Top = y;
                l.Left = x;
                l.Width = 50;
                l.Text = SaatAdi[i].ToString();
                l.Name = "Label_" + SaatAdi[i];
                l.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.Controls.Add(l);
                y += 30;
            }
            x += 60; y = 82;
            for (int j = 0; j < GunID.Count; j++)
            {
                for (int i = 0; i < SaatID.Count; i++)
                {
                    DersDagilimi dd = new DersDagilimi();
                    dd = DersProgramiBilgiAl();
                    Label l = new Label();
                    l.Top = y;
                    l.Left = x;
                    l.Width = 150;
                    l.Name = "Label_Ders"+((j * SaatID.Count) + (i + 1));
                    dd.Gunu.Kodu = GunID[j];
                    dd.Saati.Kodu = SaatID[i];
                    dd = ddvt.DersDagilimdanDersAl(dd);
                    if (dd.BolumDersDonemi.Dersi.Kodu != 0)
                    {
                        l.Text = dd.BolumDersDonemi.Dersi.Adi;
                    }
                    else
                    {
                        l.Text = "---------------------------";
                    }
                    this.Controls.Add(l);
                    y += 30;
                }
                x += 160;y = 82;
                for (int i = 0; i < SaatID.Count; i++)
                {
                    DersDagilimi dd = new DersDagilimi();
                    dd = DersProgramiBilgiAl();
                    Label l = new Label();
                    l.Top = y;
                    l.Left = x;
                    l.Width = 60;
                    l.Name = "Label_Derslik" + j + SaatID[i];
                    dd.Gunu.Kodu = GunID[j];
                    dd.Saati.Kodu = SaatID[i];
                    dd = ddvt.DersDagilimdanDersAl(dd);

                    if (dd.Derslik.Kodu != 0)
                    {
                        l.Text = dd.Derslik.Adi;
                    }
                    else
                    {
                        l.Text = "----";
                    }
                    
                    this.Controls.Add(l);
                    y += 30;
                }
                y = 82; x += 70;
            }
        }

        private DersDagilimi DersProgramiBilgiAl()
        {
            DersDagilimi dd = new DersDagilimi();
            dd.BolumDersDonemi.Bolumu.Kodu = BolumKodu;
            dd.BolumDersDonemi.Donemi.Sinifi.Kodu = SinifKodu;
            dd.BolumDersDonemi.Donemi.Subesi.Kodu = SubeKodu;
            dd.BolumDersDonemi.Donemi.Donemi.Kodu = DonemKodu;
            return dd;
        }
    }
}
