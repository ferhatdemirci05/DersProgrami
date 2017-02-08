using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhiEvranDersProgrami
{
    public class Donemi : IVarlik
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

        public Donemi()
        {
            this.Adi = "";
            this.Kodu = 0;
            
        }
    }
}
