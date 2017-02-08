using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhiEvranDersProgrami
{
    public class Saat : IVarlik
    {
        private int kodu;

        public int Kodu
        {
            get { return kodu; }
            set { kodu = value; }
        }
        private string araligi;

        public string Araligi
        {
            get { return araligi; }
            set { araligi = value; }
        }
        private bool ogrenimTuru;

        public bool OgrenimTuru
        {
            get { return ogrenimTuru; }
            set { ogrenimTuru = value; }
        }
        public Saat()
        {
            this.Araligi = "";
            this.Kodu = 0;
            this.OgrenimTuru = false;
        }
    }
}
