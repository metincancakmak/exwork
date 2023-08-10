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
    public partial class frmGorevTakibiPersonel : Form
    {
        public frmGorevTakibiPersonel()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmGorevTakibiPersonel_Paint);
        }

        MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=exwork;Uid=root;Pwd='';"); //localhost bağlantı bilgileri

        private void personelinGorev()
        {
            listView2.Items.Clear();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from gorevler where personel_id=" + frmGiris.personelID + "");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem veriler = new ListViewItem(dr["gorev_id"].ToString());
                //veriler.SubItems.Add(dr["gorev_id"].ToString());
                veriler.SubItems.Add(dr["gorev_tur"].ToString());
                veriler.SubItems.Add(dr["gorev"].ToString());
                veriler.SubItems.Add(dr["tamamlandimi"].ToString());
                veriler.SubItems.Add(dr["gorev_sonuc"].ToString());
                veriler.SubItems.Add(dr["verilis_tarih"].ToString());
                veriler.SubItems.Add(dr["son_tarih"].ToString());
                veriler.SubItems.Add(dr["tamamlanma_tarih"].ToString());
                veriler.SubItems.Add(dr["puan"].ToString());
                veriler.BackColor = Color.FromArgb(247, 13, 26);

                if (dr["gorev_sonuc"].ToString() != "")
                {
                    veriler.BackColor = Color.Orange;
                    veriler.ForeColor = Color.White;
                }

                if (dr["tamamlandimi"].ToString() != "Hayır")
                {
                    veriler.BackColor = Color.Green;
                    veriler.ForeColor = Color.White;
                }                

                listView2.Items.Add(veriler);
            }
            con.Close();
        }

        private void frmGorevTakibiPersonel_Load(object sender, EventArgs e)
        {
            personelinGorev();
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            string gorevID = listView2.SelectedItems[0].SubItems[0].Text;
            label3.Text = gorevID.ToString();

            string gorevAd = listView2.SelectedItems[0].SubItems[2].Text;
            label4.Text = gorevAd.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gorevID = listView2.SelectedItems[0].SubItems[0].Text;
            string gorevSonuc = textBox1.Text;

            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            string sorgu =
          "update gorevler set gorev_sonuc='" + gorevSonuc + "' where gorev_id=" + gorevID + "";
            cmd.CommandText = sorgu;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Güncelleme Başarılı");
            personelinGorev();
            //tabControl1.SelectedTab = tabPage1;

            textBox1.Text = "";
        }

        private void frmGorevTakibiPersonel_Paint(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(253, 219, 146), // Başlangıç rengi (örneğin beyaz)
            Color.FromArgb(180, 220, 150),    // Bitiş rengi (örneğin mavi)
            System.Drawing.Drawing2D.LinearGradientMode.Horizontal)) // Gradyan yönü (dikey)
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
