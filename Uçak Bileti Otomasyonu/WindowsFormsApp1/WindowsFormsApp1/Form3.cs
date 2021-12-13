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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-08F7DVD\\SQLEXPRESS;Initial Catalog=ucakrez;Integrated Security=True");
        private void geriPicForm3_Click(object sender, EventArgs e)
        {
            Form fm2 = new Form2();
            fm2.Show();
            this.Close();
        }

        private void picCikisForm3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            labelkullanici.Text = "Hosgeldiniz " + Form1.kAdi;
        }

        private void btnmusterikaydet_Click(object sender, EventArgs e)
        {
            if (textadres.Text!="" && textadsoyad.Text!="" && textcep.Text!="" && textev.Text!="" &&combocinsiyet.Text!="" && textemail.Text!=""&&texttcno.Text!="")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Insert into musteriler(tcno,adsoyad,ceptelno,evtelno,cinsiyet,email,adres) Values('" + texttcno.Text + "','" + textadsoyad.Text + "','" + textcep.Text + "','" + textev.Text + "','" + combocinsiyet.Text + "','" + textemail.Text + "','" + textadres.Text + "' ) ", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                MessageBox.Show("Güncelleme Başarılı.");
                baglanti.Close();
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("select * from musteriler where tcno='"+ texttcno.Text +"' and adsoyad='"+ textadsoyad.Text+"' and ceptelno='"+ textcep.Text+"' ", baglanti);
                SqlDataReader dr2 = komut2.ExecuteReader();
                if (dr2.Read()) {
                    textmusterino.Text = dr2[7].ToString();
                }                    
                baglanti.Close();
                texttcno.Text = "";
                textadres.Text = "";
                textadsoyad.Text = "";
                textcep.Text = "";
                textev.Text = "";
                textemail.Text = "";
                combocinsiyet.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen bilgileri eksiksiz doldurunuz..");
            }
          
        }

        private void btnmusteribul_Click(object sender, EventArgs e)
        {
            textmusterino.Text = "";
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from musteriler where MID="+ textmusterinobul.Text + " ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            if (dr2.Read())
            {
                groupBox2.Enabled = true;
                text2tcno.Text= dr2[0].ToString();
                text2adsoyad.Text = dr2[1].ToString();
                text2cep.Text = dr2[2].ToString();
                text2ev.Text = dr2[3].ToString();
                combo2cinsiyet.Text = dr2[4].ToString();
                text2mail.Text = dr2[5].ToString();
                text2adres.Text = dr2[6].ToString();          
                
            }else
            {
                MessageBox.Show("Bu ID'ye ait müşteri bilgisi bulunamadı.!");
                text2tcno.Text = "";
                text2adsoyad.Text = "";
                text2cep.Text = "";
                text2ev.Text = "";
                combo2cinsiyet.Text = "";
                text2mail.Text = "";
                text2adres.Text = "";
            }
            baglanti.Close();
        }

        private void btnmusteriguncelle_Click(object sender, EventArgs e)
        {
            if (text2tcno.Text != "" && text2adsoyad.Text != "" && text2cep.Text != "" && text2ev.Text != "" && combo2cinsiyet.Text != "" && text2mail.Text != ""&& text2adres.Text!="")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update musteriler set tcno='" + text2tcno.Text + "' , adsoyad='" + text2adsoyad.Text + "', ceptelno='" + text2cep.Text + "', evtelno='" + text2ev.Text + "',  cinsiyet='" + combo2cinsiyet.Text + "', email='" + text2mail.Text + "', adres='" + text2adres.Text + "' where MID=" + textmusterinobul.Text + " ", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                MessageBox.Show("Güncelleme Başarılı.");
                textmusterinobul.Enabled = true;
                textmusterinobul.Text = "";
                groupBox2.Enabled = false;

                baglanti.Close();
            }
            else
            {
                 MessageBox.Show("Boş Alan Bırakmayınız..");
                
            }
        }

        private void texttcno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textmusterinobul_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void text2tcno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textmusterino_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void text2cep_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void text2ev_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textcep_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textev_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }

}
