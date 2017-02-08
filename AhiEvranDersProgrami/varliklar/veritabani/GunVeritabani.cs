using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace AhiEvranDersProgrami
{
    class GunVeritabani:TemelVeritabani
    {
        public override void Ekle(IVarlik varlik)
        {
            Gun g = (Gun)varlik;
            Baglan();
            komut = new SqlCommand("usp_gunekle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@adi", g.Adi);
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
            throw new NotImplementedException();
        }

        public override DataTable Listele(IVarlik varlik)
        {
            Gun G = (Gun)varlik;
            Baglan();
            komut = new SqlCommand("usp_GunListeleParametre", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Ad", G.Adi);
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
            komut = new SqlCommand("usp_GunListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal List<string> GunListele()
        {
            List<string> Gun = new List<string>();
            Baglan();
            komut = new SqlCommand("usp_GunListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                Gun.Add(okuyucu["G_Adi"].ToString());
            }
            baglanti.Close();
            baglanti.Dispose();
            return Gun;

        }

        internal List<string> GunAdiListele()
        {
            List<string> Gun = new List<string>();
            Baglan();
            komut = new SqlCommand("usp_GunListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                Gun.Add(okuyucu["G_Adi"].ToString());
            }
            baglanti.Close();
            baglanti.Dispose();
            return Gun;
        }

        internal List<int> GunIdListele()
        {
            List<int> Gun = new List<int>();
            Baglan();
            komut = new SqlCommand("usp_GunListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                Gun.Add(Convert.ToInt32(okuyucu["G_Kodu"].ToString()));
            }
            baglanti.Close();
            baglanti.Dispose();
            return Gun;
        }
    }
}
