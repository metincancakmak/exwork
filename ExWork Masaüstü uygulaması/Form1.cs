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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mail = textBox1.Text;
            string parola = textBox2.Text;

            if(mail == "admin" &&  parola == "112233") {
                Form2 f2 = new Form2(); // kullanıcı girişi doğru ise yönetim formuna yönlendiriyoruz.. 
                f2.Show();
                this.Hide();
            }
        }
    }
}
