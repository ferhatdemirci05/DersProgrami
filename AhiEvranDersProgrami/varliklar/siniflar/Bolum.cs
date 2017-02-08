using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhiEvranDersProgrami
{
    public class Bolum : IVarlik
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
        private string kadi;

        public string Kadi
        {
            get { return kadi; }
            set { kadi = value; }
        }

        public Bolum()
        {
            this.Adi = "";
            this.Kadi = "";
            this.Kodu = 0;
            this.Baskani = 0;
        }

        private int baskani;

        public int Baskani
        {
            get { return baskani; }
            set { baskani = value; }
        }
    }
}
