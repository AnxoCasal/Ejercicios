using System.Collections;

namespace Ejer8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            botones = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button13, button14, button15, button16, };
        }

        double opt;
        double result = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                result = double.Parse(textBox1.Text); if (textBox2.Text != "")
                {
                    switch (opt)
                    {
                        case 0:
                            result = result + double.Parse(textBox1.Text);
                            break;
                        case 1:
                            result = result - double.Parse(textBox1.Text);
                            break;
                        case 2:
                            result = result * double.Parse(textBox1.Text);
                            break;
                        case 3:
                            result = result / double.Parse(textBox1.Text);
                            break;
                    }
                    textBox3.Text = result.ToString();
                    textBox2.Text = textBox2.Text + textBox1.Text + "+";
                }
                else
                {
                    textBox2.Text = textBox2.Text + textBox1.Text + "+";
                }
            }
            opt = 0;
            textBox1.Text = "";


        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                result = double.Parse(textBox1.Text);

                if (textBox2.Text != "")
                {
                    switch (opt)
                    {
                        case 0:
                            result = result + double.Parse(textBox1.Text);
                            break;
                        case 1:
                            result = result - double.Parse(textBox1.Text);
                            break;
                        case 2:
                            result = result * double.Parse(textBox1.Text);
                            break;
                        case 3:
                            result = result / double.Parse(textBox1.Text);
                            break;
                    }
                    textBox3.Text = result.ToString();
                }
                else
                {
                    textBox2.Text = textBox2.Text + textBox1.Text + "-";
                }
            }
            opt = 1;
            textBox1.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                result = double.Parse(textBox1.Text);

                if (textBox2.Text != "")
                {
                    switch (opt)
                    {
                        case 0:
                            result = result + double.Parse(textBox1.Text);
                            break;
                        case 1:
                            result = result - double.Parse(textBox1.Text);
                            break;
                        case 2:
                            result = result * double.Parse(textBox1.Text);
                            break;
                        case 3:
                            result = result / double.Parse(textBox1.Text);
                            break;
                    }
                    textBox3.Text = result.ToString();
                    textBox2.Text = textBox2.Text + textBox1.Text + "*";
                }
                else
                {
                    textBox2.Text = textBox2.Text + textBox1.Text + "*";
                }
            }
            opt = 2;
            textBox1.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                result = double.Parse(textBox1.Text); if (textBox2.Text != "")
                {
                    switch (opt)
                    {
                        case 0:
                            result = result + double.Parse(textBox1.Text);
                            break;
                        case 1:
                            result = result - double.Parse(textBox1.Text);
                            break;
                        case 2:
                            result = result * double.Parse(textBox1.Text);
                            break;
                        case 3:
                            result = result / double.Parse(textBox1.Text);
                            break;
                    }
                    textBox3.Text = result.ToString();
                }
                else
                {
                    textBox2.Text = textBox2.Text + textBox1.Text + "/";
                }
            }
            opt = 3;
            textBox1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            result = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            foreach (Button boton in botones)
            {
                boton.Enabled = true;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                switch (opt)
                {
                    case 0:
                        result = result + double.Parse(textBox1.Text);
                        break;
                    case 1:
                        result = result - double.Parse(textBox1.Text);
                        break;
                    case 2:
                        result = result * double.Parse(textBox1.Text);
                        break;
                    case 3:
                        result = result / double.Parse(textBox1.Text);
                        break;
                }
                textBox3.Text = result.ToString();
                textBox2.Text = textBox2.Text + textBox1.Text + "=";
            }
            else if (textBox1.Text != "")
            {
                result = double.Parse(textBox1.Text);
                textBox2.Text = textBox2.Text + textBox1.Text + "=";
            }
            textBox1.Text = "";
            foreach (Button boton in botones)
            {
                boton.Enabled = false;
            }
        }

        Button[] botones;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}