﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            islemPaneli.Controls.Clear();

            Form3 f3 = new Form3();
            f3.TopLevel = false;
            islemPaneli.Controls.Add(f3);
            f3.Show();
            f3.Dock = DockStyle.Fill;
            f3.BringToFront();
        }
    }
}
