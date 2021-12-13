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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-08F7DVD\\SQLEXPRESS;Initial Catalog=ucakrez;Integrated Security=True");
        int seferID, MusteriID, biletID,secilen=0;
        int[] diziKoltuk = new int[20] { 0,0,0,0,0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        private void geriPicForm8_Click(object sender, EventArgs e)
        {
            Form fm2 = new Form2();
            fm2.Show();
            this.Close();
        }

        private void picCikisForm8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btngeridön_Click(object sender, EventArgs e)
        {
            textadsoyad.Text = "";
            textTc.Text = "";
            textinis.Text = "";
            textkalkis.Text = "";
            texttarih.Text = "";
            texttutar.Text = "";
            btnkoltuksec.Enabled = false;
            btnPNRBul.Enabled = true;
            btngeridön.Enabled = false;
            textBox1.Enabled = true;
        }

        private void btnkoltuksec_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand koltukList = new SqlCommand("select * from koltuklar where seferID=@seferID",baglanti);
            koltukList.Parameters.Add("seferID",seferID);
            SqlDataReader dr = koltukList.ExecuteReader();
            if (dr.Read())
            {
                if (Convert.ToInt32(dr["koltuk1"]) == 0)
                {
                    diziKoltuk[0] = 0;
                    button1.BackColor =Color.Green;
                    button1.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[0] = 1;
                    button1.BackColor = Color.Red;
                    button1.Enabled = false;
                    button1.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk2"]) == 0)
                {
                    diziKoltuk[1] = 0;
                    button2.BackColor = Color.Green;
                    button2.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[1] = 1;
                    button2.BackColor = Color.Red;
                    button2.Enabled = false;
                    button2.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk3"]) == 0)
                {
                    diziKoltuk[2] = 0;
                    button3.BackColor = Color.Green;
                    button3.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[2] = 1;
                    button3.BackColor = Color.Red;
                    button3.Enabled = false;
                    button3.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk4"]) == 0)
                {
                    diziKoltuk[3] = 0;
                    button4.BackColor = Color.Green;
                    button4.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[3] = 1;
                    button4.BackColor = Color.Red;
                    button4.Enabled = false;
                    button4.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk5"]) == 0)
                {
                    diziKoltuk[4] = 0;
                    button5.BackColor = Color.Green;
                    button5.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[4] = 1;
                    button5.BackColor = Color.Red;
                    button5.Enabled = false;
                    button5.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk6"]) == 0)
                {
                    diziKoltuk[5] = 0;
                    button6.BackColor = Color.Green;
                    button6.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[5] = 1;
                    button6.BackColor = Color.Red;
                    button6.Enabled = false;
                    button6.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk7"]) == 0)
                {
                    diziKoltuk[6] = 0;
                    button7.BackColor = Color.Green;
                    button7.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[6] = 1;
                    button7.BackColor = Color.Red;
                    button7.Enabled = false;
                    button7.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk8"]) == 0)
                {
                    diziKoltuk[7] = 0;
                    button8.BackColor = Color.Green;
                    button8.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[7] = 1;
                    button8.BackColor = Color.Red;
                    button8.Enabled = false;
                    button8.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk9"]) == 0)
                {
                    diziKoltuk[8] = 0;
                    button9.BackColor = Color.Green;
                    button9.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[8] = 1;
                    button9.BackColor = Color.Red;
                    button9.Enabled = false;
                    button9.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk10"]) == 0)
                {
                    diziKoltuk[9] = 0;
                    button10.BackColor = Color.Green;
                    button10.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[9] = 1;
                    button10.BackColor = Color.Red;
                    button10.Enabled = false;
                    button10.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk11"]) == 0)
                {
                    diziKoltuk[10] = 0;
                    button11.BackColor = Color.Green;
                    button11.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[10] = 1;
                    button11.BackColor = Color.Red;
                    button11.Enabled = false;
                    button11.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk12"]) == 0)
                {
                    diziKoltuk[11] = 0;
                    button12.BackColor = Color.Green;
                    button12.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[11] = 1;
                    button12.BackColor = Color.Red;
                    button12.Enabled = false;
                    button12.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk13"]) == 0)
                {
                    diziKoltuk[12] = 0;
                    button13.BackColor = Color.Green;
                    button13.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[12] = 1;
                    button13.BackColor = Color.Red;
                    button13.Enabled = false;
                    button13.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk14"]) == 0)
                {
                    diziKoltuk[13] = 0;
                    button14.BackColor = Color.Green;
                    button14.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[13] = 1;
                    button14.BackColor = Color.Red;
                    button14.Enabled = false;
                    button14.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk15"]) == 0)
                {
                    diziKoltuk[14] = 0;
                    button15.BackColor = Color.Green;
                    button15.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[14] = 1;
                    button15.BackColor = Color.Red;
                    button15.Enabled = false;
                    button15.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk16"]) == 0)
                {
                    diziKoltuk[15] = 0;
                    button16.BackColor = Color.Green;
                    button16.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[15] = 1;
                    button16.BackColor = Color.Red;
                    button16.Enabled = false;
                    button16.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk17"]) == 0)
                {
                    diziKoltuk[16] = 0;
                    button17.BackColor = Color.Green;
                    button17.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[16] = 1;
                    button17.BackColor = Color.Red;
                    button17.Enabled = false;
                    button17.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk18"]) == 0)
                {
                    diziKoltuk[17] = 0;
                    button18.BackColor = Color.Green;
                    button18.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[17] = 1;
                    button18.BackColor = Color.Red;
                    button18.Enabled = false;
                    button18.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk19"]) == 0)
                {
                    diziKoltuk[18] = 0;
                    button19.BackColor = Color.Green;
                    button19.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[18] = 1;
                    button19.BackColor = Color.Red;
                    button19.Enabled = false;
                    button19.Text = "Dolu";
                }
                if (Convert.ToInt32(dr["koltuk20"]) == 0)
                {
                    diziKoltuk[19] = 0;
                    button20.BackColor = Color.Green;
                    button20.Text = "Müsait";
                }
                else
                {
                    diziKoltuk[19] = 1;
                    button20.BackColor = Color.Red;
                    button20.Enabled = false;
                    button20.Text = "Dolu"; 
                }

                btnkoltuksec.Enabled = false;

            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "2 Nolu Koltuk Seçildi.";
            secilen = 2;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "3 Nolu Koltuk Seçildi.";
            secilen = 3;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "4 Nolu Koltuk Seçildi.";
            secilen = 4;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "5 Nolu Koltuk Seçildi.";
            secilen = 5;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "6 Nolu Koltuk Seçildi.";
            secilen = 6;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "7 Nolu Koltuk Seçildi.";
            secilen = 7;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "8 Nolu Koltuk Seçildi.";
            secilen = 8;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "9 Nolu Koltuk Seçildi.";
            secilen = 9;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "10 Nolu Koltuk Seçildi.";
            secilen = 10;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "11 Nolu Koltuk Seçildi.";
            secilen = 11;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "12 Nolu Koltuk Seçildi.";
            secilen = 12;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "13 Nolu Koltuk Seçildi.";
            secilen = 13;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "14 Nolu Koltuk Seçildi.";
            secilen = 14;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "15 Nolu Koltuk Seçildi.";
            secilen = 15;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "16 Nolu Koltuk Seçildi.";
            secilen = 16;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "17 Nolu Koltuk Seçildi.";
            secilen = 17;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "18 Nolu Koltuk Seçildi.";
            secilen = 18;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "19 Nolu Koltuk Seçildi.";
            secilen = 19;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "20 Nolu Koltuk Seçildi.";
            secilen = 20;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (secilen == 0)
            {
                MessageBox.Show("Lütfen Koltuk Seçiniz");
            }else if (secilen==1)
            {
                MessageBox.Show(secilen.ToString()+" Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk1=@biletId where seferID=@seferId ",baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 2)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk2=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 3)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk3=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 4)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk4=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 5)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk5=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 6)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk6=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 7)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk7=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 8)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk8=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 9)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk9=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 10)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk10=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 11)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk11=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 12)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk12=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 13)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk13=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 14)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk14=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 15)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk15=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 16)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk16=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 17)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk17=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 18)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk18=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 19)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk19=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (secilen == 20)
            {
                MessageBox.Show(secilen.ToString() + " Numaralı Koltuk için Checkin işlemi Başarılı. ");
                baglanti.Open();
                SqlCommand koltukayarla = new SqlCommand("update koltuklar set koltuk20=@biletId where seferID=@seferId ", baglanti);
                koltukayarla.Parameters.Add("@biletId", biletID);
                koltukayarla.Parameters.Add("@seferId", seferID);
                koltukayarla.ExecuteNonQuery();
                baglanti.Close();
            }
            if (secilen != 0)
            {
                baglanti.Open();
                SqlCommand rezervedurumu = new SqlCommand("update biletler set checkindurumu=@koltukno where biletID=@biletno",baglanti);
                rezervedurumu.Parameters.Add("@koltukno",secilen);
                rezervedurumu.Parameters.Add("@biletno", biletID);
                rezervedurumu.ExecuteNonQuery();
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textsecilen.Text = "1 Nolu Koltuk Seçildi.";
            secilen = 1;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            labelkullanici.Text = "Hosgeldiniz " + Form1.kAdi;
        }

        private void btnPNRBul_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int pnr = Convert.ToInt32(textBox1.Text);
                baglanti.Open();
                SqlCommand pnrbul = new SqlCommand("select * from biletler where biletID=@PNR and checkindurumu=0 and rezervasyondurumu=0", baglanti);
                pnrbul.Parameters.Add("@PNR", pnr);
                SqlDataReader oku = pnrbul.ExecuteReader();
                if (oku.Read())
                {
                    MusteriID = Convert.ToInt32(oku["musteriID"].ToString());
                    seferID = Convert.ToInt32(oku["seferID"].ToString());
                    biletID = Convert.ToInt32(textBox1.Text);
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand musteribul = new SqlCommand("select * from musteriler where MID=@MusteriID", baglanti);
                    musteribul.Parameters.Add("MusteriID", MusteriID);
                    SqlDataReader musteri = musteribul.ExecuteReader();
                    if (musteri.Read())
                    {
                        textadsoyad.Text = musteri["adsoyad"].ToString();
                        textTc.Text = musteri["tcno"].ToString();
                    }
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand seferBul = new SqlCommand("select * from seferler where seferID=@seferr", baglanti);
                    seferBul.Parameters.Add("@seferr", seferID);
                    SqlDataReader seferrr = seferBul.ExecuteReader();
                    if (seferrr.Read())
                    {
                        textinis.Text = seferrr["inisyeri"].ToString();
                        textkalkis.Text = seferrr["kalkisyeri"].ToString();
                        texttarih.Text = seferrr["gidistarihi"].ToString().Substring(0, 11) + seferrr["gidissaat"].ToString();
                        texttutar.Text = seferrr["ucret"].ToString();
                    }
                    btnkoltuksec.Enabled = true;
                    btnPNRBul.Enabled = false;
                    btngeridön.Enabled = true;
                    textBox1.Enabled = false;
                }
                else { MessageBox.Show("Bu PNR numarasına ait bilet bulunamadı."); }
                baglanti.Close();
            }
            else { MessageBox.Show("Lütfen PNR numarası giriniz."); }
        }
    }
}
