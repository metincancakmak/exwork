using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace istakipsistemi
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sifreGoster_Click(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;
            sifreGoster.Visible = false;
            sifreGizle.Visible = true;
        }

        private void sifreGizle_Click(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = false;
            sifreGoster.Visible = true;
            sifreGizle.Visible = false;
        }
    }
}
