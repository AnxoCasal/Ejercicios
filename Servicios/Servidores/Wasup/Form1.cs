using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Wasup
{
    public partial class Form1 : Form
    {

        static readonly object k = new object();
        static string username = "";
        static NetworkStream ns;
        static StreamReader sr;
        static StreamWriter sw;
        static TextBox chatroom;
        static string newText;
        static Form thisForm;
        public Form1()
        {
            InitializeComponent();
            chatroom = chatroomTxtBox;
            thisForm = this;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxtBox.Text != "")
            {
                username = usernameTxtBox.Text;

                usernameTxtBox.Visible = false;
                enterBtn.Visible = false;
                usernameLBl.Visible = false;

                inputTxtBox.Visible = true;
                exitBtn.Visible = true;
                userListBtn.Visible = true;
                chatroomTxtBox.Visible = true;
                infoLbl.Visible = true;
                sendBtn.Visible = true;
            }
            connect();
        }

        private static void connect()
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 31416);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            try
            {
                s.Connect(ie);
            }
            catch (SocketException e)
            {
                Console.WriteLine(string.Format("Error connection: {0}\nError code: {1}({2})", e.Message, (SocketError)e.ErrorCode, e.ErrorCode));
            }

            try
            {
                ns = new NetworkStream(s);
                sw = new StreamWriter(ns);
                sr = new StreamReader(ns);

                sw.WriteLine(username);
                sw.Flush();

                Thread hiloReceiver = new Thread(receiver);
                hiloReceiver.IsBackground = true;
                hiloReceiver.Start(sr);
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Imposible conectarse");
            }

        }

        static void receiver(Object sro)
        {
            try
            {
                Delega d = new Delega(cambiaTexto);

                string message = sr.ReadLine();
                thisForm.Invoke(d, message, chatroom);
                while (true)
                {
                    message = sr.ReadLine();
                    thisForm.Invoke(d, message, chatroom);
                }
            }
            catch (System.ObjectDisposedException) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = inputTxtBox.Text;
            if (message != "")
            {
                sw.WriteLine(message);
                sw.Flush();
                inputTxtBox.Text = "";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ns != null && sw != null && sr != null)
            {

                sr.Close();
                sw.Close();
                ns.Close();
            }
        }


        delegate void Delega(string texto, TextBox t);
        private static void cambiaTexto(string texto, TextBox t)
        {
            t.AppendText(texto + Environment.NewLine);
        }

        private void userListBtn_Click(object sender, EventArgs e)
        {
            string message = "#list";
            sw.WriteLine(message);
            sw.Flush();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            string message = "#exit";
            sw.WriteLine(message);
            sw.Flush();
            this.Close();
        }
    }
}
