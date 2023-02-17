using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Ejercio1
{
    public enum POSICION
    {
        Izquierda, Derecha
    }

    public partial class LblText : UserControl
    {

        private POSICION ePosicion = POSICION.Izquierda;
        private int separacion = 0;

        public LblText()
        {
            InitializeComponent();
            TextLbl = Name;
            TextTxt = "";
            recolocar();
        }

        [Category("Apperence")]
        [Description("Indica si la Labels se encuentra a la izquierda o derecha del componente")]
        public POSICION Posicion
        {
            set
            {
                if (Enum.IsDefined(typeof(POSICION), value))
                {
                    ePosicion = value;
                    OnPosicionChanged(EventArgs.Empty);
                    recolocar();
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return ePosicion;
            }
        }

        [Category("Desing")]
        [Description("Separacion intermedia entre los componentes")]
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    OnSeparacionChanged(EventArgs.Empty);
                    recolocar();
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return separacion;
            }
        }

        [Category("Appearance")]
        [Description("Texto asociado a la Label del control")]
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
                recolocar();
            }
            get
            {
                return lbl.Text;
            }
        }
        [Category("Appearance")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
        {
            set
            {
                txtBox.Text = value;
            }
            get
            {
                return txtBox.Text;
            }
        }

        [Category("Appearance")]
        [Description("Cambia la propiedad PasswordChar del TextBox interno")]
        public char PswChr
        {
            set
            {
                txtBox.PasswordChar = value;
            }
            get
            {
                return txtBox.PasswordChar;
            }
        }


        private void recolocar()
        {
            switch (ePosicion)
            {
                case POSICION.Izquierda:
                    lbl.Location = new Point(0, 0);
                    txtBox.Location = new Point(lbl.Width + Separacion, 0);
                   
                    break;
                case POSICION.Derecha:
                    txtBox.Location = new Point(0, 0);
                    lbl.Location = new Point(txtBox.Width + Separacion, 0);
                 
                    break;
            }
            this.Height = Math.Max(txtBox.Height, lbl.Height);
            this.Width = txtBox.Width + lbl.Width + separacion;
        }



        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Posicion cambia")]
        public event System.EventHandler PosicionChanged;

        public virtual void OnPosicionChanged(EventArgs e)
        {
            if (PosicionChanged != null)
            {
                PosicionChanged(this, e);
            }
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Separacion cambia")]
        public event System.EventHandler SeparacionChanged;

        public virtual void OnSeparacionChanged(EventArgs e)
        {
            if (SeparacionChanged != null)
            {
                SeparacionChanged(this, e);
            }
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Text cambia")]
        public event System.EventHandler TxtChanged;

        public virtual void OnTxtChanged(EventArgs e)
        {
            if (TxtChanged != null)
            {
                TxtChanged(this, e);
            }
        }

        protected void txtBox_TextChanged(object sender, EventArgs e)
        {
            OnTxtChanged(EventArgs.Empty);
        }

        protected void txtBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            recolocar();
        }

        protected void LabelTextBox_SizeChanged(object sender, EventArgs e)
        {
            recolocar();
        }
    }
}
