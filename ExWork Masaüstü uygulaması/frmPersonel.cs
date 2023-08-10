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
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmPersonel_Paint);
        }

        private void btnGorevTakibi_Click(object sender, EventArgs e)
        {
            frmGorevTakibiPersonel frmgorevtakibipersonel = new frmGorevTakibiPersonel();
            frmgorevtakibipersonel.TopLevel = false;
            icerikPaneli.Controls.Add(frmgorevtakibipersonel);
            frmgorevtakibipersonel.Show();
            frmgorevtakibipersonel.Dock = DockStyle.Fill;
            frmgorevtakibipersonel.BringToFront();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmAyarlarPersonel frmayarlarpersonel = new frmAyarlarPersonel();
            frmayarlarpersonel.TopLevel = false;
            icerikPaneli.Controls.Add(frmayarlarpersonel);
            frmayarlarpersonel.Show();
            frmayarlarpersonel.Dock = DockStyle.Fill;
            frmayarlarpersonel.BringToFront();
        }

        private void frmPersonel_Paint(object sender, PaintEventArgs e)
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
