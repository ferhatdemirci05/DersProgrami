using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AhiEvranDersProgrami
{
    class DersDagilimVeritabani:TemelVeritabani
    {
        public override void Ekle(IVarlik varlik)
        {
            throw new NotImplementedException();
        }

        public override void Sil(IVarlik varlik)
        {
            throw new NotImplementedException();
        }

        public override void Guncelle(IVarlik varlik)
        {
            throw new NotImplementedException();
        }
        public override DataTable Listele(IVarlik varlik)
        {
            throw new NotImplementedException();
        }
        public override DataTable Listele()
        {
            throw new NotImplementedException();
        }
        internal object DersListele(DersDagilimi dd)
        {
            Baglan();
            komut = new SqlCommand("usp_GunveSaateGoreDersListele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@BolumKodu",dd.BolumDersDonemi.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@SinifKodu",dd.BolumDersDonemi.Donemi.Sinifi.Kodu);
            komut.Parameters.AddWithValue("SubeKodu",dd.BolumDersDonemi.Donemi.Subesi.Kodu);
            komut.Parameters.AddWithValue("@Donemi",dd.BolumDersDonemi.Donemi.Donemi.Kodu);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }
        internal object DerslikListele(DersDagilimi dd)
        {
            Baglan();
            komut = new SqlCommand("usp_GunveSaateGoreDerslikListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@GunKodu", dd.Gunu.Kodu);
            komut.Parameters.AddWithValue("@SaatKodu", dd.Saati.Kodu);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }
        internal void DersDagilimiEkle(DersDagilimi dd, List<string> DersId, List<int> Saatid, List<string> DerslikId ,List<int> GunId)
        {
            int g = 0, s = 0;
            for (int i = 0; i < DersId.Count; i++)
            {
                Baglan();
                komut = new SqlCommand("usp_DersDagilimiEkle",baglanti);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@Gun",GunId[g]);
                komut.Parameters.AddWithValue("@Saat",Saatid[s]);
                komut.Parameters.AddWithValue("@Bolum",dd.BolumDersDonemi.Bolumu.Kodu);
                komut.Parameters.AddWithValue("@DersAdi",DersId[i]);
                komut.Parameters.AddWithValue("@Sinif",dd.BolumDersDonemi.Donemi.Sinifi.Kodu);
                komut.Parameters.AddWithValue("@Sube",dd.BolumDersDonemi.Donemi.Subesi.Kodu);
                komut.Parameters.AddWithValue("@Donem",dd.BolumDersDonemi.Donemi.Donemi.Kodu);
                komut.Parameters.AddWithValue("@DerslikAdi",DerslikId[i]);
                komut.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Dispose();
                s++;
                if (s==8)
                {
                    s = 0;
                    g++;
                }
            }
        }

        internal string[] dersdagilimigetir(DersDagilimi dd, BolumDersDonem bdd)
        {
            string[] dersdagilimi = { "", "", "" };
            Baglan();
            komut = new SqlCommand("usp_DersDağilimiGetir", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum", bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Sinif", bdd.Donemi.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@Sube", bdd.Donemi.Subesi.Kodu);
            komut.Parameters.AddWithValue("@Donem", bdd.Donemi.Donemi.Kodu);
            komut.Parameters.AddWithValue("@Gun", dd.Gunu.Kodu);
            komut.Parameters.AddWithValue("@Saat", dd.Saati.Kodu);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                dersdagilimi[0]= okuyucu["DERS"].ToString();
                dersdagilimi[1] = okuyucu["OE"].ToString();
                dersdagilimi[2] = okuyucu["DERSLIK"].ToString();
            }
            return dersdagilimi;
        }
    }
}
