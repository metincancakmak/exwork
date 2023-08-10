using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exwork
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmAdmin_Paint);
        }

        private void frmAdmin_Paint(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(246, 211, 101), // Başlangıç rengi (örneğin beyaz)
                Color.FromArgb(253, 160, 133),    // Bitiş rengi (örneğin mavi)
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal)) // Gradyan yönü (dikey)
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void genelIcerik()
        {
            frmAjanda frmgenel = new frmAjanda();
            frmgenel.TopLevel = false;
            icerikPaneli.Controls.Add(frmgenel);
            frmgenel.Show();
            frmgenel.Dock = DockStyle.Fill;
            frmgenel.BringToFront();
        }
        private void btnGenel_Click(object sender, EventArgs e)
        {
            genelIcerik();
        }

        private void btnGorevVer_Click(object sender, EventArgs e)
        {
            frmGorevVer frmgorevver = new frmGorevVer();
            frmgorevver.TopLevel = false;
            icerikPaneli.Controls.Add(frmgorevver);
            frmgorevver.Show();
            frmgorevver.Dock = DockStyle.Fill;
            frmgorevver.BringToFront();
        }

        private void btnGorevTakibi_Click_1(object sender, EventArgs e)
        {
            if (frmGiris.girisTur == "Yönetici") { 
            frmGorevTakibi frmgorevtakibi = new frmGorevTakibi();
            frmgorevtakibi.TopLevel = false;
            icerikPaneli.Controls.Add(frmgorevtakibi);
            frmgorevtakibi.Show();
            frmgorevtakibi.Dock = DockStyle.Fill;
            frmgorevtakibi.BringToFront();
            }
            if (frmGiris.girisTur == "Personel")
            {
                frmGorevTakibiPersonel frmgorevtakibi = new frmGorevTakibiPersonel();
                frmgorevtakibi.TopLevel = false;
                icerikPaneli.Controls.Add(frmgorevtakibi);
                frmgorevtakibi.Show();
                frmgorevtakibi.Dock = DockStyle.Fill;
                frmgorevtakibi.BringToFront();
            }
        }

        private void btnAjandam_Click(object sender, EventArgs e)
        {
            frmAjanda frmajandam = new frmAjanda();
            frmajandam.TopLevel = false;
            icerikPaneli.Controls.Add(frmajandam);
            frmajandam.Show();
            frmajandam.Dock = DockStyle.Fill;
            frmajandam.BringToFront();
        }

        private void btnPersonelAyarları_Click(object sender, EventArgs e)
        {
            frmUyeEkle frmuyeekle = new frmUyeEkle();
            frmuyeekle.TopLevel = false;
            icerikPaneli.Controls.Add(frmuyeekle);
            frmuyeekle.Show();
            frmuyeekle.Dock = DockStyle.Fill;
            frmuyeekle.BringToFront();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            if (frmGiris.girisTur == "Yönetici") { 
            frmAyarlar frmayarlar = new frmAyarlar();
            frmayarlar.TopLevel = false;
            icerikPaneli.Controls.Add(frmayarlar);
            frmayarlar.Show();
            frmayarlar.Dock = DockStyle.Fill;
            frmayarlar.BringToFront();
            }

            if (frmGiris.girisTur == "Personel")
            {
                frmAyarlarPersonel frmayarlar = new frmAyarlarPersonel();
                frmayarlar.TopLevel = false;
                icerikPaneli.Controls.Add(frmayarlar);
                frmayarlar.Show();
                frmayarlar.Dock = DockStyle.Fill;
                frmayarlar.BringToFront();
            }
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            if (frmGiris.girisTur == "Yönetici")
            {
                yoneticiMenu.Visible = true;
            }
            genelIcerik();
        }
    }
}
