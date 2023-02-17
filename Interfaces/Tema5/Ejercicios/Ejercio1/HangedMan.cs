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
    public partial class HangedMan : Control
    {

        private int errors = 0;
        public HangedMan()
        {
            InitializeComponent();
            this.Size = new Size(185, 280);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            Pen pen = new Pen(Color.Red, 5);
            g.DrawLine(pen, widthConverter(5), heightConverter(5), widthConverter(5), heightConverter(270));
            g.DrawLine(pen, widthConverter(5), heightConverter(5), widthConverter(125), heightConverter(5));

            if (errors >= 1)
            {
                g.DrawLine(pen, widthConverter(125), heightConverter(200), widthConverter(180), heightConverter(270));

                if (errors >= 2)
                {
                    g.DrawLine(pen, widthConverter(125), heightConverter(200), widthConverter(70), heightConverter(270));
                    if (errors >= 3)
                    {
                        g.DrawLine(pen, widthConverter(125), heightConverter(100), widthConverter(125), heightConverter(200));
                        if (errors >= 4)
                        {
                            g.DrawLine(pen, widthConverter(125), heightConverter(110), widthConverter(180), heightConverter(175));
                            if (errors >= 5)
                            {
                                g.DrawLine(pen, widthConverter(125), heightConverter(110), widthConverter(70), heightConverter(175));
                                if (errors >= 6)
                                {
                                    g.DrawEllipse(pen, widthConverter(100), heightConverter(50), widthConverter(50), heightConverter(50));
                                    if (errors >= 7)
                                    {
                                        g.DrawLine(pen, widthConverter(125), heightConverter(5), widthConverter(125), heightConverter(50));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        [Category("Game")]
        [Description("Number of errors")]
        public int NumOfErrors
        {
            set
            {
                if (value < 0)
                {
                    errors = 0;
                }
                else
                {
                    errors = value;
                }
                this.OnErrorsChanged(EventArgs.Empty);
                if (errors >= 0)
                {
                    this.OnGameOver(EventArgs.Empty);
                }
                this.Refresh();
            }
            get
            {
                return errors;
            }
        }

        [Category("Game")]
        [Description("Se cambiaron los errores")]
        public event EventHandler ErrorsChanged;

        public virtual void OnErrorsChanged(EventArgs e)
        {
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, e);
            }
        }

        [Category("Game")]
        [Description("Game Over")]
        public event EventHandler GameOver;

        public virtual void OnGameOver(EventArgs e)
        {
            if (GameOver != null)
            {
                GameOver(this, e);
            }
        }

        private int widthConverter(int n)
        {
            return ((n * this.Width) / 185);
        }
        private int heightConverter(int n)
        {
            return ((n * this.Height) / 270);
        }
    }
}
