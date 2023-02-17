using System.Net.Sockets;
using System.Net;
using System.ComponentModel;

namespace servers
{
    class TimeServer
    {
        static string pass;
        static bool close = false;
        static bool socketError;
        static Socket s;
        static IPEndPoint ie;
        static int socketPort = 135;
        static void Main(string[] args)
        {
            do
            {
                socketError = false;
                ie = new IPEndPoint(IPAddress.Any, socketPort);
                s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    s.Bind(ie);
                    s.Listen(10);
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    socketPort++;
                    socketError = true;
                }

            } while (socketError);


            string path = Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\pass.txt";
            pass = File.ReadAllText(path);

            Console.WriteLine("Server waiting at port {0}", ie.Port);

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