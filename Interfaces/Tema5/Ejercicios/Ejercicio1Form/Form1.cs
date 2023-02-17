using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblText2.Posicion == Ejercio1.POSICION.Derecha)
            {
                lblText2.Posicion = Ejercio1.POSICION.Izquierda;
            }
            else
            {
                lblText2.Posicion = Ejercio1.POSICION.Derecha;
            }
            lblText2.Separacion += 10;
        }

        private void lblText1_PosicionChanged(object sender, EventArgs e)
        {
            this.Text += lblText2.Posicion.ToString();
        }

        private void lblText1_SeparacionChanged(object sender, EventArgs e)
        {
            this.Text += " " + lblText2.Separacion;
        }

        private void lblText1_KeyUp(object sender, KeyEventArgs e)
        {
            this.Text = lblText2.TextTxt.ToString();
        }

        private void lblText2_TxtChanged(object sender, EventArgs e)
        {
            Random random = new Random();
            random.Next(255);
            this.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
        }
    }
}
