using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AhiEvranDersProgrami
{
    class SaatVeritabani:TemelVeritabani
    {
        public override void Ekle(IVarlik varlik)
        {
            Saat s = (Saat)varlik;
            Baglan();
            komut = new SqlCommand("usp_saatekle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@araligi", s.Araligi);
            komut.Parameters.AddWithValue("@ogrenimTuru",s.OgrenimTuru);
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
            Saat S = (Saat)varlik;
            Baglan();
            komut = new SqlCommand("usp_SaatListeleParametre", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Araligi", S.Araligi);
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
            komut = new SqlCommand("usp_SaatListele",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

           




            internal List<int> SaatIdListele(Saat s)
            {
                List<int> Saatid = new List<int>();
                Baglan();
                komut = new SqlCommand("usp_SaatListeleOgrenimTuru", baglanti);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@ogrenimTuru", s.OgrenimTuru);
                komut.ExecuteNonQuery();
                okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Saatid.Add(Convert.ToInt32(okuyucu["St_Kodu"].ToString()));
                }
                baglanti.Close();
                baglanti.Dispose();
                return Saatid;
            }
            internal List<int> SaatIdListele()
            {
                List<int> Saatid = new List<int>();
                Baglan();
                komut = new SqlCommand("usp_SaatListele", baglanti);
                komut.CommandType = CommandType.StoredProcedure;
                komut.ExecuteNonQuery();
                okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Saatid.Add(Convert.ToInt32(okuyucu["St_Kodu"].ToString()));
                }
                baglanti.Close();
                baglanti.Dispose();
                return Saatid;
            }
            internal List<string> saatadilistele(Saat s)
            {
                List<string> SaatAdi = new List<string>();
                Baglan();
                komut = new SqlCommand("usp_SaatListeleOgrenimTuru", baglanti);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@ogrenimTuru", s.OgrenimTuru);
                komut.ExecuteNonQuery();
                okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    SaatAdi.Add(okuyucu["St_Araligi"].ToString());
                }
                baglanti.Close();
                baglanti.Dispose();
                return SaatAdi;
            }
            internal List<string> saatadilistele()
            {
                List<string> SaatAdi = new List<string>();
                Baglan();
                komut = new SqlCommand("usp_SaatListele", baglanti);
                komut.CommandType = CommandType.StoredProcedure;
                komut.ExecuteNonQuery();
                okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    SaatAdi.Add(okuyucu["St_Araligi"].ToString());
                }
                baglanti.Close();
                baglanti.Dispose();
                return SaatAdi;
            }
    }
}
