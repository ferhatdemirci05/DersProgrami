using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace AhiEvranDersProgrami
{
    class UnvanVeritabani:TemelVeritabani
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
            Baglan();
            komut = new SqlCommand("usp_UnvanListele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal bool unvankontrol(Unvan u)
        {
            Baglan();
            komut = new SqlCommand("usp_unvankontrol",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@unvan",u.Adi);
            SqlParameter prm_Sonuc = new SqlParameter("@Sonuc", SqlDbType.Bit);
            prm_Sonuc.Direction = ParameterDirection.Output;
            komut.Parameters.Add(prm_Sonuc);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
            return Convert.ToBoolean(prm_Sonuc.Value); 
        }

        internal Unvan UnvanListele(Unvan u)
        {
            Baglan();
            komut = new SqlCommand("usp_UnvanListele", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                u.Adi = okuyucu["U_Adi"].ToString();
            }
            return u;
        }
    }
}
