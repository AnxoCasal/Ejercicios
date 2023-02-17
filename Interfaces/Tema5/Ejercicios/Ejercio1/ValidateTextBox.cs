using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercio1
{
    public partial class ValidateTextBox : UserControl
    {
        public ValidateTextBox()
        {
            InitializeComponent();
            this.Size = new Size(txtBox.Width + 20, txtBox.Height + 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Green, 1);

            if (tipo == eTipo.Textual)
            {
                int n;
                bool nums = false;
                pen = new Pen(Color.Green, 1);
                foreach (char c in txtBox.Text)
                {
                    if (int.TryParse(c.ToString(), out n))
                    {
                        nums = true;
                    }
                }
                if (nums)
                {
                    pen = new Pen(Color.Red, 1);
                }
            }
            else
            {
                int n;
                if (int.TryParse(txtBox.Text, out n))
                {
                    pen = new Pen(Color.Green, 1);
                }
                else
                {
                    pen = new Pen(Color.Red, 1);
                }
            }

            txtBox.Size = new Size(this.Width - 20, this.Height - 20);
            txtBox.Location = new Point((this.Width/2)-(txtBox.Width/2), (this.Height / 2) - (txtBox.Height / 2));
            g.DrawRectangle(pen,new Rectangle(5,5,this.Width-10,this.Height-10));

        }


        [Category("Inputs")]
        [Description("Cambia el texto del txtBox interno")]
        public string Texto
        {
            set
            {
                txtBox.Text = value;
              //  this.OnTextCambiado(EventArgs.Empty);
                this.Refresh();
            }
            get
            {
                return txtBox.Text;
            }
        }

      // private bool multiline;

        [Category("Apariencia")]
        [Description("Cambia el formate del textbox de 1 linea a multiple")]
        public bool Multilinea
        {
            set
            {
             //   multiline = value;
                txtBox.Multiline = value;
                this.Refresh();
            }
            get
            {
                return txtBox.Multiline;
            }
        }

        public enum eTipo
        {
            Numerico, Textual
        }

        public eTipo tipo = eTipo.Numerico;

        [Category("Funcionamiento")]
        [Description("Cambia el tipo texto entre textual y numerico")]
        public eTipo Tipo
        {
            set
            {
                tipo = value;
                this.Refresh();
            }
            get
            {
                return tipo;
            }
        }

        [Category("Inputs")]
        [Description("Se cambio el contenido del textBox")]
        public event EventHandler TextCambiado;

        public virtual void OnTextCambiado(EventArgs e)
        {
            if (TextCambiado != null)
            {
                TextCambiado(this, e);
            }
            this.Refresh();
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
           
            this.OnTextCambiado(EventArgs.Empty);
        }
    }
}
