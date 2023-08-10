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
    public partial class frmUyeEkle : Form
    {
        public frmUyeEkle()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmUyeEkle_Paint);
        }

        MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=exwork;Uid=root;Pwd='';"); //localhost bağlantı bilgileri


        string personelAd, personelSoyad, personelDepartman, personelGorev, personelMail, personelTelefon, personelGSifre;

        private void departmanListele()
        {
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from departman");
            cmd.Connection = con;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["departman_adi"]);
                comboBox3.Items.Add(dr["departman_adi"]);
            }
        }

        private void gorevListele()
        {
            comboBox2.Text = "";
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

            comboBox2.Items.Clear();


            MySqlCommand cmd = new MySqlCommand("Select * From dpgorev where departman_id='" + dpID + "'", con);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["dpgorev_adi"]);
            }
            con.Close();
        }

        private void personelEkle()
        {
            personelAd = textBox1.Text;
            personelSoyad = textBox2.Text;
            personelMail = textBox5.Text;
            personelTelefon = textBox6.Text;
            personelGSifre = textBox8.Text;
            personelDepartman = comboBox1.Text;
            personelGorev = comboBox2.Text;

            try { 
                con.Open();

                string komut = "insert into personel(ad,soyad,mail,telefon,sifre,departman,gorev,rol,firma_id) values('" + personelAd + "', '" + personelSoyad + "', '" + personelMail + "', '" + personelTelefon + "', '" + personelGSifre + "', '" + personelDepartman + "', '" + personelGorev + "', '" + "personel" + "', '" + frmGiris.id +  "')";
                MySqlCommand cmd = new MySqlCommand(komut, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Tamamlandı.");
                personelListele();

                con.Close();
            }
            catch
            {
                MessageBox.Show("Kayıt Başarısız.");
            }
        }

        private void personelGuncelle()
        {
            con.Close();
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            string sorgu =
     "update personel set ad='" + textBox3.Text + "',soyad='" + textBox4.Text + "',mail='" + textBox7.Text + "',telefon='" + textBox9.Text
     + "',departman='" + comboBox3.Text + "',gorev='" + comboBox4.Text + "',rol='" + personelRol.Text + "' where personel_id=" + secilenID + "";
            cmd.CommandText = sorgu;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Güncelleme Başarılı");
            personelListele();
            tabControl1.SelectedTab = tabPage1;
        }

        void personelCekme()
        {
            //MessageBox.Show(secilenID);
            textBox3.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox9.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[6].Text;
            personelRol.Text = listView1.SelectedItems[0].SubItems[7].Text;
        }
                

       private void button1_Click(object sender, EventArgs e)
       {            
            personelListele();
        }        

        private void button3_Click(object sender, EventArgs e)
        {
            if(secilenID!="") 
            {
                silme(secilenID);

            }
            else //Bir satıra tıklanmamışsa
            {
                MessageBox.Show("Listeden bir seçim yapmalısınız.");
            }
        }

        private string secilenID = "";


        private void silme(string id)
        {
            DialogResult dialogResult = MessageBox.Show("Personeli silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                string sorgu = "DELETE FROM personel where personel_id='" + id + "'";
                cmd.CommandText = sorgu;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Silme İşlemi Başarılı");
                personelListele();
                tabControl1.SelectedTab = tabPage1;
            }

            else if (dialogResult == DialogResult.No)
            {
            };            
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            string sorgu =
     "update personel set ad='" + textBox4.Text + "',soyad='" + textBox7.Text + "',mail='" + textBox9.Text + "',telefon='" + personelRol.Text
     + "',departman='" + comboBox3.Text + "',gorev='" + comboBox4.Text + "',rol='" + personelRol.Text + "' where personel_id=" + secilenID + "";
            cmd.CommandText = sorgu;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Güncelleme Başarılı");
            personelListele();
            tabControl1.SelectedTab = tabPage1;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"] && secilenID == "")
            {
                tabControl1.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen işlem yapılacak personeli seçiniz."+secilenID ,"Uyarı!" );
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"] && secilenID != "")
            {
                secilenID = "";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int hata = 0;
            string kontrol = ".com";

            if (textBox3.Text == "" || textBox4.Text == "" || textBox7.Text == "" || textBox9.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || personelRol.Text == "")
            {
                hata++;
                MessageBox.Show("Boş alan bırakmayınız!");
            }

            if (textBox9.Text.Length < 11)
            {
                hata++;
                MessageBox.Show("Telefon numarası 11 haneli olmak zorundadır!");
            }

            if (textBox7.Text.EndsWith(kontrol) != true)
            {
                hata++;
                MessageBox.Show("Mail adresinin sonunda " + kontrol + " olmak zorundadır!");
            }

            if (hata == 0)
            {
                personelGuncelle();
            }            
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            secilenID = listView1.SelectedItems[0].SubItems[0].Text;
            label16.Visible = true;
            label16.Text = "Seçilen personel: " + listView1.SelectedItems[0].SubItems[1].Text + " " + listView1.SelectedItems[0].SubItems[2].Text;
            personelCekme();
        }

        int say = 0;

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                while (say < 5)
                {
                    textBox8.Text = textBox8.Text + textBox6.Text.Substring(say, 1);
                    say++;
                }
            }

            catch
            {

            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gorevListele();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Text = "";
            con.Close();
            con.Open();

            MySqlCommand cmd2 = new MySqlCommand("Select * From departman where departman_adi='" + comboBox3.Text + "'", con);

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
           
            MySqlCommand cmd = new MySqlCommand("Select * From dpgorev where departman_id='" + dpID + "'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                comboBox4.Items.Add(dr["dpgorev_adi"]);
            }
            con.Close();
        }

        private void frmUyeEkle_Paint(object sender, PaintEventArgs e)
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * From personel where ad like '" + textBox10.Text + "%' and firma_id=" + frmGiris.id + "" , con);
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

        private void button2_Click(object sender, EventArgs e)
        {
            int hata = 0;
            string kontrol = ".com";

            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                hata++;
                MessageBox.Show("Boş alan bırakmayınız!");
            }

            if (textBox6.Text.Length < 11)
            {
                hata++;
                MessageBox.Show("Telefon numarası 11 haneli olmak zorundadır!");
            }

            if (textBox5.Text.EndsWith(kontrol) != true)
            {
                hata++;
                MessageBox.Show("Mail adresinin sonunda " + kontrol + " olmak zorundadır!");
            }

            if (hata == 0)
            {
                personelEkle();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox8.Text = "";
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

        private void frmUyeEkle_Load_1(object sender, EventArgs e)
        {
            textBox10.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox10.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox10.AutoCompleteCustomSource = collection;

            personelListele();
            departmanListele();
        }

        private void personelListele()
        {          
            listView1.Items.Clear();
            con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from personel where firma_id='" + frmGiris.id + "'");
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
    }
}
