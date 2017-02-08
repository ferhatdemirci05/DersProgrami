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
            DersDagilimi dd = (DersDagilimi)varlik;
            Baglan();
            komut = new SqlCommand("usp_DersDagilimiKaldir",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum",dd.BolumDersDonemi.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Sinif",dd.BolumDersDonemi.Donemi.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@Sube",dd.BolumDersDonemi.Donemi.Subesi.Kodu);
            komut.Parameters.AddWithValue("@Donem",dd.BolumDersDonemi.Donemi.Donemi.Kodu);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
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
        internal void DersDagilimiEkle(DersDagilimi dd, List<string> DersId, List<int> Saatid, List<string> DerslikId, List<int> GunId)
        {
            int g=0,s=0;
            for (int i = 0; i < DerslikId.Count; i++)
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
                if (s==Saatid.Count)
                {
                    g++;
                    s = 0;
                    if (g==GunId.Count)
                    {
                        g = 0;
                    }
                }
            }
        }

        internal string[] dersdagilimigetir(DersDagilimi dd, BolumDersDonem bdd)
        {
            string[] dersdagilimi = { "", "", "" };
            Baglan();
            komut = new SqlCommand("usp_DersDagilimiGetir", baglanti);
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
            baglanti.Close();
            baglanti.Dispose();
            return dersdagilimi;
        }

        internal DersDagilimi ElProgramiListele(DersDagilimi dd)
        {
            Baglan();
            komut = new SqlCommand("usp_ElProgramDagitim",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Saat",dd.Saati.Kodu);
            komut.Parameters.AddWithValue("@Gun",dd.Gunu.Kodu);
            komut.Parameters.AddWithValue("@OE",dd.BolumDersDonemi.Ogretimelemani.Kodu);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                dd.BolumDersDonemi.Dersi.Adi = okuyucu["D_Adi"].ToString();
                dd.BolumDersDonemi.Bolumu.Kadi = okuyucu["B_KAdi"].ToString();
                dd.BolumDersDonemi.Donemi.Sinifi.Adi = okuyucu["Sf_Adi"].ToString();
                dd.BolumDersDonemi.Donemi.Subesi.Adi = okuyucu["Sb_Adi"].ToString();
                dd.Derslik.Adi = okuyucu["Dk_Adi"].ToString();
                dd.BolumDersDonemi.Ogretimelemani.Maasi = Convert.ToInt32(okuyucu["OE_Maas"].ToString());
            }
            baglanti.Close();
            baglanti.Dispose();
            return dd;
        }

        internal DersDagilimi DerslikDagilimiListele(DersDagilimi dd)
        {
            Baglan();
            komut = new SqlCommand("usp_DerslikDagilimiListele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Gun",dd.Gunu.Kodu);
            komut.Parameters.AddWithValue("@Saat",dd.Saati.Kodu);
            komut.Parameters.AddWithValue("@Derslik",dd.Derslik.Kodu);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                dd.BolumDersDonemi.Dersi.Adi = okuyucu["D_Adi"].ToString();
                dd.BolumDersDonemi.Bolumu.Kadi = okuyucu["B_KAdi"].ToString();
                dd.BolumDersDonemi.Donemi.Sinifi.Adi = okuyucu["Sf_Adi"].ToString();
                dd.BolumDersDonemi.Donemi.Subesi.Adi = okuyucu["Sb_Adi"].ToString();
                dd.BolumDersDonemi.Ogretimelemani.Kadi = okuyucu["OE_KAdi"].ToString();
            }
            baglanti.Close();
            baglanti.Dispose();
            return dd;
        }

        internal bool DersprogramiKontrolu(DersDagilimi dd)
        {
            Baglan();
            komut = new SqlCommand("usp_DersprogramiKontrolu",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum",dd.BolumDersDonemi.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Sinif",dd.BolumDersDonemi.Donemi.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@Sube",dd.BolumDersDonemi.Donemi.Subesi.Kodu);
            komut.Parameters.AddWithValue("@Donem",dd.BolumDersDonemi.Donemi.Donemi.Kodu);
            SqlParameter prm_Sonuc = new SqlParameter("@Sonuc", SqlDbType.Bit);
            prm_Sonuc.Direction = ParameterDirection.Output;
            komut.Parameters.Add(prm_Sonuc);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
            return Convert.ToBoolean(prm_Sonuc.Value); 
        }

        internal DersDagilimi       DersDagilimdanDersAl(DersDagilimi dd)
        {
            Baglan();
            komut = new SqlCommand("usp_DersDagilimiGetir", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum", dd.BolumDersDonemi.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Sinif", dd.BolumDersDonemi.Donemi.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@Sube", dd.BolumDersDonemi.Donemi.Subesi.Kodu);
            komut.Parameters.AddWithValue("@Donem",dd.BolumDersDonemi.Donemi.Donemi.Kodu);
            komut.Parameters.AddWithValue("@Gun", dd.Gunu.Kodu);
            komut.Parameters.AddWithValue("@Saat", dd.Saati.Kodu);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                dd.BolumDersDonemi.Dersi.Adi = okuyucu["DERS"].ToString();
                dd.BolumDersDonemi.Dersi.Kodu = Convert.ToInt32(okuyucu["D_Kodu"]);
                dd.Derslik.Adi = okuyucu["DERSLIK"].ToString();
                dd.Derslik.Kodu = Convert.ToInt32(okuyucu["Dk_Kodu"]);
            }
            baglanti.Close();
            baglanti.Dispose();
            return dd;
        }

        internal void tabloSifirla()
        {
            Baglan();
            komut = new SqlCommand("usp_tabloDDSifirla",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }
    }
}
