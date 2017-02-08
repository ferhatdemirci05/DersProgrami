using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AhiEvranDersProgrami
{
   abstract class TemelVeritabani
    {
        public string yol;
        public SqlConnection baglanti;
        public SqlCommand komut;
        public SqlParameter parametre;
        public DataTable tablo;
        public SqlDataAdapter adaptor;
        public SqlDataReader okuyucu;
        public TemelVeritabani()
        {
            yol = ConfigurationManager.ConnectionStrings["Veriyolu"].ConnectionString;
        }
        public void Baglan()
        {
            baglanti = new SqlConnection(yol);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
        }
        abstract public void Ekle(IVarlik varlik);
        abstract public void Sil(IVarlik varlik);
        abstract public void Guncelle(IVarlik varlik);
        abstract public DataTable Listele(IVarlik varlik);
        abstract public DataTable Listele(); 
    }
}
