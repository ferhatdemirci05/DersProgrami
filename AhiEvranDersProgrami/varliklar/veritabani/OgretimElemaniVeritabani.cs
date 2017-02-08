using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace AhiEvranDersProgrami
{
    class OgretimElemaniVeritabani:TemelVeritabani
    {
        public override void Ekle(IVarlik varlik)
        {
            OgretimElemani oe = (OgretimElemani)varlik;
            Baglan();
            komut = new SqlCommand("usp_OgretimElemaniEkle",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kadi",oe.Kadi);
            komut.Parameters.AddWithValue("@adi",oe.Adi);
            komut.Parameters.AddWithValue("@soyadi",oe.Soyadi);
            komut.Parameters.AddWithValue("@unav",oe.Unvani.Kodu);
            komut.Parameters.AddWithValue("@dtarih",oe.DTarihi);
            komut.Parameters.AddWithValue("@stel",oe.STel);
            komut.Parameters.AddWithValue("@ctel",oe.CTel);
            komut.Parameters.AddWithValue("@mail",oe.Mail);
            komut.Parameters.AddWithValue("@maas",oe.Maasi);
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
            OgretimElemani oe = (OgretimElemani)varlik;
            Baglan();
            komut = new SqlCommand("usp_ogretimelemaniguncelle",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.Add("@adi",oe.Adi);
            komut.Parameters.Add("@ctel",oe.CTel);
            komut.Parameters.Add("@dtarih",oe.DTarihi);
            komut.Parameters.Add("@kadi",oe.Kadi);
            komut.Parameters.Add("@kodu",oe.Kodu);
            komut.Parameters.Add("@maas",oe.Maasi);
            komut.Parameters.Add("@mail",oe.Mail);
            komut.Parameters.Add("@soyadi",oe.Soyadi);
            komut.Parameters.Add("@stel",oe.STel);
            komut.Parameters.Add("@unvan",oe.Unvani.Kodu);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        public override DataTable Listele(IVarlik varlik)
        {
            OgretimElemani OE = (OgretimElemani)varlik;
            Baglan();
            komut = new SqlCommand("usp_ogreimelemanilisteleParametre",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Ad", OE.Adi);
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
            komut = new SqlCommand("usp_ogretimelemanilistele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal OgretimElemani Bİlgigetir(OgretimElemani oe)
        {
            Baglan();
            komut = new SqlCommand("usp_ogretimelemanibilgileri", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@kod",oe.Kodu);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                oe.Adi = okuyucu["OE_Adi"].ToString();
                oe.Soyadi = okuyucu["OE_Soyadi"].ToString();
                oe.Kadi = okuyucu["OE_KAdi"].ToString();
                oe.Unvani.Kodu =Convert.ToInt32(okuyucu["OE_Unvan"].ToString());
                oe.DTarihi = Convert.ToDateTime(okuyucu["OE_DTarihi"].ToString());
                oe.STel = okuyucu["OE_STel"].ToString();
                oe.CTel = okuyucu["OE_CTel"].ToString();
                oe.Mail = okuyucu["OE_Mail"].ToString();
                oe.Maasi =Convert.ToInt32(okuyucu["OE_Maas"].ToString());
            }
            baglanti.Close();
            baglanti.Dispose();
            return oe;
        }

        internal bool kontrolet(OgretimElemani oe2)
        {
            Baglan();
            komut = new SqlCommand("usp_ogretimelemanikontrol",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@adi",oe2.Adi);
            komut.Parameters.AddWithValue("@unvan",oe2.Unvani.Adi);
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
