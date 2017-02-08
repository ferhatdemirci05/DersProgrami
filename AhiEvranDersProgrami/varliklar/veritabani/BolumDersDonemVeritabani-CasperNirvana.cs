using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AhiEvranDersProgrami
{
    class BolumDersDonemVeritabani:TemelVeritabani
    {
        public override void Ekle(IVarlik varlik)
        {
            BolumDersDonem bdd = (BolumDersDonem)varlik;
            Baglan();
            komut = new SqlCommand("usp_BolumDersDonemEkle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@bolum", bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@donem", bdd.Donemi.Kodu);
            komut.Parameters.AddWithValue("@ders", bdd.Dersi.Kodu);
            komut.Parameters.AddWithValue("@oe", bdd.Ogretimelemani.Kodu);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        public override void Sil(IVarlik varlik)
        {
            BolumDersDonem bdd = (BolumDersDonem)varlik;
            Baglan();
            komut = new SqlCommand("usp_BolumDersDonemSil",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Kod",bdd.Kodu);
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
            BolumDersDonem bdd = (BolumDersDonem)varlik;
            Baglan();
            komut = new SqlCommand("usp_BolumDersDonemKriteregöreListele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum",bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Donem", bdd.Donemi.Kodu);
            komut.Parameters.AddWithValue("@Ders",bdd.Dersi.Kodu);
            komut.Parameters.AddWithValue("@OE",bdd.Ogretimelemani.Kodu);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;

        }

        public override DataTable Listele()
        {
            Baglan();
            komut = new SqlCommand("usp_BolumDersDonemListele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal bool kontrolet(BolumDersDonem bdd)
        {
            Baglan();
            komut = new SqlCommand("usp_BolumDersDonemKontrolet",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@bolum",bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@donem",bdd.Donemi.Kodu);
            komut.Parameters.AddWithValue("@ders", bdd.Dersi.Kodu);
            komut.Parameters.AddWithValue("@oe",bdd.Ogretimelemani.Kodu);
            SqlParameter prm_Sonuc = new SqlParameter("@Sonuc", SqlDbType.Bit);
            prm_Sonuc.Direction = ParameterDirection.Output;
            komut.Parameters.Add(prm_Sonuc);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
            return Convert.ToBoolean(prm_Sonuc.Value); 
        }

        internal object siniflistele(BolumDersDonem bdd)
        {
            Baglan();
            komut = new SqlCommand("usp_BölümdenSinifListele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum",bdd.Bolumu.Kodu);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal object SubeListele(BolumDersDonem bdd)
        {
            Baglan();
            komut = new SqlCommand("usp_BölümdenSinifaGoreSubeListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum", bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Sinif",bdd.Donemi.Sinifi.Kodu);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal object DonemListele(BolumDersDonem bdd)
        {
            Baglan();
            komut = new SqlCommand("usp_BölümdenSinifaveSubeyeGoreDonemListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum", bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Sinif", bdd.Donemi.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@Sube",bdd.Donemi.Subesi.Kodu);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal List<int> KayıtliBolumSiniflariListele(BolumDersDonem bdd)
        {
            List<int> Id = new List<int>();
            Baglan();
            komut = new SqlCommand("usp_KayitliBolumSiniflariListele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum",bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Sube",bdd.Donemi.Subesi.Kodu);
            komut.Parameters.AddWithValue("@Donemi",bdd.Donemi.Donemi.Kodu);
            komut.ExecuteNonQuery();
            okuyucu=komut.ExecuteReader();
            while (okuyucu.Read())
            {
                Id.Add(Convert.ToInt32(okuyucu["Sf_Kodu"].ToString()));
            }
            return Id;
        }
        internal List<string> KayıtliBolumSiniflariListele2(BolumDersDonem bdd)
        {
            List<string> Adi = new List<string>();
            Baglan();
            komut = new SqlCommand("usp_KayitliBolumSiniflariListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum", bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Sube", bdd.Donemi.Subesi.Kodu);
            komut.Parameters.AddWithValue("@Donemi", bdd.Donemi.Donemi.Kodu);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                Adi.Add(okuyucu["Sf_Kodu"].ToString());
            }
            return Adi;
        }
        internal void derssaatiarttir(BolumDersDonem bdd)
        {
            Baglan();
            komut = new SqlCommand("usp_derssaatiarttir",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum",bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Ders",bdd.Dersi.Kodu);
            komut.Parameters.AddWithValue("@Donem",bdd.Donemi.Donemi.Kodu);
            komut.Parameters.AddWithValue("@Sinif",bdd.Donemi.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@Sube",bdd.Donemi.Subesi.Kodu);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }
        internal void derssaatiazalt(BolumDersDonem bdd)
        {
            Baglan();
            komut = new SqlCommand("usp_derssaatiazalt", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum", bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Ders", bdd.Dersi.Kodu);
            komut.Parameters.AddWithValue("@Donem", bdd.Donemi.Donemi.Kodu);
            komut.Parameters.AddWithValue("@Sinif", bdd.Donemi.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@Sube", bdd.Donemi.Subesi.Kodu);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }
        internal bool derssaatikontrolet(BolumDersDonem bdd)
        {
            Baglan();
            komut = new SqlCommand("usp_derssaatikontrolet",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Bolum",bdd.Bolumu.Kodu);
            komut.Parameters.AddWithValue("@Ders",bdd.Dersi.Kodu);
            komut.Parameters.AddWithValue("@Donem",bdd.Donemi.Donemi.Kodu);
            komut.Parameters.AddWithValue("@Sinif",bdd.Donemi.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@Sube",bdd.Donemi.Subesi.Kodu);
            SqlParameter prm_Sonuc = new SqlParameter("@Sonuc", SqlDbType.Bit);
            prm_Sonuc.Direction = ParameterDirection.Output;
            komut.Parameters.Add(prm_Sonuc);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
            return Convert.ToBoolean(prm_Sonuc.Value);
        }
    }
}
