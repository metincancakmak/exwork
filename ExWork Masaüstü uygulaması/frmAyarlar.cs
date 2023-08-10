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
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmAyarlar_Paint_1);
        }

        private void frmAyarlar_Paint_1(object sender, PaintEventArgs e)
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

        MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=exwork;Uid=root;Pwd='';"); //localhost bağlantı bilgileri
        MySqlCommand cmd = new MySqlCommand();

        private void firmaBilgiGetir()
        {
            con.Open();

            cmd = new MySqlCommand("Select * from firma where firma_id=" + frmGiris.id + "");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox3.Text = dr["firma_adi"].ToString();
                textBox4.Text = dr["firma_yetkili"].ToString();
                textBox2.Text = dr["firma_mail"].ToString();
                textBox5.Text = dr["firma_telefon"].ToString();
                textBox6.Text = dr["firma_sehir"].ToString();
                textBox7.Text = dr["firma_ilce"].ToString();
                textBox1.Text = dr["sifre"].ToString();
            }

            con.Close();
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            firmaBilgiGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hata = 0;

            if (textBox3.Text == "")
            {
                hata++;
                MessageBox.Show("Alan boş bırakılamaz!");
            }

            if (hata == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Firma adını değiştirmeyi kabul ediyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    cmd.Connection = con;
                    string sorgu =
             "update firma set firma_adi='" + textBox3.Text + "' where firma_id=" + frmGiris.id + "";
                    cmd.CommandText = sorgu;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Firma adı değiştirildi!");
                }

                else if (dialogResult == DialogResult.No)
                {

                };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int hata = 0;

            if (textBox4.Text == "")
            {
                hata++;
                MessageBox.Show("Alan boş bırakılamaz!");
            }

            if (hata == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Firma yetkilisini değiştirmeyi kabul ediyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    cmd.Connection = con;
                    string sorgu =
             "update firma set firma_yetkili='" + textBox4.Text + "' where firma_id=" + frmGiris.id + "";
                    cmd.CommandText = sorgu;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Firma yetkili değiştirildi!");
                }

                else if (dialogResult == DialogResult.No)
                {

                };
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int hata = 0;
            string kontrol = ".com";

            if (textBox2.Text == "")
            {
                hata++;
                MessageBox.Show("Alan boş bırakılamaz");
            }

            else if (textBox2.Text.EndsWith(kontrol))
            {
                DialogResult dialogResult = MessageBox.Show("Firma mail adresini değiştirmeyi kabul ediyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    cmd.Connection = con;
                    string sorgu =
             "update firma set firma_mail='" + textBox2.Text + "' where firma_id=" + frmGiris.id + "";
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

        private void button4_Click(object sender, EventArgs e)
        {
            int hata = 0;

            if (textBox5.Text.Length < 11)
            {
                hata++;
                MessageBox.Show("Telefon numarası 11 haneli olmak zorundadır!");
            }

            if (hata == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Firma telefon numarasını değiştirmeyi kabul ediyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    cmd.Connection = con;
                    string sorgu =
             "update firma set firma_telefon='" + textBox5.Text + "' where firma_id=" + frmGiris.id + "";
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int hata = 0;

            if (textBox6.Text == "")
            {
                hata++;
                MessageBox.Show("Alan boş bırakılamaz!");
            }

            if (hata == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Firma şehir adresini değiştirmeyi kabul ediyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    cmd.Connection = con;
                    string sorgu =
             "update firma set firma_sehir='" + textBox6.Text + "' where firma_id=" + frmGiris.id + "";
                    cmd.CommandText = sorgu;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Firma şehir adresi değiştirildi!");
                }

                else if (dialogResult == DialogResult.No)
                {

                };
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int hata = 0;

            if (textBox7.Text == "")
            {
                hata++;
                MessageBox.Show("Alan boş bırakılamaz!");
            }

            if (hata == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Firma ilçe adresini değiştirmeyi kabul ediyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                    cmd.Connection = con;
                    string sorgu =
             "update firma set firma_ilce='" + textBox7.Text + "' where firma_id=" + frmGiris.id + "";
                    cmd.CommandText = sorgu;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Firma ilçe adresi değiştirildi!");
                }

                else if (dialogResult == DialogResult.No)
                {

                };
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int hata = 0;

            if (textBox1.Text == "" || textBox1.Text.Length < 8)
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
             "update firma set sifre='" + textBox1.Text + "' where firma_id=" + frmGiris.id + "";
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

        
    }
}
