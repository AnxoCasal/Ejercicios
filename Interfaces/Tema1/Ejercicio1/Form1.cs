namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            double num1 = 0;
            double num2 = 0;
            string result = "";
            try
            {
                num1 = double.Parse(text1);
                num2 = double.Parse(text2);
                result = (num1 + num2).ToString();
                label2.Text = "= "+result;
            }
            catch (FormatException)
            {
                label2.Text = "= SYNTAX ERROR";
            } 

        }
    }
}