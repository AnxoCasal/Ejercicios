#define depuracion
namespace Ejercicio3
{
    public partial class Form1 : Form
    {
        int credit = 50;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            label2.Text = "CREDIT = " + credit;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            credit = credit - 2;

            int num1 = random.Next(1, 8);
            int num2 = random.Next(1, 8);
            int num3 = random.Next(1, 8);

            textBox1.Text = num1.ToString();
            textBox2.Text = num2.ToString();
            textBox3.Text = num3.ToString();

            if (num1 == num2 && num2 == num3)
            {
                label1.Text = "PREMIO";
                credit = credit + 15;
            }
            else if (num1 == num2 || num1 == num3 || num2 == num3)
            {
                label1.Text = "MINI PREMIO";
#if depuracion
                credit = credit - 5;
#else
                credit = credit + 5;
#endif
            }
            else
            {
                label1.Text = "MÁS SUERTE LA PROXIMA";
            }

            label2.Text = "CREDIT = " + credit;

            textBox1.Text = num1.ToString();
            textBox2.Text = num2.ToString();
            textBox3.Text = num3.ToString();

            if (num1 == num2 && num2 == num3)
            {
                label1.Text = "PREMIO";
                credit = credit + 15;
            }
            else if (num1 == num2 || num1 == num3 || num2 == num3)
            {
                label1.Text = "MINI PREMIO";
#if depuracion
                credit = credit - 5;
#else
                credit = credit + 5;
#endif
            }
            else
            {
                label1.Text = "MÁS SUERTE LA PROXIMA";
            }

            label2.Text = "CREDIT = " + credit;

            if (credit < 2)
            {

                textBox1.Text = "RIP";
                textBox2.Text = "RIP";
                textBox3.Text = "RIP";

                label2.Text = "Game over";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            credit = credit + 5;
            label2.Text = "CREDIT = " + credit;
        }
    }
}