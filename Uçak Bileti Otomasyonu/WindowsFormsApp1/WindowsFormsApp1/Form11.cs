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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-08F7DVD\\SQLEXPRESS;Initial Catalog=ucakrez;Integrated Security=True");
        private void picCikisForm11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geriPicForm11_Click(object sender, EventArgs e)
        {
            Form fm2 = new Form2();
            fm2.Show();
            this.Close();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update giris set telefon='" + Texttel.Text + "' , tcno='" + Texttcno.Text + "', adsoyad='" + Textadsoyad.Text + "', email='" + Textemail.Text + "',  adres='" + Textadres.Text + "', gizlisoru='" + combogizlisoru.Text + "', gizlicevap='" + Textgizlicevap.Text + "'  where kullaniciadi='" + Form1.kAdi + "' ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            MessageBox.Show("Güncelleme Başarılı.");
              if (dr.Read())
             {

                 Texttcno.Text = dr[5].ToString();
                  Textkullaniciadi.Text = dr[0].ToString();
                  Textadsoyad.Text = dr[8].ToString();
                  Textemail.Text = dr[7].ToString();
                  Texttel.Text = dr[4].ToString();
                  Textadres.Text = dr[6].ToString();
                  combogizlisoru.Text = dr[2].ToString();
                  Textgizlicevap.Text = dr[3].ToString();
                  Textsifre.Text = dr[1].ToString();   
              }
              else
              {
                  MessageBox.Show("Bir Sorun Oluştu, Tekrar Deneyiniz..");
              }  
            baglanti.Close();

        }
        private void Form11_Load(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            labelkullanici.Text = "Hosgeldiniz " + Form1.kAdi;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from giris where kullaniciadi='" + Form1.kAdi + "' ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Texttcno.Text = dr[5].ToString();
                Textkullaniciadi.Text= dr[0].ToString();
                Textadsoyad.Text= dr[8].ToString();
                Textemail.Text= dr[7].ToString();
                Texttel.Text= dr[4].ToString();
                Textadres.Text= dr[6].ToString();
                combogizlisoru.Text=dr[2].ToString();
                Textgizlicevap.Text= dr[3].ToString();
                Textsifre.Text= dr[1].ToString();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız.");
            }
            baglanti.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Textsifre.PasswordChar = '\0';
            } else
            {
                Textsifre.PasswordChar = '*';
            }
        }

        private void btndegistir_Click(object sender, EventArgs e)
        {
            if (textyenisifre.Text == textsifretekrar.Text)
            {
                if (textyenisifre.Text != "") {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("update giris set sifre='" + textyenisifre.Text + "'where kullaniciadi='" + Form1.kAdi + "' ", baglanti);
                    SqlDataReader dr = komut.ExecuteReader();
                    baglanti.Close();
                    MessageBox.Show("Şifre değiştirildi..");
                    Form fm11 = new Form11();
                    fm11.Show();
                }
                else
                {
                    MessageBox.Show("Boş giriş yapmayınız..");
                }
            }
            else
            {
                MessageBox.Show("Yeni şifre ile şifre tekrarı uyuşmamaktadır..");
            }
            
        }
    }
}
