using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer2Client
{

    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\curroServerData.txt"))
            {

                using (StreamReader reader = File.OpenText(Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\curroServerData.txt"))
                {
                    ipTxtBox.Text = reader.ReadLine();
                    portTxtBox.Text = reader.ReadLine();
                    userTxtBox.Text = reader.ReadLine();
                }
            }
            else
            {
                ipTxtBox.Text = "";
                portTxtBox.Text = "";
                userTxtBox.Text = "";
            }
        }

        private void conexion(string order)
        {
            try
            {
                IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipTxtBox.Text), int.Parse(portTxtBox.Text));

                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    server.Connect(ie);
                }
                catch (SocketException e)
                {
                    MessageBox.Show(String.Format("Error connection: {0}\nError code: {1}({2})", e.Message, (SocketError)e.ErrorCode, e.ErrorCode));
                }

                try
                {
                    using (NetworkStream ns = new NetworkStream(server))
                    using (StreamWriter sw = new StreamWriter(ns))
                    using (StreamReader sr = new StreamReader(ns))
                    {
                        sw.WriteLine("user " + userTxtBox.Text);
                        sw.Flush();
                        string mesg = sr.ReadLine();
                        if (mesg == "OK")
                        {
                            if (order == "add")
                            {
                                sw.WriteLine("add");
                                sw.Flush();
                                MessageBox.Show(sr.ReadLine());
                            }
                            else if (order == "list")
                            {
                                sw.WriteLine("list");
                                sw.Flush();
                                mesg = sr.ReadToEnd();
                                MessageBox.Show(mesg);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario no encontrado");
                        }
                    }

                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Cant create conection");
                }
                server.Close();
            }
            catch (System.FormatException e)
            {
                MessageBox.Show(e.Message);
            }
            catch(OverflowException e)
            {
                MessageBox.Show(e.Message);
            }
            catch(System.ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            conexion("add");
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            conexion("list");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.WriteAllText(Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\curroServerData.txt", ipTxtBox.Text + "\r\n" + portTxtBox.Text + "\r\n" + userTxtBox.Text);

        }
    }
}
