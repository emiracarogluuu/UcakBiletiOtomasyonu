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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        int seferID, MusteriID,kID;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-08F7DVD\\SQLEXPRESS;Initial Catalog=ucakrez;Integrated Security=True");

        private void geriPicForm3_Click(object sender, EventArgs e)
        {
            Form fm2 = new Form2();
            fm2.Show();
            this.Close();
        }

        private void picCikisForm5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            labelkullanici.Text = "Hosgeldiniz " + Form1.kAdi;
            kID = Form1.kullaniciID;
            dateTimegidis.MinDate = DateTime.Now.AddDays(2);
        }

        private void dateTimegidis_ValueChanged(object sender, EventArgs e)
        {
            combosaatucret.Items.Clear();
            btnDevamEt.Enabled = false;
        }

        private void combosaatucret_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combosaatucret.Text != "")
            {
                btnDevamEt.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen bir saat seçiniz..");
            }
        }

        private void btnDevamEt_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DateTime tarih = dateTimegidis.Value;
            string zaman = tarih.ToShortDateString();
            tarih = Convert.ToDateTime(zaman);
            string saat = combosaatucret.Text.Substring(0, 8);
            SqlCommand sorgu = new SqlCommand("select seferID from seferler where kalkisyeri=@kalkiss and inisyeri=@iniss and gidistarihi=@tarihh and gidissaat=@saaat", baglanti);
            sorgu.Parameters.Add("@kalkiss", combokalkisyeri.Text);
            sorgu.Parameters.Add("@iniss", comboinisyeri.Text);
            sorgu.Parameters.Add("@tarihh", tarih);
            sorgu.Parameters.Add("@saaat", saat);
            SqlDataReader sorgula = sorgu.ExecuteReader();
            if (sorgula.Read())
            {
                seferID = Convert.ToInt32(sorgula["seferID"].ToString());
                groupBox1.Enabled = false;
                gbMusteriBilgi.Enabled = true;
                btnOdemeYap.Enabled = false;
            }
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from musteriler where MID=" + textmusteriID.Text + " ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            if (dr2.Read())
            {
                MusteriID = Convert.ToInt32(dr2[7]);
                texttcno.Text = dr2[0].ToString();
                textadsoyad.Text = dr2[1].ToString();
                textcepno.Text = dr2[2].ToString();
                textevno.Text = dr2[3].ToString();
                comboBox4.Text = dr2[4].ToString();
                textemail.Text = dr2[5].ToString();
                textadres.Text = dr2[6].ToString();
                btnOdemeYap.Enabled = true;
            }
            else
            {
                texttcno.Text = "";
                textadsoyad.Text = "";
                textcepno.Text = "";
                textevno.Text = "";
                comboBox4.Text = "";
                textemail.Text = "";
                textadres.Text = "";
                MessageBox.Show("Bu ID'ye ait müşteri bilgisi bulunamadı.!");
                btnOdemeYap.Enabled = false;
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            groupBox1.Enabled = true;
            btnDevamEt.Enabled = false;
            gbMusteriBilgi.Enabled = false;
            combosaatucret.Items.Clear();
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DateTime satis = DateTime.Now;
            SqlCommand sorgu = new SqlCommand("insert into biletler (seferID,kullaniciID,musteriID,checkindurumu,rezervasyondurumu,satistarihi)values (@seferID,@kullaniciID,@musteriID,0,1,@satistarihi)", baglanti);
            sorgu.Parameters.Add("@seferID", seferID);
            sorgu.Parameters.Add("@kullaniciID", kID);
            sorgu.Parameters.Add("@musteriID", MusteriID);
            sorgu.Parameters.Add("@satistarihi", satis);
            sorgu.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand IDogren = new SqlCommand("select biletID from biletler where seferID=@seferr and kullaniciID=@KID and musteriID=@MID and satistarihi=@tarihh ", baglanti);
            IDogren.Parameters.Add("@seferr", seferID);
            IDogren.Parameters.Add("@KID", kID);
            IDogren.Parameters.Add("@MID", MusteriID);
            IDogren.Parameters.Add("@tarihh", satis);
            SqlDataReader oku = IDogren.ExecuteReader();
            if (oku.Read())
            {
                int PNRno = Convert.ToInt32(oku["biletID"].ToString());
                MessageBox.Show("PNR Numaranız: " + PNRno.ToString() + " \n Not alınız..    Bilet Çıktı sayfasına yönlendirme");
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand guncelleKoltuk = new SqlCommand("update seferler set koltuksayisi=koltuksayisi-1 where seferID=@seferrr", baglanti);
            guncelleKoltuk.Parameters.Add("@seferrr", seferID);
            guncelleKoltuk.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DateTime tarih = dateTimegidis.Value;
            DateTime ara1;
            string zaman = tarih.ToShortDateString();
            string saat = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":00";
            ara1 = Convert.ToDateTime(zaman);
            SqlCommand sorgu = new SqlCommand("select * from seferler where kalkisyeri=@kalkis and inisyeri=@inis and gidistarihi=@zamann and koltuksayisi!=0", baglanti);
            sorgu.Parameters.Add("@kalkis", combokalkisyeri.Text);
            sorgu.Parameters.Add("@inis", comboinisyeri.Text);
            sorgu.Parameters.Add("@zamann", ara1);
            SqlDataReader dr = sorgu.ExecuteReader();
            int sayac = 0;
            int koltuk;
            while (dr.Read())
            {
                // koltuk sayisi kontrolü
                sayac++;
                combosaatucret.Items.Add(dr["gidissaat"] + " Saatli ve " + dr["ucret"].ToString() + " TL ücretli ");

            }
            if (sayac == 0)
            {
                MessageBox.Show("Bu kriterlere uygun uçuş bulunmamaktadır.");
            }
            dr.Close();
            baglanti.Close();
        }
    }

}
