using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AhiEvranDersProgrami
{
    public partial class Ayar : Form
    {
        public Ayar()
        {
            InitializeComponent();
        }
        string resimPath;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";

            openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg|Gif Dosyası (*.gif)|*.gif|Png Dosyası (*.png)|*.png|Tif Dosyası (*.tif)|*.tif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                resimPath = openFileDialog1.FileName.ToString();
                textBox2.Text = resimPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(resimPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] resim = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            SqlConnection bag = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=dp;Integrated Security=True");
            SqlCommand kmt = new SqlCommand("insert into tbl_Ayar(Ayar_Image) Values (@image) ", bag);
            kmt.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;
            
            try
            {
                bag.Open();
                kmt.ExecuteNonQuery();
                MessageBox.Show(" Veritabanına kayıt yapıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                bag.Close();
            }
        }

        private void textBox_Lisans1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Lisans1.TextLength == 5)
            {
                textBox_Lisans2.Focus();
            }
        }

        private void textBox_Lisans2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Lisans2.TextLength == 5)
            {
                textBox_Lisans3.Focus();
            }
            else if (textBox_Lisans2.TextLength == 0)
            {
                textBox_Lisans1.Focus();
            }
        }

        private void textBox_Lisans3_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Lisans3.TextLength == 5)
            {
                textBox_Lisans4.Focus();
            }
            else if (textBox_Lisans3.TextLength == 0)
            {
                textBox_Lisans2.Focus();
            }
        }

        private void textBox_Lisans4_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Lisans4.TextLength == 5)
            {
                textBox_Lisans5.Focus();
            }
            else if (textBox_Lisans4.TextLength == 0)
            {
                textBox_Lisans3.Focus();
            }
        }

        private void textBox_Lisans5_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Lisans5.TextLength == 5)
            {
              
                label_Lisans.Focus();
            }
            else if (textBox_Lisans5.TextLength == 0)
            {
                textBox_Lisans4.Focus();
            }
        }
    }
}
