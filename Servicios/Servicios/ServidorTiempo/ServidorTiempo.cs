using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServidorTiempo
{
    public partial class ServidorTiempo : ServiceBase
    {
        TimeServer ts;
        public ServidorTiempo()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            writeEvent("Service Started");
            ts = new TimeServer();
            Thread hilo = new Thread(ts.init);
            hilo.IsBackground = true;
            hilo.Start();
        }

        protected override void OnStop()
        {
            writeEvent("Service Stoped");
            ts.stop();
        }

        public void writeEvent(string mensaje)
        {
            string nombre = "TimeService";
            string logDestino = "Application";
            if (!EventLog.SourceExists(nombre))
            {
                EventLog.CreateEventSource(nombre, logDestino);
            }
            EventLog.WriteEntry(nombre, mensaje);
        }
    }


    class TimeServer
    {
        static string pass;
        static bool close = false;
        static bool socketError;
        static Socket s;
        static IPEndPoint ie;
        static int socketPort;

        public void init()
        {
            socketPort = portRead(Environment.GetEnvironmentVariable("PROGRAMDATA") + "/port.txt");
            ie = new IPEndPoint(IPAddress.Any, socketPort);
            s = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            try
            {
                s.Bind(ie);
                s.Listen(10);


                string path = Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\pass.txt";
                pass = File.ReadAllText(path);

                writeEvent(String.Format("Server waiting at port {0}", ie.Port));

                try
                {
                    while (!close)
                    {
                        Socket cliente = s.Accept();
                        Thread hilo = new Thread(hiloCliente);
                        hilo.IsBackground = true;
                        hilo.Start(cliente);
                    }
                }
                catch (System.Net.Sockets.SocketException) { }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                writeEvent("Both ports unabalible");
            }
        }

        public void stop()
        {
            s.Close();
        }

        public int portRead(string path)
        {
            try
            {
                return int.Parse(File.ReadAllText(path));
            }
            catch (IOException)
            {
                writeEvent("FilePortError");
                return 1048;
            }
            catch (ArgumentException)
            {
                writeEvent("FilePortError");
                return 1048;
            }
            catch (FormatException)
            {
                writeEvent("FilePortError");
                return 1048;
            }
            catch (OverflowException)
            {
                writeEvent("FilePortError");
                return 1048;
            }
        }
        public void writeEvent(string mensaje)
        {
            string nombre = "TimeService";
            string logDestino = "Application";
            if (!EventLog.SourceExists(nombre))
            {
                EventLog.CreateEventSource(nombre, logDestino);
            }
            EventLog.WriteEntry(nombre, mensaje);
        }

        static void hiloCliente(object socket)
        {
            string mensaje;
            Socket cliente = (Socket)socket;
            IPEndPoint ieCliente = (IPEndPoint)cliente.RemoteEndPoint;
            Console.WriteLine("Connected with client {0} at port {1}",
            ieCliente.Address, ieCliente.Port);
            using (NetworkStream ns = new NetworkStream(cliente))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                try
                {
                    mensaje = "";
                    mensaje += sr.ReadLine();
                    if (mensaje.StartsWith("close"))
                    {
                        if (mensaje == "close " + pass)
                        {
                            throw new IOException();
                        }
                        else
                        {
                            throw new InvalidEnumArgumentException("InvalidPassword");
                        }
                    }
                    else
                    {
                        switch (mensaje)
                        {
                            case "time":
                                sw.WriteLine(DateTime.Now.ToShortTimeString());
                                break;
                            case "date":
                                sw.WriteLine(DateTime.Today.ToShortDateString());
                                break;
                            case "all":
                                sw.WriteLine(DateTime.Now.ToString());
                                break;
                        }
                        sw.Flush();
                    }
                }
                catch (IOException)
                {
                    sw.WriteLine("Cerrando servidor");
                    sw.Flush();
                    s.Close();
                }
                catch (InvalidEnumArgumentException e)
                {
                    sw.WriteLine(e.Message);
                    sw.Flush();
                }
                Console.WriteLine("Finished connection with {0}:{1}",
                ieCliente.Address, ieCliente.Port);
            }
            cliente.Close();

        }
    }
}
