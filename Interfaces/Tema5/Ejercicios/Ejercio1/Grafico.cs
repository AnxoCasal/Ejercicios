using System;
using System.Collections;
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
    public partial class Grafico : UserControl
    {
        public enum modes
        {
            Manual, Automatico
        }

        public enum estilos
        {
            Barras, Lienas
        }

        private modes modo = modes.Automatico;
        private estilos estilo = estilos.Barras;
        private int[] tamañoBarras = { 3, 5, 1 };
        private int tmñMax = 50;
        private Pen[] pens = { new Pen(Color.Green, 20), new Pen(Color.Blue, 20), new Pen(Color.Yellow, 20) };
        private String yText = "";
        private String xText = "";


        public Grafico()
        {
            InitializeComponent();
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (estilo == estilos.Barras)
            {

                if (modo == modes.Automatico)
                {
                    for (int i = 0; i < tamañoBarras.Length; i++)
                    {
                        g.DrawLine(pens[i % 3], 25 * i + 10 + this.Font.Height, (this.Height - this.Font.Height), 25 * i + 10 + this.Font.Height, (this.Height - this.Font.Height) - (tamañoBarras[i] * (this.Height - this.Font.Height)) / tamañoBarras.Max());
                    }
                }
                else
                {
                    for (int i = 0; i < tamañoBarras.Length; i++)
                    {
                        if (((tamañoBarras[i] * tmñMax) / tamañoBarras.Max()) < (this.Height - this.Font.Height))
                        {
                            g.DrawLine(pens[i % 3], 25 * i + 10 + this.Font.Height, (this.Height - this.Font.Height), 25 * i + 10 + this.Font.Height, (this.Height - this.Font.Height) - (tamañoBarras[i] * tmñMax) / tamañoBarras.Max());
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Red, 20), 25 * i + 10 + this.Font.Height, (this.Height - this.Font.Height), 25 * i + 10 + this.Font.Height, (this.Height - this.Font.Height) - (tamañoBarras[i] * tmñMax) / tamañoBarras.Max());
                        }
                    }
                }

            }
            else if (estilo == estilos.Lienas)
            {
                Pen pen = new Pen(this.ForeColor, 5);
                if (modo == modes.Automatico)
                {
                    for (int i = 0; i < tamañoBarras.Length - 1; i++)
                    {
                        g.DrawLine(pen, 25 * i + 20 + this.Font.Height * i, (this.Height - this.FontHeight) - ((this.Height * tamañoBarras[i]) / tamañoBarras.Max()) + 20, 25 * (i + 1) + 20 + this.Font.Height * (i + 1), (this.Height - this.FontHeight) - ((this.Height * tamañoBarras[i + 1]) / tamañoBarras.Max()) + 20);
                    }
                }
                else if (modo == modes.Manual)
                {
                    for (int i = 0; i < tamañoBarras.Length - 1; i++)
                    {
                        g.DrawLine(pen, 25 * i + 20 + this.Font.Height * i, (this.Height - this.FontHeight) - ((tmñMax * tamañoBarras[i]) / tamañoBarras.Max()) + 20, 25 * (i + 1) + 20 + this.Font.Height * (i + 1), (this.Height - this.FontHeight) - ((tmñMax * tamañoBarras[i + 1]) / tamañoBarras.Max()) + 20);
                    }
                }
            }

            g.DrawString(xText, this.Font, new SolidBrush(this.ForeColor), new PointF(10, this.Height - this.Font.Height));
            g.RotateTransform(-90);
            g.DrawString(yText, this.Font, new SolidBrush(this.ForeColor), new PointF((-this.Height/4)*3,0));
            g.ResetTransform();

        }


        [Category("Apparence")]
        [Description("Tamaño de las barras del grafico")]
        public int[] Valores
        {
            set
            {
                tamañoBarras = value;
                Refresh();
            }
            get
            {
                return tamañoBarras;
            }
        }


        [Category("Apparence")]
        [Description("Modo de dimensionado de las barras")]
        public modes Modo
        {
            set
            {
                modo = value;
                Refresh();
            }
            get
            {
                return modo;
            }
        }


        [Category("Apparence")]
        [Description("Estilo del grafico")]
        public estilos Estilo
        {
            set
            {
                estilo = value;
                Refresh();
            }
            get
            {
                return estilo;
            }
        }


        [Category("Apparence")]
        [Description("Tamaño maximo de las barras en el modo manual")]
        public int TamañoMax
        {
            set
            {
                tmñMax = value;
                if (tmñMax < 10)
                {
                    tmñMax = 10;
                }
                Refresh();
            }
            get
            {
                return tmñMax;
            }
        }

        [Category("Apparence")]
        [Description("Texto informativo a la izquierda del grafico")]
        public string TextoIzquierda
        {
            set
            {
                yText = value;
                this.Refresh();
            }
            get
            {
                return yText;
            }
        }

        [Category("Apparence")]
        [Description("Texto informativo en el inferior del grafico")]
        public string TextoAbajo
        {
            set
            {
                xText = value;
                this.Refresh();
            }
            get
            {
                return xText;
            }
        }


    }
}
