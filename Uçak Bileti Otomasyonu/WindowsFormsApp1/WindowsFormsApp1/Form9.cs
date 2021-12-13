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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-08F7DVD\\SQLEXPRESS;Initial Catalog=ucakrez;Integrated Security=True");
        int seferID, MusteriID,biletID;
        private void geriPicForm9_Click(object sender, EventArgs e)
        {
            Form fm2 = new Form2();
            fm2.Show();
            this.Close();
        }
        private void picCikisForm9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            labelkullanici.Text = "Hosgeldiniz " + Form1.kAdi;
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btngeridön_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            textadsoyad.Text = "";
            textTc.Text = "";
            textinis.Text = "";
            textkalkis.Text = "";
            texttarih.Text = "";
            texttutar.Text = "";
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            DateTime ucustarih;
            int checkin=0;
            baglanti.Open();
            SqlCommand seferIDbul = new SqlCommand("select seferID,checkindurumu from biletler where biletID=@biletNO",baglanti);
            seferIDbul.Parameters.Add("biletNO",biletID);
            SqlDataReader dr = seferIDbul.ExecuteReader();
            if (dr.Read())
            {
                seferID = Convert.ToInt32(dr["seferID"].ToString());
                checkin = Convert.ToInt32(dr["checkindurumu"].ToString());   
            }
            dr.Close();
            SqlCommand tarihal = new SqlCommand("select gidistarihi from seferler where seferID=@seferNO", baglanti);
            tarihal.Parameters.Add("seferNO",seferID);
            SqlDataReader dr1 = tarihal.ExecuteReader();
            if (dr1.Read())
            {
                
                ucustarih = Convert.ToDateTime(dr1["gidistarihi"].ToString());
                if (ucustarih < DateTime.Now)
                {
                    MessageBox.Show("Geçmiş Tarihe ait bilet iptal edilemez");

                    dr1.Close();
                }
                else if (checkin != 0) {
                    MessageBox.Show("Checkin yapılan bilet iptal edilemez..");
                }
                else
                {
                    dr1.Close();
                    SqlCommand biletsil = new SqlCommand("delete from biletler where biletID=@BiletID", baglanti);
                    biletsil.Parameters.Add("BiletID", biletID);
                    biletsil.ExecuteNonQuery();
                    SqlCommand koltukarttir = new SqlCommand("update seferler set koltuksayisi=koltuksayisi+1 where seferID=@seferID", baglanti);
                    koltukarttir.Parameters.Add("@seferID", seferID);
                    koltukarttir.ExecuteNonQuery();
                    MessageBox.Show("Bilet Silindi..");
                    this.Hide();
                    Form fm1 = new Form2();
                    fm1.Show();
                }
            }
            
            baglanti.Close();

        }
        private void btnPNRBul_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int pnr = Convert.ToInt32(textBox1.Text);
                baglanti.Open();
                SqlCommand pnrbul = new SqlCommand("select * from biletler where biletID=@PNR", baglanti);
                pnrbul.Parameters.Add("@PNR", pnr);
                SqlDataReader oku = pnrbul.ExecuteReader();
                if (oku.Read())
                {
                    MusteriID = Convert.ToInt32(oku["musteriID"].ToString());
                    seferID = Convert.ToInt32(oku["seferID"].ToString());
                    biletID=Convert.ToInt32(textBox1.Text);
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand musteribul = new SqlCommand("select * from musteriler where MID=@MusteriID",baglanti);
                    musteribul.Parameters.Add("MusteriID",MusteriID);
                    SqlDataReader musteri = musteribul.ExecuteReader();
                    if(musteri.Read())
                    {
                        textadsoyad.Text = musteri["adsoyad"].ToString();
                        textTc.Text = musteri["tcno"].ToString();
                    }
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand seferBul = new SqlCommand("select * from seferler where seferID=@seferr",baglanti);
                    seferBul.Parameters.Add("@seferr", seferID);
                    SqlDataReader seferrr = seferBul.ExecuteReader();
                    if (seferrr.Read()){
                        textinis.Text = seferrr["inisyeri"].ToString();
                        textkalkis.Text = seferrr["kalkisyeri"].ToString();
                        texttarih.Text = seferrr["gidistarihi"].ToString().Substring(0,11)+seferrr["gidissaat"].ToString();
                        texttutar.Text = seferrr["ucret"].ToString();
                    }
                    groupBox2.Enabled = true;
                    groupBox1.Enabled = false;
                }else { MessageBox.Show("Bu PNR numarasına ait bilet bulunamadı."); }
                baglanti.Close();
            }else { MessageBox.Show("Lütfen PNR numarası giriniz."); }
        }
    }

}
