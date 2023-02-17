using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer8
{
    public partial class Form2 : Form
    {
        ArrayList paths;
        int actualPosition = 0;
        public Form2(ArrayList paths)
        {
            InitializeComponent();
            this.paths = paths;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            pictureBox.Location = new Point(0, 0);
            pictureBox.Image = new Bitmap(paths[actualPosition].ToString());
            this.Size = pictureBox.Size;
            FileInfo file = new FileInfo(paths[0].ToString());
            this.Text = file.Name;
        }

        public void selectImage(int index)
        {
            actualPosition = index;
            pictureBox.Image = new Bitmap(paths[actualPosition].ToString());
            this.Size = pictureBox.Size;
            FileInfo file = new FileInfo(paths[actualPosition].ToString());
            this.Text = file.Name;

        }
    }
}
