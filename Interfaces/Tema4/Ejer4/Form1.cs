using Microsoft.VisualBasic.Logging;
using System.Collections;
using Timer = System.Windows.Forms.Timer;

namespace Ejer4
{
    public delegate float MyDelegate(float n1, float n2);

    public partial class Form1 : Form
    {
        Hashtable ht;
        RadioButton[] rb;
        float n1;
        float n2;
        bool ok1;
        bool ok2;
        string operation;
        Timer timer = new Timer();
        int contSecs = 55;
        int contMins = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ht = new Hashtable();
            ht.Add("+", (MyDelegate)((float n1, float n2) => n1 + n2));
            ht.Add("-", (MyDelegate)((float n1, float n2) => n1 - n2));
            ht.Add("*", (MyDelegate)((float n1, float n2) => n1 * n2));
            ht.Add("/", (MyDelegate)((float n1, float n2) => n1 / n2));
            radioButton1.Checked = true;

            timer.Interval = 1000;
            timer.Tick += new EventHandler(cambiarTituloSegs);
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = label2.Text;
            label1.Text = ((MyDelegate)(ht[key]))(float.Parse(textBox1.Text), float.Parse(textBox2.Text)).ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (sender == textBox1)
            {
                ok1 = float.TryParse(textBox1.Text, out n1);
                if (!ok1)
                {
                    textBox1.BackColor = Color.Red;
                }
                else
                {
                    textBox1.BackColor = Color.White;
                }
            }
            else if (sender == textBox2)
            {
                ok2 = float.TryParse(textBox2.Text, out n2);

                if (!ok2)
                {
                    textBox2.BackColor = Color.Red;
                }
                else
                {
                    textBox2.BackColor = Color.White;
                }
            }

            button1.Enabled = ok1 && ok2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = ((RadioButton)sender).Text;
        }

        private void cambiarTituloSegs(Object myObject, EventArgs myEventArgs)
        {
            contSecs++;
            if (contSecs == 60)
            {
                contSecs = 0;
                contMins++;
            }
            String minutero = String.Format("{0,2:D2}:{1,2:D2}", contMins, contSecs);
            this.Text = minutero;
        }


    }
}