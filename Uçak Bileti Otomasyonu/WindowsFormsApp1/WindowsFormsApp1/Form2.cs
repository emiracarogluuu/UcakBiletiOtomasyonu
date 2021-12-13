using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void geriPic_Click(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            fm1.Show();
            this.Close(); 
        }
        private void picCikisForm2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void musterieklePic_Click(object sender, EventArgs e)
        {
            Form fm3 = new Form3();
            fm3.Show();
            this.Close();
        }
        private void satisPic_Click(object sender, EventArgs e)
        {
            Form fm4 = new Form4();
            fm4.Show();
            this.Close();
        }

        private void rezervasyonPic_Click(object sender, EventArgs e)
        {
            Form fm5 = new Form5();
            fm5.Show();
            this.Close();
        }

        private void seferDuzenlePic_Click(object sender, EventArgs e)
        {
            Form fm6 = new Form6();
            fm6.Show();
            this.Close();
        }

        

        private void pnrPic_Click(object sender, EventArgs e)
        {
            Form fm8 = new Form8();
            fm8.Show();
            this.Close();
        }

        private void iadePic_Click(object sender, EventArgs e)
        {
            Form fm9 = new Form9();
            fm9.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form fm11 = new Form11();
            fm11.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form fm1 = new Form1();
            labelkullanici.Text = "Hosgeldiniz "+ Form1.kAdi;
        }
    }

}
