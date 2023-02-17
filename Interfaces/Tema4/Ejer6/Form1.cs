namespace Ejer6
{
    public partial class Form1 : Form
    {
        int x = 30;
        int y = 60;

        Button[] botonera = new Button[12];
        String[] texts = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "*", "0", "#", };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 pass = new Form2();
            DialogResult res;
            res = pass.ShowDialog();
            if(res != DialogResult.OK)
            {
                this.Close();
            }

            for(int i = 0; i<botonera.Length; i++)
            {
                botonera[i] = new Button();
                botonera[i].Text = texts[i];
                botonera[i].Location = new Point(x, y);
                botonera[i].Size = new Size(100, 30);
                botonera[i].Enabled = true;

                botonera[i].Click += new System.EventHandler(this.btnClick);
                botonera[i].MouseEnter += new System.EventHandler(this.MouseEnter);
                botonera[i].MouseLeave += new System.EventHandler(this.MouseLeave);

                this.Controls.Add(botonera[i]);

                x += 100;
                if (x > 230)
                {
                    x = 30;
                    y += 30;
                }
            }
        }

        void btnClick(Object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightGreen;
            textBox1.Text += ((Button)sender).Text;
        }

        void MouseEnter(Object sender, EventArgs e)
        {
            if(((Button)sender).BackColor!= Color.LightGreen) ((Button)sender).BackColor = Color.LightCoral;
        }

        void MouseLeave(Object sender, EventArgs e)
        {
            if (((Button)sender).BackColor != Color.LightGreen) ((Button)sender).BackColor = Color.LightGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < botonera.Length; i++)
            {
                botonera[i].BackColor = Color.LightGray;
            }
            textBox1.Text = "";
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programa hecho por Anxo Casal");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void grabarNumeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
           SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Seleccionar agenda de telefono";
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.OverwritePrompt = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               StreamWriter s = new StreamWriter(saveFileDialog.FileName, true);
                s.Write(textBox1.Text + "\n");
                s.Close();
            }
        }
    }
}