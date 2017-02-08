using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhiEvranDersProgrami
{
    public class DersDagilimi : IVarlik
    {
        private int kodu;

        public int Kodu
        {
            get { return kodu; }
            set { kodu = value; }
        }
        private Gun gunu;

        public Gun Gunu
        {
            get { return gunu; }
            set { gunu = value; }
        }
        private Saat saati;

        public Saat Saati
        {
            get { return saati; }
            set { saati = value; }
        }
        private BolumDersDonem bolumDersDonemi;

        public BolumDersDonem BolumDersDonemi
        {
            get { return bolumDersDonemi; }
            set { bolumDersDonemi = value; }
        }
        private Derslik derslik;

        public Derslik Derslik
        {
            get { return derslik; }
            set { derslik = value; }
        }

        public DersDagilimi()
        {
            this.BolumDersDonemi = new BolumDersDonem();
            this.Derslik = new Derslik();
            this.Gunu = new Gun();
            this.Kodu = 0;
            this.Saati = new Saat();
            
        }
    }
}
