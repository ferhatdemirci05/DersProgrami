using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhiEvranDersProgrami
{
    public class OgretimElemani : IVarlik
    {
        private int kodu;

        public int Kodu
        {
            get { return kodu; }
            set { kodu = value; }
        }
        private string kadi;

        public string Kadi
        {
            get { return kadi; }
            set { kadi = value; }
        }
        private string adi;

        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }
        private string soyadi;

        public string Soyadi
        {
            get { return soyadi; }
            set { soyadi = value; }
        }
        private Unvan unvani;

        public Unvan Unvani
        {
            get { return unvani; }
            set { unvani = value; }
        }
        private DateTime dTarihi;

        public DateTime DTarihi
        {
            get { return dTarihi; }
            set { dTarihi = value; }
        }
        private string sTel;

        public string STel
        {
            get { return sTel; }
            set { sTel = value; }
        }
        private string cTel;

        public string CTel
        {
            get { return cTel; }
            set { cTel = value; }
        }
        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        private int maasi;

        public int Maasi
        {
            get { return maasi; }
            set { maasi = value; }
        }

        public OgretimElemani()
        {
            this.Adi = "";
            this.CTel = "";
            this.DTarihi= new DateTime();
            this.Kadi = "";
            this.Kodu = 0;
            this.Maasi = 0;
            this.Mail = "";
            this.Soyadi = "";
            this.STel = "";
            this.Unvani = new Unvan();
        }
    }
}
