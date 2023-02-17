using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer3
{
    public partial class Marco : Form
    {
        private string ruta;
        public Marco(String path, String nombre)
        {
            InitializeComponent();
            ruta = path;
            this.Text = nombre;
        }

        private void Marco_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = this.Size;
            pictureBox1.Image = Image.FromFile(ruta);
        }
    }
}
