using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhiEvranDersProgrami
{
    public class BolumDersDonem : IVarlik
    {
        private int kodu;

        public int Kodu
        {
            get { return kodu; }
            set { kodu = value; }
        }
        private Bolum bolumu;

        public Bolum Bolumu
        {
            get { return bolumu; }
            set { bolumu = value; }
        }
        private Ders dersi;

        public Ders Dersi
        {
            get { return dersi; }
            set { dersi = value; }
        }
        private Donem donemi;

        public Donem Donemi
        {
            get { return donemi; }
            set { donemi = value; }
        }

        public BolumDersDonem()
        {
            this.Bolumu = new Bolum();
            this.Dersi = new Ders();
            this.Donemi = new Donem();
            this.Kodu = 0;
            this.Ogretimelemani = new OgretimElemani();
        }

        private OgretimElemani ogretimelemani;

        public OgretimElemani Ogretimelemani
        {
            get { return ogretimelemani; }
            set { ogretimelemani = value; }
        }
    }
}
