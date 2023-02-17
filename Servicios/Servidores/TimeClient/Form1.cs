namespace TimeClient
{

    using System;
    using System.Net;
    using System.Net.Sockets;

    public partial class Form1 : Form
    {
        string ip;
        string port;
        string pass;
        IPEndPoint ie;
        Socket server;

        public Form1()
        {
            InitializeComponent();
            ip = "127.0.0.1";
            port = "31416";
            lblConexion.Text = "IP:" + ip + " - " + "PORT:" + port;

            allBtn.Tag = "all";
            timeBtn.Tag = "time";
            dateBtn.Tag = "date";
            closeBtn.Tag = "close";
        }

        private void createConexion()
        {
            ie = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ie);
            }
            catch (SocketException e)
            {
                resultLbl.Text = string.Format("Error connection: {0}\nError code: {1}({2})", e.Message, (SocketError)e.ErrorCode, e.ErrorCode);
            }
        }

        private void sendInput(string peticion)
        {

            createConexion();
            try
            {
                using (NetworkStream ns = new NetworkStream(server))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    if (peticion == "close")
                    {
                        sw.WriteLine(peticion + " " + txtBoxPass.Text);
                        sw.Flush();
                    }
                    else
                    {
                        sw.WriteLine(peticion);
                        sw.Flush();
                    }

                    resultLbl.Text = sr.ReadToEnd();
                }
                server.Close();

            }
            catch (System.IO.IOException)
            {
                resultLbl.Text = "Imposible connectarse";
            }
        }

        private void allBtns_click(object sender, EventArgs e)
        {
            sendInput(((Button)sender).Tag.ToString());
        }

        private void optionsBtn_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                try
                {
                    new IPEndPoint(IPAddress.Parse(form.ip), Int32.Parse(form.port));
                    this.ip = form.ip;
                    this.port = form.port;
                    lblConexion.Text = "IP:" + ip + " - " + "PORT:" + port;
                }
                catch (Exception)
                {
                    resultLbl.Text = "Invalid IP or PORT";
                }
            }

        }
    }
}