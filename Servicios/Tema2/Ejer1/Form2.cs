using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer1
{
    public partial class Form2 : Form
    {

        string path;
        bool changes;

        public Form2(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = path;
            textBox1.Location = new Point(0, 0);
            textBox1.Size = this.Size;
            textBox1.Text = File.ReadAllText(path);
            changes = false;
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            textBox1.Size = this.Size;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changes)
            {

                DialogResult res = MessageBox.Show("¿Quiere guardar los cambios?", "EXIT", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    File.WriteAllText(path, textBox1.Text);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            changes = true;
        }
    }
}
