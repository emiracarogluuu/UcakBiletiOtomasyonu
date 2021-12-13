using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
        public static string kAdi;
        public static int kullaniciID;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-08F7DVD\\SQLEXPRESS;Initial Catalog=ucakrez;Integrated Security=True");
        
        private void picCikisForm1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from giris where kullaniciadi=@ad and sifre=@sifre", baglanti);
            komut.Parameters.Add("@ad", txtkullaniciAdi.Text);
            komut.Parameters.Add("@sifre", txtparola.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                kAdi = txtkullaniciAdi.Text;
                kullaniciID = Convert.ToInt32(dr["kullaniciID"].ToString());
                Form fr = new Form2();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız.");
            }
            baglanti.Close();
        }       
        private void sifremiunuttum_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form fr10 = new Form10();
            fr10.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtparola.PasswordChar = '\0';
            }
            else
            {
                txtparola.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
