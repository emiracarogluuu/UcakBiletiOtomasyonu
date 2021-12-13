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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        int seferID;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-08F7DVD\\SQLEXPRESS;Initial Catalog=ucakrez;Integrated Security=True");
        private void geriPicForm6_Click(object sender, EventArgs e)
        {
            Form fm2 = new Form2();
            fm2.Show();
            this.Close();
        }

        private void picCikisForm6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            labelkullanici.Text = "Hosgeldiniz " + Form1.kAdi;
            dateTimeTarih.MinDate = DateTime.Now.AddDays(1);
            dateTimeTarih.Value = DateTime.Now.AddDays(1);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            DateTime tarih = dateTimeTarih.Value;
            if(comboInisYeri.Text!="" && comboKalkisYeri.Text!="" && textkoltuk.Text!="" && textucret.Text != "" && comboSaat.Text!=""&& comboDakika.Text!="")
            {
            if (comboInisYeri.Text != comboKalkisYeri.Text)
                {
            string zaman = tarih.ToShortDateString();
                    tarih = Convert.ToDateTime(zaman);
            string saat = comboSaat.Text + ":" + comboDakika.Text + ":00.0";
                    baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into seferler(kalkisyeri, inisyeri,gidistarihi,gidissaat,koltuksayisi,ucret) values (@kalkis,@inis,@tarih,@saat,@koltuk,@ucret)", baglanti); 
            komut.Parameters.AddWithValue("@inis", comboInisYeri.Text);
            komut.Parameters.AddWithValue("@kalkis", comboKalkisYeri.Text);
            komut.Parameters.AddWithValue("@tarih", tarih);
            komut.Parameters.AddWithValue("@saat", saat);
            komut.Parameters.AddWithValue("@koltuk", textkoltuk.Text);
            komut.Parameters.AddWithValue("@ucret", textucret.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Sefer Eklendi");
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select seferID from seferler where kalkisyeri=@kalkiss and inisyeri=@iniss and gidistarihi=@tarihh and gidissaat=@saatt ", baglanti);
                    komut2.Parameters.AddWithValue("@iniss", comboInisYeri.Text);
                    komut2.Parameters.AddWithValue("@kalkiss", comboKalkisYeri.Text);
                    komut2.Parameters.AddWithValue("@tarihh", tarih);
                    komut2.Parameters.AddWithValue("@saatt", saat);
                    komut2.ExecuteNonQuery();
                    SqlDataReader dr = komut2.ExecuteReader();
                    if (dr.Read())
                    {
                        seferID = Convert.ToInt32(dr["seferID"]);
                    }
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand koltukekle = new SqlCommand("Insert into koltuklar (seferID,koltuk1,koltuk2,koltuk3,koltuk4,koltuk5,koltuk6,koltuk7,koltuk8,koltuk9,koltuk10,koltuk11,koltuk12,koltuk13,koltuk14,koltuk15,koltuk16,koltuk17,koltuk18,koltuk19,koltuk20) values (@seferID,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)", baglanti);
                    koltukekle.Parameters.Add("seferID",seferID);
                    koltukekle.ExecuteNonQuery();
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("İniş Yeri İle Kalkış Yeri aynı olamaz..");
                } 
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız..");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
