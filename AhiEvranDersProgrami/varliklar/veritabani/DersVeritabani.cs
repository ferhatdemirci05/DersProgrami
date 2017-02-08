using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AhiEvranDersProgrami
{
    class DersVeritabani:TemelVeritabani
    {
        public override void Ekle(IVarlik varlik)
        {
            Ders d = (Ders)varlik;
            Baglan();
            komut = new SqlCommand("usp_dersekle",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kod", d.Kodu);
            komut.Parameters.AddWithValue("@adi",d.Adi);
            komut.Parameters.AddWithValue("@k",d.Kredi);
            komut.Parameters.AddWithValue("@u",d.Uygulama);
            komut.Parameters.AddWithValue("@t",d.Teori);
            komut.Parameters.AddWithValue("@akts",d.Akts);
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
            Ders d = (Ders)varlik;
            Baglan();
            komut = new SqlCommand("usp_dersguncelle",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@adi",d.Adi);
            komut.Parameters.AddWithValue("@akts",d.Akts);
            komut.Parameters.AddWithValue("@kodu",d.Kodu);
            komut.Parameters.AddWithValue("@k",d.Kredi);
            komut.Parameters.AddWithValue("@t",d.Teori);
            komut.Parameters.AddWithValue("@u",d.Uygulama);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        public override DataTable Listele(IVarlik varlik)
        {
            Ders D = (Ders)varlik;
            Baglan();
            komut = new SqlCommand("usp_DersListeleParametre",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Ad",D.Adi);
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
            komut = new SqlCommand("usp_derslistele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal bool kontrolet(Ders d)
        {
            Baglan();
            komut = new SqlCommand("usp_derskontrolet",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kod", d.Kodu);
            SqlParameter prm_Sonuc = new SqlParameter("@Sonuc", SqlDbType.Bit);
            prm_Sonuc.Direction = ParameterDirection.Output;
            komut.Parameters.Add(prm_Sonuc);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
            return Convert.ToBoolean(prm_Sonuc.Value);
        }

        internal Ders bilgigetir(Ders d2)
        {
            Baglan();
            komut = new SqlCommand("usp_dersbilgileri",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kod",d2.Kodu);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                d2.Adi = okuyucu["D_Adi"].ToString();
                d2.Akts =Convert.ToInt32(okuyucu["D_AKTS"].ToString());
                d2.Kodu =Convert.ToInt32(okuyucu["D_Kodu"].ToString());
                d2.Kredi = Convert.ToInt32(okuyucu["D_K"].ToString());
                d2.Teori = Convert.ToInt32(okuyucu["D_T"].ToString());
                d2.Uygulama = Convert.ToInt32(okuyucu["D_U"].ToString());
            }
            baglanti.Close();
            baglanti.Dispose();
            return d2;
        }
    }
}
