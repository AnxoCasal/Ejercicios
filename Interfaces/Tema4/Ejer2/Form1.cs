namespace Ejer2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Icon icon = Icon.ExtractAssociatedIcon("C:\\Users\\AnxoC\\Pictures\\Saved Pictures\\icono.ico");
            this.Icon = icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox3.Text, out int color3) && Int32.TryParse(textBox1.Text, out int color1) && Int32.TryParse(textBox2.Text, out int color2))
            {
                if (color1 > 0 && color2 > 0 && color3 > 0 && color1 < 256 && color2 < 256 && color3 < 256)
                {

                    this.BackColor = Color.FromArgb(color1, color2, color3);
                }
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                ((Button)sender).BackColor = Color.Red;
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                ((Button)sender).BackColor = Color.White;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(textBox4.Text);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message+"\r\nWas not found");
                }

            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = button3;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = button2;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are u sure u want to exit?", "Exit?", MessageBoxButtons.OKCancel);
            if(res == DialogResult.Cancel) e.Cancel = true;
        }
    }
}