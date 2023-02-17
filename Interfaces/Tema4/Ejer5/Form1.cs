using System.Collections;
using Timer = System.Windows.Forms.Timer;

namespace Ejer5
{
    public partial class Form1 : Form
    {
        Timer myTimer;
        int cont = 0;
        string title = "ListBoxes - Programa de Anxo Casal";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myTimer = new Timer();
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 200;
            myTimer.Start();
        }

        public void TimerEventProcessor(Object myobjecte, EventArgs eventArgs)
        {
            cont++;
            if (cont > title.Length)
            {
                cont = 0;
            }
            if (cont%2==0)
            {
                this.Icon = Icon.ExtractAssociatedIcon("C:\\Users\\AnxoC\\Pictures\\Saved Pictures\\engranaje1.ico");
            } else
            {
                this.Icon = Icon.ExtractAssociatedIcon("C:\\Users\\AnxoC\\Pictures\\Saved Pictures\\engranaje2.ico");
            }
            this.Text = title.Substring(title.Length - cont);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool exists = false;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (textBox1.Text.Equals(listBox1.Items[i].ToString()) || textBox1.Text.Equals(""))
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                listBox1.Items.Add(textBox1.Text);
            }
            label1.Text = listBox1.Items.Count.ToString();
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
                {
                    listBox1.Items.RemoveAt(int.Parse(listBox1.SelectedIndices[i].ToString()));
                }
                if (listBox1.SelectedIndices.Count > 0)
                {
                    listBox1.Items.RemoveAt(int.Parse(listBox1.SelectedIndices[0].ToString()));
                }
                label1.Text = listBox1.Items.Count.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
                {
                    if (!listBox2.Items.Contains(listBox1.SelectedItems[i].ToString()))
                    {
                        listBox2.Items.Add(listBox1.SelectedItems[i].ToString());
                    }
                }
                if (listBox1.SelectedIndices.Count > 0)
                {
                    for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
                    {
                        listBox1.Items.RemoveAt(int.Parse(listBox1.SelectedIndices[i].ToString()));
                    }
                    if (listBox1.SelectedIndices.Count > 0)
                    {
                        listBox1.Items.RemoveAt(int.Parse(listBox1.SelectedIndices[0].ToString()));
                    }
                }
                label1.Text = listBox1.Items.Count.ToString();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listBox2.SelectedIndices.Count; i++)
                {
                    if (!listBox1.Items.Contains(listBox2.SelectedItems[i].ToString()))
                    {
                        listBox1.Items.Add(listBox2.SelectedItems[i].ToString());
                    }
                }
                for (int i = 0; i < listBox2.SelectedIndices.Count; i++)
                {
                    listBox2.Items.RemoveAt(int.Parse(listBox2.SelectedIndices[i].ToString()));
                }
                if (listBox2.SelectedIndices.Count > 0)
                {
                    listBox2.Items.RemoveAt(int.Parse(listBox2.SelectedIndices[0].ToString()));
                }
                label1.Text = listBox1.Items.Count.ToString();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = listBox1.SelectedIndices.Count.ToString();
        }
    }
}