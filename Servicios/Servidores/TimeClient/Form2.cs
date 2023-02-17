using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeClient
{
    public partial class Form2 : Form
    {
        public string ip = "";
        public string port = "";

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ip = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            port = textBox2.Text;

        }
    }
}
