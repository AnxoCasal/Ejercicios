
//#define KEYCODE
using Microsoft.VisualBasic.Devices;

namespace Ejer1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender == this)
            {
                this.Text = "x:" + e.X + "  y:" + e.Y;
            }
            else if (sender.GetType() == typeof(Button))
            {
                this.Text = "x:" + (e.X + ((Button)sender).Left) + "  y:" + (e.Y + ((Button)sender).Top);
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Form1";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.Aqua;
            }
            else if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.Red;
            }
            else
            {
                button1.BackColor = Color.Aqua;
                button2.BackColor = Color.Red;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.White;
            }
            else if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.White;
            }
            else
            {
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Mi Aplicación",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
 == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

#if KEYCODE
            this.Text = e.KeyChar.ToString();
#endif
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Text = "Form1";
            }
            else
            {
#if !KEYCODE
                this.Text = e.KeyCode.ToString();
#endif
            }
        }
    }
}