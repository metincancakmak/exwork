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
using System;

namespace Exwork
{
    public partial class frmGorevVer : Form
    {
        public frmGorevVer()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmGorevVer_Paint);
        }

        MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=exwork;Uid=root;Pwd='';"); //localhost bağlantı bilgileri

        string secilenId = "";
        string gorevTuru = "";

        private void departmanListele()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox6.Items.Clear();
            con.Close();
            con.Open();
            
            MySqlCommand cmd = new MySqlCommand("Select * from departman");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["departman_adi"]);
                comboBox2.Items.Add(dr["departman_adi"]);
                comboBox6.Items.Add(dr["departman_adi"]);
            }
        }

        private void gorevListele()
        {

            con.Close();
            con.Open();

            MySqlCommand cmd2 = new MySqlCommand("Select * From departman where departman_adi='" + comboBox1.Text + "'", con);

            cmd2.Connection = con;
            MySqlDataReader dr2 = cmd2.ExecuteReader();

            string dpID = "";
            while (dr2.Read())
            {
                dpID = (dr2["departman_id"].ToString());
            }

            con.Close();
            con.Open();

            gorevBox.Items.Clear();


            MySqlCommand cmd = new MySqlCommand("Select * From dpgorev where departman_id='" + dpID + "'", con);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                gorevBox.Items.Add(dr["dpgorev_adi"]);
            }
            con.Close();
        }

        void departmanGetir()
        {
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * From personel where personel_id ='" + comboBox1.Text + "' and gorev='" + gorevBox.Text + "' and firma_id='"+frmGiris.id+"'", con);

            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox3.Items.Add((dr["ad"].ToString()));
            }
            con.Close();
        }

        void personelGetir()
        {
            comboBox3.Items.Clear();
            idler.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * From personel where departman='" + comboBox1.Text + "' and gorev='" + gorevBox.Text + "' and firma_id="+frmGiris.id+"", con);
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox3.Items.Add(dr["ad"]);
                idler.Items.Add(dr["personel_id"]);
            }
            comboBox3.Enabled = true;
        }

        void tumPersonelListele()
        {
            comboBox8.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select personel_id from personel where firma_id='"+frmGiris.id+"'");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox8.Items.Add(dr["personel_id"].ToString());
            }
        }

        private void frmGorevVer_Load(object sender, System.EventArgs e)
        {
            departmanListele();
            tumPersonelListele();
        }

        private void gorevBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            personelGetir();
        }

        string Id = "";

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox1.Enabled = true;
            }
            if (radioButton1.Checked == false)
            {
                groupBox1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                groupBox2.Enabled = true;
            }
            if (radioButton2.Checked == false)
            {
                groupBox2.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                groupBox3.Enabled = true;
            }
            if (radioButton3.Checked == false)
            {
                groupBox3.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                groupBox4.Enabled = true;
            }
            if (radioButton4.Checked == false)
            {
                groupBox4.Enabled = false;
            }
        }

        string olustuma_tarih = DateTime.Now.ToString("yyyy-MM-dd");

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            string gorevTarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            con.Close();
            con.Open();
            gorevTuru = "Kişisel";
            string komut = "insert into gorevler(firma_id,personel_id,gorev_tur,gorev,verilis_tarih,son_tarih,tamamlandimi,tamamlanma_tarih,puan) values('" + frmGiris.id + "', '" + Id + "', '" + gorevTuru + "', '" + textBox1.Text + "', '" + olustuma_tarih + "', '" + gorevTarih + "', '" + "Hayır" + "', '" + "0000-00-00" + "', '" + "" + "')";
            MySqlCommand cmd = new MySqlCommand(komut, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Görev Verildi.");

            con.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            gorevBox.Text = "";
            comboBox3.Text = "";
            gorevListele();
        }

        private void gorevBox_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            comboBox3.Text = "";
            personelGetir();
            comboBox3.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            idler.SelectedIndex = comboBox3.SelectedIndex;
            Id = idler.Text;
            //MessageBox.Show(Id);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            string personelID = "";

            foreach (string idler in comboBox5.Items)
            {
                personelID = (string)idler;
                string gorevTarih = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                con.Close();
                con.Open();
                gorevTuru = "Departman";
                string komut = "insert into gorevler(firma_id,personel_id,gorev_tur,gorev,verilis_tarih,son_tarih,tamamlandimi,tamamlanma_tarih,puan) values('" + frmGiris.id + "', '" + personelID + "', '" + gorevTuru + "', '" + textBox2.Text + "', '" + olustuma_tarih + "', '" + gorevTarih + "', '" + "Hayır" + "', '" + "0000-00-00" + "', '" + "" + "')";
                MySqlCommand cmd = new MySqlCommand(komut, con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Görev Verildi.");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            comboBox5.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT departman, personel_id FROM `personel` WHERE departman ='" + comboBox2.Text + "' and firma_id='"+frmGiris.id+"'");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox5.Items.Add(dr["personel_id"].ToString());
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            comboBox4.Text = "";
            con.Close();
            con.Open();

            MySqlCommand cmd2 = new MySqlCommand("Select * From departman where departman_adi='" + comboBox6.Text + "'",con);

            cmd2.Connection = con;
            MySqlDataReader dr2 = cmd2.ExecuteReader();

            string dpID = "";
            while (dr2.Read())
            {
                dpID = (dr2["departman_id"].ToString());
            }

            con.Close();
            con.Open();

            comboBox4.Items.Clear();


            MySqlCommand cmd = new MySqlCommand("Select * From personel where departman='" + comboBox6.Text + "' and firma_id='" + frmGiris.id + "' group by gorev",con);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox4.Items.Add(dr["gorev"]);
            }
            con.Close();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            string personelID = "";
            string gorevTarih = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            foreach (string idler in comboBox7.Items)
            {
                personelID = (string)idler;

                con.Close();
                con.Open();
                gorevTuru = "Bölüm";
                string komut = 
                    "insert into gorevler(firma_id,personel_id,gorev_tur,gorev,verilis_tarih,son_tarih,tamamlandimi,tamamlanma_tarih,puan)" +
                    " values('" + frmGiris.id + "', '" + personelID + "', '" + gorevTuru + "', '" + textBox3.Text + "', '" + olustuma_tarih +
                    "', '" + gorevTarih + "', '" + "Hayır" + "', '" + "0000-00-00" + "', '" + "" + "')";
                MySqlCommand cmd = new MySqlCommand(komut, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }

            MessageBox.Show("Görev Verildi.");
        }

        private void comboBox4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            comboBox7.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT gorev, personel_id FROM `personel` WHERE gorev ='" + comboBox4.Text + "' and firma_id='"+frmGiris.id+"'  GROUP BY gorev, personel_id");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox7.Items.Add(dr["personel_id"].ToString());
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            string personelID = "";
            string gorevTarih = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            foreach (string idler in comboBox8.Items)
            {
                personelID = (string)idler;

                con.Close();
                con.Open();
                gorevTuru = "Tüm Şirket";
                string komut = "insert into gorevler(firma_id,personel_id,gorev_tur,gorev,verilis_tarih,son_tarih,tamamlandimi,tamamlanma_tarih,puan) values('" + frmGiris.id + "', '" + personelID + "', '" + gorevTuru + "', '" + textBox4.Text + "', '" + olustuma_tarih + "', '" + gorevTarih + "', '" + "Hayır" + "', '" + "0000-00-00" + "', '" + "" + "')";
                MySqlCommand cmd = new MySqlCommand(komut, con);
                cmd.ExecuteNonQuery();

                con.Close();

            }

            MessageBox.Show("Görev Verildi.");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmGorevVer_Paint(object sender, PaintEventArgs e)
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

