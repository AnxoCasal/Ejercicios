using System.Collections;

namespace Ejer9
{
    public partial class Form1 : Form
    {
        ArrayList recientes = new ArrayList();
        string path;
        bool edited = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxMain.Height = this.Height - 64;
            textBoxMain.Width = this.Width - 10;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            textBoxMain.Height = this.Height - 64;
            textBoxMain.Width = this.Width - 10;
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (edited)
            {
                if (MessageBox.Show("Has hecho cambios, deseas guardarlos?", "ATENCION", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    guardarToolStripMenuItem.PerformClick();
                }
                edited = false;
            }
            SaveFileDialog svf = new SaveFileDialog();
            svf.Title = "Seleccione el archivo";
            if (svf.ShowDialog() == DialogResult.OK)
            {
                path = svf.FileName;
                newPath();
            }
            edited = false;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edited = false;
            if (path == null)
            {
                nuevoToolStripMenuItem1.PerformClick();
            }
            File.WriteAllText(path, textBoxMain.Text);
        }

        private void abrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edited)
            {
                if (MessageBox.Show("Has hecho cambios, deseas guardarlos?", "ATENCION", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    guardarToolStripMenuItem.PerformClick();
                }
                edited = false;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Seleccione un archivo";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                newPath();
                textBoxMain.Text = File.ReadAllText(path);
                edited = false;
            }
        }

        private void recientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string paths in recientes)
            {
                textBoxMain.Text += "\n" + paths;
            }
        }

        private void newPath()
        {
            this.Text = path;
            if (recientes.Count == 0)
            {
                recientes.Add(path);
            }
            else
            {
                bool exists = false;
                foreach (string reciente in recientes)
                {
                    if (reciente == path)
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    for (int i = recientes.Count - 1; i > 1; i--)
                    {
                        recientes[i - 1] = recientes[i];
                    }
                    recientes[0] = path;
                }
            }
        }

        private void textBoxMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            edited = true;
            if (!this.Text.EndsWith("*"))
            {
                this.Text = this.Text + "*";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Wanna exit?","Exit?",MessageBoxButtons.OKCancel))
            if (edited)
            {

            }
        }
    }
}