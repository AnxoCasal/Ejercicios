using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Ejer2
{
    public partial class Form1 : Form
    {
        ArrayList results = new ArrayList();
        bool mayusMatters = false;
        string[] files;
        readonly private object k = new object();

        public Form1()
        {
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxPath.Text) && textBoxTarget.Text != "")
            {
                results.Clear();
                textBoxResult.Text = "";
                files = Directory.GetFiles(textBoxPath.Text);
                foreach (string file in files)
                {
                    Thread hilo;

                    if (mayusMatters)
                    {
                        hilo = new Thread(contarPalabras);
                        hilo.Start(file);
                    }
                    else
                    {
                        hilo = new Thread(contarPalabrasNonSensitive);
                        hilo.Start(file);
                    }
                }
            }
            else
            {
                textBoxResult.Text = "DIRECTORIO NO EXISTENTE O PALABRA OBJETIVO NO INTRODUCIDA";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                mayusMatters = true;
            }
            else
            {
                mayusMatters = false;
            }
        }

        private void contarPalabras(object objFile)
        {
            string file = objFile.ToString();

            if (File.ReadAllText(file).Contains(textBoxTarget.Text))
            {
                string contenido = File.ReadAllText(file);
                int cont = 0;

                for (int i = 0; i < contenido.Length - textBoxTarget.Text.Length; i++)
                {
                    string comparador = contenido[i].ToString();
                    for (int j = 1; j < textBoxTarget.Text.Length; j++)
                    {
                        comparador += contenido[i + j];
                    }
                    if ((comparador).Equals(textBoxTarget.Text))
                    {
                        cont++;
                    }
                }

                lock (k)
                {
                    results.Add(cont + " Resultados en " + file + "\n\r");
                }
            }
            else
            {
                results.Add("0 Resultados en " + file + "\n\r");
            }

            if (files.Length == results.Count)
            {

                foreach (string result in results)
                {
                    textBoxResult.Text += result + "\n\r";
                }
            }

        }

        private void contarPalabrasNonSensitive(object objFile)
        {
            string file = objFile.ToString();

            if ((File.ReadAllText(file)).ToLower().Contains(textBoxTarget.Text.ToLower()))
            {
                string contenido = File.ReadAllText(file).ToLower();
                int cont = 0;

                for (int i = 0; i < contenido.Length - textBoxTarget.Text.Length; i++)
                {
                    string comparador = contenido[i].ToString();
                    for (int j = 1; j < textBoxTarget.Text.Length; j++)
                    {
                        comparador += contenido[i + j];
                    }
                    if ((comparador).Equals(textBoxTarget.Text.ToLower()))
                    {
                        cont++;
                    }
                }
                lock (k)
                {
                    results.Add(cont + " Resultados en " + file + "\n\r");
                }
            }
            else
            {
                results.Add("0 Resultados en " + file + "\n\r");
            }


            if (files.Length == results.Count)
            {

                foreach (string result in results)
                {
                    textBoxResult.Text += result + "\n\r";
                }
            }
        }
    }
}