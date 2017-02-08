using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhiEvranDersProgrami
{
    public class Ders : IVarlik
    {
        private int kodu;

        public int Kodu
        {
            get { return kodu; }
            set { kodu = value; }
        }
        private string adi;

        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }
        private int teori;

        public int Teori
        {
            get { return teori; }
            set { teori = value; }
        }
        private int uygulama;

        public int Uygulama
        {
            get { return uygulama; }
            set { uygulama = value; }
        }

        public Ders()
        {
            this.Adi = "";
            this.Kodu = 0;
            this.Teori = 0  ;
            this.Uygulama = 0;
            this.Kredi = 0;
            this.Akts = 0;
        }

        private int kredi;

        public int Kredi
        {
            get { return kredi; }
            set { kredi = value; }
        }
        private int akts;

        public int Akts
        {
            get { return akts; }
            set { akts = value; }
        }
    }
}
