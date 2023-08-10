using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data; // mysql bağlantısı için kütüphaneler
using MySql.Data.MySqlClient; // mysql bağlantısı için kütüphaneler
using System.Data.SqlClient; // mysql bağlantısı için kütüphaneler

namespace Exwork
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        MySqlDataReader dr;
        MySqlCommand cmd;

        MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=exwork;Uid=root;Pwd='';"); //localhost bağlantı bilgileri 

        public static string id; //admin ID
        public static string personelID;
        public static string girisTur;


        private void button1_Click(object sender, EventArgs e)
        {
            string mail = textBox1.Text;
            string sifre = textBox2.Text;
            string sorgu = "";
           

            if (radioButton1.Checked == true) // eğer kullanıcı girişi yapılacaksa
            {
                sorgu = "Select * From personel where mail='" + mail + "' and sifre='" + sifre + "'";
            }
            if (radioButton2.Checked == true) // eğer yönetici girişi yapılacaksa
            {
                sorgu = "Select * From firma where firma_mail='" + mail + "' and sifre='" + sifre + "'";
            }
            bool giris = false;
            
            con.Open();
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if(radioButton1.Checked == true)
                {
                    personelID = dr["personel_id"].ToString();
                    girisTur = "Personel";
                    MessageBox.Show("Başarılı Giriş");
                    frmAdmin f1 = new frmAdmin();
                    f1.Show();
                }
                if (radioButton2.Checked == true)
                {
                    id = dr["firma_id"].ToString();
                    girisTur = "Yönetici";
                    MessageBox.Show("Başarılı Giriş");
                    frmAdmin f1 = new frmAdmin();
                    f1.Show();
                }

                giris = true;
                this.Hide();
            }

            if (giris == false)
            {
                MessageBox.Show("Hatalı Giriş !");
            }
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
