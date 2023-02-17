using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace Ejer3
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void viewProcces_Click(object sender, EventArgs e)
        {
            textBox1.Text = "     NOMBRE     |   ID    | NOMBRE VENTANA\r\n";
            textBox1.Text += "-------------------------------------\r\n";

            Process[] processes = Process.GetProcesses(); ;
            foreach (Process p in processes)
            {
                string nombre = p.ProcessName;
                if (nombre.Length > 15)
                {
                    nombre = nombre.Substring(0, 12) + "...";
                }

                textBox1.Text += String.Format("{0,15} | {1,7} | {2,4}\r\n", nombre, p.Id, p.MainWindowTitle); //Titulo ventana

            }
        }

        private void proccesInfo_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string id = textBox2.Text;
                try
                {
                    Process p = Process.GetProcessById(int.Parse(id));
                    textBox1.Text = String.Format("Nombre: {0}\tID: {1}\tNº Hilos:{2}\tHora de inicio:{3}\r\n", p.ProcessName, p.Id, p.Threads.Count, p.StartTime.ToShortTimeString());
                    textBox1.Text += "--------------------------------------------------------------------------------------------\r\n";
                    textBox1.Text += "THREADS\r\n";
                    textBox1.Text += "--------------------------------------------------------------------------------------------\r\n";
                    ProcessThreadCollection hilos = p.Threads;
                    foreach (ProcessThread t in hilos)
                    {
                        textBox1.Text += String.Format("Thread ID: {0,10}\t |Init {1,6}\t |Priority {2,10}\t |State {3,10}\r\n",
                            t.Id, t.StartTime.ToShortTimeString(), t.PriorityLevel, t.ThreadState);
                    }
                    textBox1.Text += "--------------------------------------------------------------------------------------------\r\n";
                    textBox1.Text += "MODULES\r\n";
                    textBox1.Text += "--------------------------------------------------------------------------------------------\r\n";
                    ProcessModuleCollection modulos = p.Modules;
                    foreach (ProcessModule m in modulos)
                    {
                        textBox1.Text += String.Format(m.FileName) + "\r\n";
                    }
                }
                catch (ArgumentException)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (OverflowException)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    textBox1.Text = ex.Message;
                }
            }
            else
            {
                DialogResult a = MessageBox.Show("Introduzca un PID en el textbox inferior", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void closeProcess_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string id = textBox2.Text;
                try
                {
                    Process p = Process.GetProcessById(int.Parse(id));
                    p.CloseMainWindow();
                    p.Close();
                }
                catch (ArgumentException)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (OverflowException)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    textBox1.Text = ex.Message;
                }
            }
            else
            {
                DialogResult a = MessageBox.Show("Introduzca un PID en el textbox inferior", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void killProcess_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string id = textBox2.Text;
                try
                {
                    Process p = Process.GetProcessById(int.Parse(id));
                    p.Kill();
                }
                catch (ArgumentException)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (OverflowException)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    textBox1.Text = ex.Message;
                }
            }
            else
            {
                DialogResult a = MessageBox.Show("Introduzca un PID en el textbox inferior", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void runApp_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string id = textBox2.Text;
                try
                {
                    Process p = Process.Start(textBox2.Text);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    DialogResult a = MessageBox.Show("ESE PID NO EXISTE", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    textBox1.Text = ex.Message;
                }
            }
            else
            {
                DialogResult a = MessageBox.Show("Introduzca un PID en el textbox inferior", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                textBox1.Text = "";
                string id = textBox2.Text;
                int size = id.Length;
                bool exists = false;
                try
                {

                    foreach (Process p in Process.GetProcesses())
                    {
                        if(p.ProcessName.Substring(0, size).Equals(id))
                        {
                            textBox1.Text += String.Format("Nombre: {0}\tID: {1}\tNº Hilos:{2}\tHora de inicio:{3}\r\n", p.ProcessName, p.Id, p.Threads.Count, p.StartTime.ToShortTimeString());
                            exists = true;
                        }
                    }
                    if (!exists)
                    {
                        textBox1.Text = "No existe ningun proceso que empieze por: " + id;
                    }
                }
                catch (Exception ex)
                {
                    textBox1.Text = ex.Message;
                }
            }
            else
            {
                DialogResult a = MessageBox.Show("Introduzca un PID en el textbox inferior", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }
    }
}