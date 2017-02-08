using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace AhiEvranDersProgrami
{
    class BolumVeritabani:TemelVeritabani
    {
        public override void Ekle(IVarlik varlik)
        {
            Bolum b = (Bolum)varlik;
            Baglan();
            komut = new SqlCommand("usp_bolumekle",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@adi",b.Adi);
            komut.Parameters.AddWithValue("@kadi",b.Kadi);
            komut.Parameters.AddWithValue("@kodu",b.Kodu);
            komut.Parameters.AddWithValue("@baskani",b.Baskani);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        public override void Sil(IVarlik varlik)
        {
            throw new NotImplementedException();
        }

        public override void Guncelle(IVarlik varlik)
        {
            Bolum b = (Bolum)varlik;
            Baglan();
            komut = new SqlCommand("usp_BolumGuncelle",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@adi", b.Adi);
            komut.Parameters.AddWithValue("@kadi",b.Kadi);
            komut.Parameters.AddWithValue("@baskani",b.Baskani);
            komut.Parameters.AddWithValue("@kodu",b.Kodu);
            komut.ExecuteNonQuery();
        }

        public override DataTable Listele(IVarlik varlik)
        {
            Bolum B = (Bolum)varlik;
            Baglan();
            komut = new SqlCommand("usp_BolumAra",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Ad", B.Adi);
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
            komut = new SqlCommand("usp_bolumlistele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal bool bolumkontrolet(Bolum b)
        {
            Baglan();
            komut = new SqlCommand("usp_bolumkontrolet", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kadi",b.Kadi);
            SqlParameter prm_Sonuc = new SqlParameter("@Sonuc", SqlDbType.Bit);
            prm_Sonuc.Direction = ParameterDirection.Output;
            komut.Parameters.Add(prm_Sonuc);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
            return Convert.ToBoolean(prm_Sonuc.Value); 
        }

        internal Bolum bolumlistele(Bolum b)
        {
            Baglan();
            komut = new SqlCommand("usp_bolumbilgilistele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kod", b.Kodu);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                b.Kadi = okuyucu["B_KAdi"].ToString();
                b.Adi = okuyucu["B_Adi"].ToString();
                b.Baskani = Convert.ToInt32(okuyucu["B_Baskani"].ToString());
            }
            baglanti.Close();
            baglanti.Dispose();
            return b;
        }
    }
}
