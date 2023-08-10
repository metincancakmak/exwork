using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmAyarlarPersonel : Form
    {
        public frmAyarlarPersonel()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmAyarlarPersonel_Paint);
        }

        MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=exwork;Uid=root;Pwd='';"); //localhost bağlantı bilgileri
        MySqlCommand cmd = new MySqlCommand();

        private void personelCekme()
        {
            con.Open();

            cmd = new MySqlCommand("Select * from personel where personel_id=" + frmGiris.personelID + "");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox3.Text = dr["ad"].ToString();
                textBox4.Text = dr["soyad"].ToString();
                textBox7.Text = dr["mail"].ToString();
                textBox1.Text = dr["telefon"].ToString();
                textBox2.Text = dr["departman"].ToString();
                textBox5.Text = dr["gorev"].ToString();
                personelRol.Text = dr["rol"].ToString();
                textBox6.Text = dr["sifre"].ToString();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hata = 0;
            string kontrol = ".com";

            if (textBox7.Text == "")
            {
                hata++;
                MessageBox.Show("Mail alanı boş bırakılamaz!");
            }

            else if (textBox7.Text.EndsWith(kontrol))
            {
                DialogResult dialogResult = MessageBox.Show("Mail adresinizi değiştirmeyi kabul ediyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    cmd.Connection = con;
                    string sorgu =
             "update personel set mail='" + textBox7.Text + "' where personel_id=" + frmGiris.personelID + "";
                    cmd.CommandText = sorgu;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Güncelleme Başarılı");
                }

                else if (dialogResult == DialogResult.No)
                {

                };
            }

            else
            {
                MessageBox.Show("Mail adresinin sonunda " + kontrol + " olmak zorundadır!");
            }
        }

        private void frmAyarlarPersonel_Load(object sender, EventArgs e)
        {
            personelCekme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int hata = 0;

            if (textBox1.Text.Length < 11)
            {
                hata++;
                MessageBox.Show("Telefon numarası 11 haneli olmak zorundadır!");
            }

            if (hata == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Telefon numaranızı değiştirmeyi kabul ediyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    cmd.Connection = con;
                    string sorgu =
             "update personel set telefon='" + textBox1.Text + "' where personel_id=" + frmGiris.personelID + "";
                    cmd.CommandText = sorgu;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Güncelleme Başarılı");
                }

                else if (dialogResult == DialogResult.No)
                {

                };
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int hata = 0;

            if (textBox6.Text == "" || textBox6.Text.Length < 8)
            {
                hata++;
                MessageBox.Show("Şifre alanı 8 karakterden küçük olamaz!");
            }

            if (hata == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Şifre değiştirmeyi kabul ediyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    cmd.Connection = con;
                    string sorgu =
             "update personel set sifre='" + textBox6.Text + "' where personel_id=" + frmGiris.personelID + "";
                    cmd.CommandText = sorgu;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Şifre değiştirildi!");
                }

                else if (dialogResult == DialogResult.No)
                {

                };
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmAyarlarPersonel_Paint(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(253, 219, 146), // Başlangıç rengi (örneğin beyaz)
            Color.FromArgb(180, 220, 150),    // Bitiş rengi (örneğin mavi)
            System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal)) // Gradyan yönü (dikey)
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
