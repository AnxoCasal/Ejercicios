using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Practica_guiada
{

    public enum eMarca
    {
        Nada, Cruz, Circulo, Imagen
    }

    public partial class EtiquetaAviso : Control
    {
        public EtiquetaAviso()
        {
            InitializeComponent();
            this.Refresh();
        }

        private eMarca marca = eMarca.Nada;
        private bool degradado = false;
        private Color color1 = Color.Black;
        private Color color2 = Color.White;
        private Image image = null;
        private int offsetX;


        [Category("Apparence")]
        [Description("Indica el tipo de marca que aparece junto al texto")]
        public eMarca Marca
        {
            set
            {
                marca = value;
                this.Refresh();
            }
            get
            {
                return marca;
            }
        }


        [Category("Apparence")]
        [Description("Selecciona la imagen a aparecer")]
        public Image picture
        {
            set
            {
                image = value;
                this.Refresh();
            }
            get
            {
                return image;
            }
        }

        [Category("Apparence")]
        [Description("Activa o desactiva el degradado del fondo")]
        public bool Degradado
        {
            set
            {
                degradado = value;
                this.Refresh();
            }
            get
            {
                return degradado;
            }
        }

        [Category("Apparence")]
        [Description("Indica el primer color del degradado del fondo")]
        public Color Color1
        {
            set
            {
                color1 = value;
                this.Refresh();
            }
            get
            {
                return color1;
            }
        }

        [Category("Apparence")]
        [Description("Indica el Segundo color del degradado del fondo")]
        public Color Color2
        {
            set
            {
                color2 = value;
                this.Refresh();
            }
            get
            {
                return color2;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (degradado)
            {
                LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 10), new Point(this.Width, 10), Color1, Color2);
                e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
            }

            int grosor = 0; //Grosor de las líneas de dibujo
            offsetX = 0; //Desplazamiento a la derecha del texto
            int offsetY = 0; //Desplazamiento hacia abajo del texto
                             // Altura de fuente, usada como referencia en varias partes
            int h = this.Font.Height;
            //Esta propiedad provoca mejoras en la apariencia o en la eficiencia
            // a la hora de dibujar
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Dependiendo del valor de la propiedad marca dibujamos una
            //Cruz o un Círculo
            switch (Marca)
            {
                case eMarca.Circulo:
                    grosor = 20;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor,
                    h, h);
                    offsetX = h + grosor;
                    offsetY = grosor;
                    break;
                case eMarca.Cruz:
                    grosor = 3;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, h, h);
                    g.DrawLine(lapiz, h, grosor, grosor, h);
                    offsetX = h + grosor;
                    offsetY = grosor / 2;
                    //Es recomendable liberar recursos de dibujo pues se
                    //pueden realizar muchos y cogen memoria
                    lapiz.Dispose();
                    break;
                case eMarca.Imagen:
                    if (this.image != null)
                    {
                        g.DrawImage(this.image, 0, 0, this.Font.Height, this.Font.Height);
                        offsetX = this.Font.Height;
                    }
                    break;
            }
            //Finalmente pintamos el Texto; desplazado si fuera necesario
            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY);
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY * 2);
            b.Dispose();

        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        [Category("Inputs")]
        [Description("Se lanza al clickar en la Marca")]
        public event System.EventHandler ClickEnMarca;

        protected virtual void OnClickEnMarca(EventArgs e)
        {
            if (ClickEnMarca != null)
            {
                ClickEnMarca(this, e);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.X < offsetX)
            {
                this.OnClickEnMarca(EventArgs.Empty);
            }
        }

    }
}
