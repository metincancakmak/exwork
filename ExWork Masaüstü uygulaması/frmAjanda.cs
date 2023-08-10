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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using Button = System.Windows.Forms.Button;

namespace Exwork
{
    public partial class frmAjanda : Form
    {
        public frmAjanda()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmAjanda_Paint);
        }

        MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=exwork;Uid=root;Pwd='';"); //localhost bağlantı bilgileri

        string[,] ajanda = new string[0, 0];

        
        private void satirSayi(string sorgu)
        {
            string id = frmGiris.personelID;
            if (id == null) { id = frmGiris.id; };  
            con.Close();

            MySqlCommand cmd = new MySqlCommand("Select COUNT(*) from ajanda where olusturan_id='" + id +
                "' and olusturan_rol='" + frmGiris.girisTur + "'" + sorgu);
            cmd.Connection = con;
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            ajanda = new string[count + 1, count + 1];
            con.Close();
        }

        // ajanda verilerinin kopyalanacağı diziyi oluşturuyoruz

        private void ajandaGoster(string sorgu)
        {
            string id = frmGiris.personelID;
            if (id == null) { id = frmGiris.id; };
            ajandaTemizle();
            satirSayi(sorgu);
            MySqlCommand cmd = new MySqlCommand("Select * from ajanda where olusturan_id='" + id + "' and olusturan_rol='" + frmGiris.girisTur + "'" + sorgu);
            cmd.Connection = con;
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();   

            int sayac = 0; // dizi indexini belirlemek için sayaç değişkeni oluşturuyoruz. Veritabanında sorgulama yaparken her satır sonrası değeri +1 güncelleniyor 
            char[] ayrac = { '.' }; //  gün.ay.yıl şeklinde  gelen tarih değerinin içinden sadece gün parametresini almak için Split komutunu kullanacağız. ayrac değişkeni ile hangi karakterden sonrasını ayıracağımızı belirtiyoruz.
            while (dr.Read()) 
            {
                string[] parcalar = dr["ajanda_tarih"].ToString().Split(ayrac); // tarihi aldıktan sonra yukarıda tanımladığımız ayrac değişkenini split komutu içerisinde kullandık gelen değerleri ara dizimize yazdırdık.
                ajanda[sayac, 0] = parcalar[0]; // yukarıda içini doldurduğuımuz dizinin ilk değerini (gün parametresi) ajanda dizimize kaydediyoruz.
                ajanda[sayac, 1] = dr["ajanda_id"].ToString(); // yukarıda içini doldurduğuımuz dizinin ilk değerini (gün parametresi) ajanda dizimize kaydediyoruz.
                sayac++;
            }

            con.Close();
            
            foreach (var button in this.Controls.OfType<Button>()) 
            {
                for (int x = 0; x < ajanda.GetLength(0); x++)  
                {
                    if (ajanda[x, 0] == button.Text)
                    {
                        // eğer butonumuzun ismi dizimizdeki değer eşleşiyorsa yapılacaklar...
                        button.BackColor = Color.Red;
                    }
                    // MessageBox.Show(ajanda[x, 0], ajanda[x, 1]);
                }                
            }
        }

        private void ajandaTemizle()
        {
            foreach (var button in this.Controls.OfType<Button>()) // form içindeki tüm butonları döngüye alıyoruz
            {
                button.BackColor = Color.White;
            }

            button11.BackColor = Color.FromArgb(66, 184, 131);
            button26.BackColor = Color.FromArgb(66, 184, 131);
        }

        void btnClick(object sender, EventArgs e) // herhangi bir güne tıkladığında yapılacak işlemler
        {
            string ajanda_id = "";      
            Button btn = (Button)sender;

            for (int x = 0; x < ajanda.GetLength(0); x++)
            {
                if (ajanda[x, 0] == btn.Text)
                {
                    // eğer butonumuzun ismi dizimizdeki değer eşleşiyorsa yapılacaklar...
                    ajanda_id = ajanda[x, 1];
                }
                // MessageBox.Show(ajanda[x, 0], ajanda[x, 1]);
            }

            if (btn != null && btn.BackColor == Color.Red && ajanda_id != "") 
            {

                groupBox1.Visible = true;
                button12.Visible = false;

                MySqlCommand cmd = new MySqlCommand("Select * from ajanda where ajanda_id='" + ajanda_id + "'");
                cmd.Connection = con;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    label8.Text = dr["ajanda_tarih"].ToString(); // tarihi aldıktan sonra yukarıda tanımladığımız ayrac değilşkenini split komutu içerisinde kullandık gelen değerleri ara dizimize yazdırdık.
                    label3.Text = dr["ajanda_tur"].ToString(); // tarihi aldıktan sonra yukarıda tanımladığımız ayrac değilşkenini split komutu içerisinde kullandık gelen değerleri ara dizimize yazdırdık.
                    label5.Text = dr["baslik"].ToString(); // tarihi aldıktan sonra yukarıda tanımladığımız ayrac değilşkenini split komutu içerisinde kullandık gelen değerleri ara dizimize yazdırdık.
                    richTextBox1.Text = dr["icerik"].ToString(); // tarihi aldıktan sonra yukarıda tanımladığımız ayrac değilşkenini split komutu içerisinde kullandık gelen değerleri ara dizimize yazdırdık.
                    secilen_gorev_id.Text = dr["ajanda_id"].ToString(); // tarihi aldıktan sonra yukarıda tanımladığımız ayrac değilşkenini split komutu içerisinde kullandık gelen değerleri ara dizimize yazdırdık.

                }

                if (label3.Text == "Kişisel")
                {
                    button12.Visible = true;
                }
                con.Close();
            }
            else
            {
                groupBox1.Visible = false;

            }
        }

        private void frmAjanda_Load(object sender, EventArgs e)
        {
            ajandaGoster(" and ajanda_tur='Kişisel'");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ajandaGoster(" and ajanda_tur='" + comboBox4.Text + "'");

        }

        private void button12_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Ajanda bilgisini silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                string sorgu = "DELETE FROM ajanda where ajanda_id='" + secilen_gorev_id.Text + "'";
                cmd.CommandText = sorgu;
                cmd.ExecuteNonQuery();
                ajandaGoster("and ajanda_tur='Kişisel'");
                groupBox1.Visible = false;
                MessageBox.Show("Silme İşlemi Başarılı");
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            ajandaGoster(" and ajanda_tur='" + comboBox4.Text + "'");
        }

        private void frmAjanda_Paint(object sender, PaintEventArgs e)
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
