using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Ejercio1
{
    public partial class Spotify : UserControl
    {

        private Image pause = Image.FromFile("C:\\Users\\AnxoC\\Pictures\\pause.png");
        private Image play = Image.FromFile("C:\\Users\\AnxoC\\Pictures\\playy.png");
        private bool playing = true;
        private int mins = 0;
        private int secs = 0;

        public Spotify()
        {
            InitializeComponent();
            lblCrono.Text = "00:00";
        }

        protected void play_pause_Click(object sender, EventArgs e)
        {

            if (playing)
            {
                play_pause.Image = pause;
            }
            else
            {
                play_pause.Image = play;
            }
            playing = !playing;
            OnPlayClick(e);
        }

        [Category("Reproducer")]
        [Description("Repdroducer state")]
        public bool isPlaying
        {
            get
            {
                return playing;
            }
        }

        [Category("Apperence")]
        [Description("Minutos de la Label")]
        public int minutes
        {
            set
            {
                if (value > 59)
                {
                    value = 0;
                }else if (value < 0)
                {
                    throw new ArgumentException();
                }

                mins = value;
                lblCrono.Text = String.Format("{0,2:D2}:{1,2:D2}", mins,secs);
            }
            get
            {
                return mins;
            }
        }

        [Category("Apperence")]
        [Description("Segundos de la Label")]
        public int seconds
        {
            set
            {
                if (value > 59)
                {
                    value = value % 60;
                    OnDesbordaTiempo(EventArgs.Empty);
                }else if (value < 0)
                {
                    throw new ArgumentException();
                }
                secs = value;
                lblCrono.Text = String.Format("{0,2:D2}:{1,2:D2}", mins, secs);
            }
            get
            {
                return secs;
            }
        }


        [Category("Inputs")]
        [Description("Se lanza cuando se pulsa el boton play/pause")]
        public event System.EventHandler PlayClick;

        protected virtual void OnPlayClick(EventArgs e)
        {
            if (PlayClick != null)
            {
                PlayClick(this, e);
            }
        }


        [Category("Timer")]
        [Description("Se lanza cuando transcurre un minute")]
        public event System.EventHandler DesbordaTiempo;

        public virtual void OnDesbordaTiempo(EventArgs e)
        {
            if (DesbordaTiempo != null)
            {
                DesbordaTiempo(this, e);
            }
        }
    }
}
