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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form4_Paint);
        }



        MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=exwork;Uid=root;Pwd='';"); //localhost bağlantı bilgileri

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void departmanListele()
        {
            comboBox2.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from departman");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["departman_adi"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = frmGiris.personelID;
            if (id == null) { id = frmGiris.id; };
            string ajandaTur = comboBox1.Text;
            string ajandaTarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string olustuma_tarih = DateTime.Now.ToString("yyyy-MM-dd");
            string baslik = textBox1.Text;
            string icerik = richTextBox1.Text;
            string departman = "";

            if (ajandaTur == "Departman")
            {
                departman = comboBox2.Text;
            }

            con.Close();
            con.Open();
            string komut = "insert into ajanda(ajanda_tur,olusturan_id,olusturma_tarih,baslik,icerik,ajanda_tarih,olusturan_rol,departman) values('" + ajandaTur + "', '" + id + "', '" + olustuma_tarih + "', '" + baslik + "', '" + icerik + "', '" + ajandaTarih + "', '" + frmGiris.girisTur + "', '" + departman  + "')";
            MySqlCommand cmd = new MySqlCommand(komut, con);
            cmd.ExecuteNonQuery();

            //MessageBox.Show(olustuma_tarih.ToString()+ " - " + ajandaTarih.ToString() );
            MessageBox.Show(ajandaTarih.ToString() + " tarihli ajanda kaydedildi.");

            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            departmanListele();

            if (frmGiris.girisTur == "Yönetici")
            {
                comboBox1.Items.Add("Firma");
                comboBox1.Items.Add("Departman");
            }
            comboBox1.Items.Add("Kişisel");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (comboBox1.Text == "Departman")
            {
                panel1.Visible=true;
            }
        }

        private void Form4_Paint(object sender, PaintEventArgs e)
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
