using Microsoft.VisualBasic.Logging;

namespace Ejer3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "img files|*.jpg;*.jpeg;*.ico;*.png|All files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string path = openFileDialog.FileName;
                    string[] divisor = path.Split(".");
                    if (divisor[1] == "jpeg" || divisor[1] == "jpg" || divisor[1] == "png" || divisor[1] == "ico")
                    {
                        divisor = path.Split("\\");
                        string archivo = divisor[divisor.Length - 1];

                        Form f2 = new Marco(path, archivo);
                        if (checkBox1.Checked)
                        {
                            f2.ShowDialog();
                        }
                        else
                        {
                            f2.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thats not an image");
                    }
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.ForeColor == Color.Red)
            {
                checkBox1.ForeColor = Color.Black;
            }
            else
            {
                checkBox1.ForeColor = Color.Red;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("SEGURO QUE QUIERES SALIR?", "EXIT?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}