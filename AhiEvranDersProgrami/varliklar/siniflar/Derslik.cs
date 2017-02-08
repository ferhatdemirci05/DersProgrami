using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhiEvranDersProgrami
{
    public class Derslik : IVarlik
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

        public Derslik()
        {
            this.Adi = "";
            this.Kodu = 0;
        }
    }
}
