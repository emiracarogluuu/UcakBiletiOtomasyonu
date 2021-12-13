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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-08F7DVD\\SQLEXPRESS;Initial Catalog=ucakrez;Integrated Security=True");
        private void geriPicForm10_Click(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            fm1.Show();
            this.Close();
        }

        private void picCikisForm10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKullaniciKontrol_Click(object sender, EventArgs e)
        {
            sifre.Enabled = false;
            txtgizlicevap.Text = "";
            sifre.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from giris where kullaniciadi='" + kullaniciAdi.Text + "' and email='" + txtemail.Text + "'and gizlisoru='" + combogizlisoru.Text+ "'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                txtgizlicevap.Enabled=true;
                txtemail.Enabled = false;
                kullaniciAdi.Enabled = false;
                combogizlisoru.Enabled = false;
                MessageBox.Show("Şimdi Gizli Soruyu Cevaplayınız..");
            }
            else
            {
                txtgizlicevap.Enabled = false;
                sifre.Enabled = false;
                MessageBox.Show("Hatalı Giriş Yaptınız.");
            }
            baglanti.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            kullaniciAdi.Text = "halil";
            txtemail.Text = "hhalilaaydin@gmail.com";
        }

        private void ogren_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from giris where kullaniciadi='" + kullaniciAdi.Text + "' and email='" + txtemail.Text + "'and gizlisoru='" + combogizlisoru.Text + "'and gizlicevap='"+ txtgizlicevap.Text +"' ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                sifre.Text = dr[1].ToString();
                txtgizlicevap.Enabled = true;
                txtemail.Enabled = true;
                kullaniciAdi.Enabled = true;
                combogizlisoru.Enabled = true;
                sifre.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen Gizli Cevabınızı Tekrar Kontrol Ediniz.");
            }
            baglanti.Close();
        }
    }
}

