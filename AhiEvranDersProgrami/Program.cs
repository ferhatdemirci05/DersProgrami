using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AhiEvranDersProgrami
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool giris = false;
            SqlConnection conn = new SqlConnection("Data Source=.;Integrated security=true");
            string durum = "";
            //Aşağıdaki sorgu SQLEXPRESS üzerinde bizim veritabanımızın (SETUPPROJESI) olup olmadığını kontrol ediyor ve eğer yoksa böyle bir veritabanı oluşturuyor.
            SqlDataReader okuyucu;
            SqlCommand kontrol = new SqlCommand("if not exists(select * from sys.databases where name = 'dp') begin select '1' as Durum end else begin select '0' as Durum end", conn);
            conn.Open();
            kontrol.ExecuteNonQuery();
            okuyucu = kontrol.ExecuteReader();
            while (okuyucu.Read())
            {
                durum = okuyucu["Durum"].ToString();
            }
            conn.Close();
            if (durum == "0")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Giris());//Giris()
            }
            else if (durum == "1")
            {
                IslemlerVeritabani vt = new IslemlerVeritabani();
                vt.vtOlustur();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Giris());
            }

        }
    }
}
