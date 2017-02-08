using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AhiEvranDersProgrami
{
    class DonemVeritabani:TemelVeritabani
    {
        public override void Ekle(IVarlik varlik)
        {
            Donem d=(Donem)varlik;
            Baglan();
            komut = new SqlCommand("usp_aktifdonemekle",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@donemi", d.Donemi.Kodu);
            komut.Parameters.AddWithValue("@sinif", d.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@sube", d.Subesi.Kodu);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        public override void Sil(IVarlik varlik)
        {
            Donem d = (Donem)varlik;
            Baglan();
            komut = new SqlCommand("usp_Donemsil",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@DonemKodu",d.Kodu);
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
            Donem d = (Donem)varlik;
            Baglan();
            komut = new SqlCommand("usp_aktifdonemlisteleparametreli", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@sinif",d.Sinifi.Adi);
            komut.Parameters.AddWithValue("@sube",d.Subesi.Adi);
            komut.Parameters.AddWithValue("@donemi", d.Donemi.Adi);
            komut.Parameters.AddWithValue("@donemid",d.Donemi.Kodu);
            komut.Parameters.AddWithValue("@subeid",d.Subesi.Kodu);
            komut.Parameters.AddWithValue("@sinifid",d.Sinifi.Kodu);
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
            komut = new SqlCommand("usp_aktifdonemlistele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal bool kontrolet(Donem d)
        {
            Baglan();
            komut = new SqlCommand("usp_Donemkontrolet",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@donemi",d.Donemi.Kodu);
            komut.Parameters.AddWithValue("@sinif",d.Sinifi.Kodu);
            komut.Parameters.AddWithValue("@sube",d.Subesi.Kodu);
            SqlParameter prm_Sonuc = new SqlParameter("@Sonuc", SqlDbType.Bit);
            prm_Sonuc.Direction = ParameterDirection.Output;
            komut.Parameters.Add(prm_Sonuc);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
            return Convert.ToBoolean(prm_Sonuc.Value); 
        }

        internal object DonemListeleListele()
        {
            Baglan();
            komut = new SqlCommand("usp_aktifdonemilistele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal Donem DonemListele(Donem d)
        {
            Baglan();
            komut = new SqlCommand("usp_BolumDonemListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kod", d.Kodu);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                d.Donemi.Adi = okuyucu["Donem"].ToString();
                d.Sinifi.Adi = okuyucu["Sinif"].ToString();
                d.Subesi.Adi = okuyucu["Sube"].ToString();
            }
            baglanti.Close();
            baglanti.Dispose();
            return d;
        }
    }
}
