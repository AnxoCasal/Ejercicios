using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ejer8
{
    public partial class Form1 : Form
    {

        Form2 form2;
        PictureBox[] images;
        int selectedImg;
        ArrayList files;

        private FolderBrowserDialog folderBrowserDialog;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            files = new ArrayList();
            btnPrevius.Enabled = false;
            btnNext.Enabled = false;
            anterioToolStripMenuItem.Enabled = false;
            siguienteToolStripMenuItem.Enabled = false;
            lblDataImg.Text = "";
            lblPath.Text = "";

            if (result.Equals(DialogResult.OK))
            {
                if (form2 != null)
                {
                    form2.Close();
                }
                selectedImg = 0;
                panelContainer.Controls.Clear();

                lblPath.Text = folderBrowserDialog.SelectedPath;
                foreach (string file in Directory.GetFiles(folderBrowserDialog.SelectedPath))
                {
                    if (file.EndsWith(".jpeg") || file.EndsWith(".jpg") || file.ToString().EndsWith(".png"))
                    {
                        files.Add(file);
                    }
                }

                images = new PictureBox[files.Count];

                int x = 20;
                int y = 100;

                for (int i = 0; i < files.Count; i++)
                {
                    images[i] = new PictureBox();
                    images[i].Image = new Bitmap(files[i].ToString());
                    images[i].Size = new Size(100, 100);
                    images[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    images[i].Location = new Point(x, y);
                    images[i].Click += ClikImage;
                    images[i].Enabled = true;

                    panelContainer.Controls.Add(images[i]);
                    x += 120;
                    if (x > 460)
                    {
                        x = 20;
                        y += 120;
                    }
                }

                if (images.Length > 0)
                {
                    form2 = new Form2(files);
                    form2.Show();
                    btnPrevius.Enabled = true;
                    btnNext.Enabled = true;
                    anterioToolStripMenuItem.Enabled = true;
                    siguienteToolStripMenuItem.Enabled = true;
                    imgInfo(selectedImg);

                }

            }
            else if (form2 != null)
            {
                panelContainer.Controls.Clear();
                form2.Close();
            }

        }

        private void ClikImage(object? sender, EventArgs e)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].Equals(sender))
                {
                    form2.selectImage(i);
                    selectedImg = i;
                    imgInfo(i);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Visor Imagenes";
        }

        private void btnPrevius_Click(object sender, EventArgs e)
        {
            int change;
            if (sender.Equals(btnPrevius) || sender.Equals(anterioToolStripMenuItem))
            {
                change = -1;
            }
            else
            {
                change = 1;
            }

            if (selectedImg + change >= 0 && selectedImg + change < images.Length)
            {
                selectedImg += change;
                form2.selectImage(selectedImg);
                imgInfo(selectedImg);
            }
        }

        private void btnOpen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.A))
            {
                btnPrevius.PerformClick();
            }
            else if (e.KeyCode.Equals(Keys.D))
            {
                btnNext.PerformClick();
            }
        }

        public void imgInfo(int index)
        {

            FileInfo file = new FileInfo(files[selectedImg].ToString());
            lblDataImg.Text = file.Name;
            if (file.Length > 1000000)
            {
                lblDataImg.Text += " -> " + file.Length / 1000000 + "mb";
            }
            else
            {
                lblDataImg.Text += " -> " + file.Length / 1000 + "kb";
            }
            lblDataImg.Text += " -> HEIGHT: " + Image.FromFile(files[selectedImg].ToString()).Width.ToString();
            lblDataImg.Text += " -> WIDTH: " + Image.FromFile(files[selectedImg].ToString()).Height.ToString();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.Close();
            btnPrevius.Enabled = false;
            btnNext.Enabled = false;
            anterioToolStripMenuItem.Enabled = false;
            siguienteToolStripMenuItem.Enabled = false;
            panelContainer.Controls.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("WANNA EXIT?", "EXIT?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}