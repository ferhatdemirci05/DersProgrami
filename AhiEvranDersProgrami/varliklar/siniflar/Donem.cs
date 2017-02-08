using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhiEvranDersProgrami
{
    public class Donem : IVarlik
    {
        private int kodu;

        public int Kodu
        {
            get { return kodu; }
            set { kodu = value; }
        }
        private Sinif sinifi;

        public Sinif Sinifi
        {
            get { return sinifi; }
            set { sinifi = value; }
        }
        private Sube subesi;

        public Sube Subesi
        {
            get { return subesi; }
            set { subesi = value; }
        }
        private Donemi donemi;

        public Donemi Donemi
        {
            get { return donemi; }
            set { donemi = value; }
        }

        public Donem()
        {
            this.Donemi = new Donemi();//Güz,Bahar,Yaz
            this.Kodu = 0;
            this.Sinifi = new Sinif();//1,2,3,4
            this.Subesi = new Sube();//A,B,C,D
        }
    }
}
