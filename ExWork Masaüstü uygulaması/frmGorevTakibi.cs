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
    public partial class frmGorevTakibi : Form
    {
        public frmGorevTakibi()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmGorevTakibi_Paint);
        }

        MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=exwork;Uid=root;Pwd='';"); //localhost bağlantı bilgileri
        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

        private string secilenID = "";


        string onaylanma_tarih = DateTime.Now.ToString("yyyy-MM-dd");

        private void personelListele()
        {
            listView1.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from personel where firma_id="+ frmGiris.id+"");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem veriler = new ListViewItem(dr["personel_id"].ToString());
                veriler.SubItems.Add(dr["ad"].ToString());
                veriler.SubItems.Add(dr["soyad"].ToString());
                veriler.SubItems.Add(dr["mail"].ToString());
                veriler.SubItems.Add(dr["telefon"].ToString());
                veriler.SubItems.Add(dr["departman"].ToString());
                veriler.SubItems.Add(dr["gorev"].ToString());
                veriler.SubItems.Add(dr["rol"].ToString());
                listView1.Items.Add(veriler);
            }
            con.Close();
        }

        private void personelCekme()
        {
            string personelID, personelAd, personelSoyad;

            personelID = listView1.SelectedItems[0].SubItems[0].Text;
            personelAd = listView1.SelectedItems[0].SubItems[1].Text;
            personelSoyad = listView1.SelectedItems[0].SubItems[2].Text;

            label1.Text = personelAd + " " + personelSoyad;
            label2.Text = personelID.ToString();
        }

        private void personelGorevCekme()
        {
            listView2.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from gorevler where personel_id=" + label2.Text + "");
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



        private void frmGorevTakibi_Load(object sender, EventArgs e)
        {
            personelListele();

            textBox10.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox10.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox10.AutoCompleteCustomSource = collection;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * From personel where firma_id="+ frmGiris.id+" and ad like '" + textBox10.Text + "%'", con);
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                ListViewItem veriler = new ListViewItem(dr["personel_id"].ToString());
                veriler.SubItems.Add(dr["ad"].ToString());
                veriler.SubItems.Add(dr["soyad"].ToString());
                veriler.SubItems.Add(dr["mail"].ToString());
                veriler.SubItems.Add(dr["telefon"].ToString());
                veriler.SubItems.Add(dr["departman"].ToString());
                veriler.SubItems.Add(dr["gorev"].ToString());
                veriler.SubItems.Add(dr["rol"].ToString());
                collection.Add(dr["ad"].ToString());
                listView1.Items.Add(veriler);
            }
            con.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"] && secilenID == "")
            {
                tabControl1.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen işlem yapılacak personeli seçiniz." + secilenID, "Uyarı!");
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"] && secilenID != "")
            {
                secilenID = "";
                label2.Text = secilenID;
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            secilenID = listView1.SelectedItems[0].SubItems[0].Text;
            label16.Visible = true;
            label16.Text = "Seçilen personel: " + listView1.SelectedItems[0].SubItems[1].Text + " " + listView1.SelectedItems[0].SubItems[2].Text;
            personelCekme();
            personelGorevCekme();
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            string txtGorev = listView2.SelectedItems[0].SubItems[4].Text;
            textBox1.Text = txtGorev.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string puan = textBox2.Text;

            if (Convert.ToInt16(puan) > 10 || Convert.ToInt16(puan) < 0 || puan == null)
            {
                MessageBox.Show("Lütfen puan değerlendirmesini 1-10 aralığında yapınız.");
                puan = "";
                textBox2.Text = "";
            }

            else
            {
                string gorevID = listView2.SelectedItems[0].SubItems[0].Text;

                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                string sorgu =
              "update gorevler set puan='" + puan + "',tamamlandimi='" + "Evet" + "',tamamlanma_tarih='" + onaylanma_tarih + "' where gorev_id=" + gorevID + "";
                cmd.CommandText = sorgu;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Güncelleme Başarılı");
                personelListele();
                tabControl1.SelectedTab = tabPage1;

                puan = "";
                textBox2.Text = "";
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void frmGorevTakibi_Paint(object sender, PaintEventArgs e)
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
