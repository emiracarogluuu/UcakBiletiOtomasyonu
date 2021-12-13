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
    public partial class odemeForm : Form
    {
        public odemeForm()
        {
            InitializeComponent();
        }
        int gelenseferID, gelenMusteriID, ucret;

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-08F7DVD\\SQLEXPRESS;Initial Catalog=ucakrez;Integrated Security=True");

        private void geriPicOdemeForm_Click(object sender, EventArgs e)
        {
            Form fm4 = new Form4();
            fm4.Show();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            nakitbox.Enabled = true;
            kredibox.Enabled = false;
            double sayi = (double)ucret * 1.19F;
            sayi = Math.Round(sayi, 2);
            textnakittoplam.Text = sayi.ToString();
            textkktoplam.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            kredibox.Enabled = true;
            nakitbox.Enabled = false;
            double sayi = (double)ucret * 1.19F;
            sayi = Math.Round(sayi, 2);
            textkktoplam.Text = sayi.ToString();
            textnakittoplam.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox9.Text!=""&& textBox8.Text!="" && textBox11.Text != "" && comboBox1.Text!="" && comboBox2.Text!="")
            {
                Form fm1 = new Form1();
                int kID = Form1.kullaniciID;
                baglanti.Open();
                DateTime satis = DateTime.Now;
                SqlCommand sorgu = new SqlCommand("insert into biletler (seferID,kullaniciID,musteriID,checkindurumu,rezervasyondurumu,satistarihi)values (@seferID,@kullaniciID,@musteriID,0,0,@satistarihi)", baglanti);
                sorgu.Parameters.Add("@seferID", gelenseferID);
                sorgu.Parameters.Add("@kullaniciID", kID);
                sorgu.Parameters.Add("@musteriID", gelenMusteriID);
                sorgu.Parameters.Add("@satistarihi", satis);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                SqlCommand IDogren = new SqlCommand("select biletID from biletler where seferID=@seferr and kullaniciID=@KID and musteriID=@MID and satistarihi=@tarihh ", baglanti);
                IDogren.Parameters.Add("@seferr", gelenseferID);
                IDogren.Parameters.Add("@KID", kID);
                IDogren.Parameters.Add("@MID", gelenMusteriID);
                IDogren.Parameters.Add("@tarihh", satis);
                SqlDataReader oku = IDogren.ExecuteReader();
                if (oku.Read())
                {
                    int PNRno = Convert.ToInt32(oku["biletID"].ToString());
                    MessageBox.Show("PNR Numaranız: " + PNRno.ToString() + " \n Not alınız..   Bilet Çıktı sayfasına yönlendirme");
                }
                baglanti.Close();
                baglanti.Open();
                SqlCommand guncelleKoltuk = new SqlCommand("update seferler set koltuksayisi=koltuksayisi-1 where seferID=@seferrr", baglanti);
                guncelleKoltuk.Parameters.Add("@seferrr", gelenseferID);
                guncelleKoltuk.ExecuteNonQuery();
                baglanti.Close();
        }
        }

        private void picCikisOdemeForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textnakitodeme_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)&&!char.IsSeparator(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            int kID = Form1.kullaniciID;
            double toplamtutar = ucret * 1.19F;
            if (textnakitodeme.Text != "" ) {
                int nakitodeme = Convert.ToInt32(textnakitodeme.Text);
                if (toplamtutar<=nakitodeme)
                {
                    double hesapla = nakitodeme - toplamtutar ;
                    hesapla = Math.Round(hesapla, 2);
                    textnakitparaustu.Text = (hesapla).ToString();
                    baglanti.Open();
                    DateTime satis = DateTime.Now;
                    SqlCommand sorgu = new SqlCommand("insert into biletler (seferID,kullaniciID,musteriID,checkindurumu,rezervasyondurumu,satistarihi)values (@seferID,@kullaniciID,@musteriID,0,0,@satistarihi)", baglanti);
                    sorgu.Parameters.Add("@seferID", gelenseferID);
                    sorgu.Parameters.Add("@kullaniciID",kID );
                    sorgu.Parameters.Add("@musteriID", gelenMusteriID);
                    sorgu.Parameters.Add("@satistarihi",satis );
                    sorgu.ExecuteNonQuery();
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand IDogren = new SqlCommand("select biletID from biletler where seferID=@seferr and kullaniciID=@KID and musteriID=@MID and satistarihi=@tarihh ", baglanti);
                    IDogren.Parameters.Add("@seferr", gelenseferID);
                    IDogren.Parameters.Add("@KID", kID);
                    IDogren.Parameters.Add("@MID", gelenMusteriID);
                    IDogren.Parameters.Add("@tarihh", satis);
                    SqlDataReader oku = IDogren.ExecuteReader();
                    if (oku.Read())
                    {
                        int PNRno = Convert.ToInt32(oku["biletID"].ToString());
                        MessageBox.Show("PNR Numaranız: "+PNRno.ToString()+" \n Not alınız..    Bilet Çıktı sayfasına yönlendirme");
                    }
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand guncelleKoltuk = new SqlCommand("update seferler set koltuksayisi=koltuksayisi-1 where seferID=@seferrr",baglanti);
                    guncelleKoltuk.Parameters.Add("@seferrr", gelenseferID);
                    guncelleKoltuk.ExecuteNonQuery();
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Eksik tutar girdiniz");
                }
            
        }else { MessageBox.Show("Lütfen ödeme yapılan tutarı giriniz.."); }
        }
          
        private void odemeForm_Load(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            Form fm4 = new Form4();
            labelkullanici.Text = "Hosgeldiniz " + Form1.kAdi;
            int kID = Form1.kullaniciID;
            gelenseferID = Form4.seferID;
            gelenMusteriID = Form4.MusteriID;
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select ucret from seferler where seferID=@seferno",baglanti);
            sorgu.Parameters.Add("@seferno", gelenseferID);
            SqlDataReader oku = sorgu.ExecuteReader();
            if (oku.Read())
            {
                ucret= Convert.ToInt32(oku["ucret"].ToString());
                textBox1.Text = oku["ucret"].ToString();
            }
            baglanti.Close();
            double hizmet =  (double)ucret * 0.01F;
            hizmet = Math.Round(hizmet, 2);
            Texthizmet.Text = (hizmet).ToString();
            double vergi= (double)ucret*0.18F;
            vergi = Math.Round(vergi, 2);
            textVergi.Text = vergi.ToString();
            double toplam = (float)ucret + (float)hizmet + (float)vergi;
            toplam = Math.Round(toplam, 2);
            texttoplam.Text = toplam.ToString();
        }
    }
}
