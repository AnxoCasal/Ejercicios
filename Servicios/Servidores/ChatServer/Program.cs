using System.Net;

namespace chatServer
{
    using System.Net.Sockets;
    using System.Net;
    using System.ComponentModel;
    using System.Collections;
    using System.Reflection.PortableExecutable;

    class chatServer
    {

        static ArrayList streamWriters = new ArrayList();
        static ArrayList users = new ArrayList();
        static readonly object k = new object();
        static bool socketError;
        static int socketPort = 1024;
        static void Main()
        {
            IPEndPoint ie;
            Socket s;

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


            try
            {
                while (true)
                {
                    Socket cliente = s.Accept();
                    Thread hilo = new Thread(hiloCliente);
                    hilo.IsBackground = true;
                    hilo.Start(cliente);
                }
            }
            catch (System.Net.Sockets.SocketException) { }
        }

        public static void hiloCliente(object socket)
        {
            String username = null;
            Socket cliente = null;
            IPEndPoint ieCliente = null;
            NetworkStream ns = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                cliente = (Socket)socket;
                ieCliente = (IPEndPoint)cliente.RemoteEndPoint;


                ns = new NetworkStream(cliente);
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);

                username = sr.ReadLine();
                sender("User connecetd : " + username + "@" + ieCliente.Address);
                lock (k)
                {
                    streamWriters.Add(sw);
                }
                users.Add(username);

                sw.WriteLine("Welcome to de chat room");
                sw.Flush();
                while (true)
                {
                    string message = sr.ReadLine();
                    if (message == "#exit" || message == null)
                    {
                        sender("SYSTEM - " + username + "@" + ieCliente.Address + "  : LEFT THE ROOM");
                        lock (k)
                        {
                            streamWriters.Remove(sw);
                        }
                        users.Remove(username);
                        break;
                    }
                    else if (message == "#list")
                    {
                        foreach (string name in users)
                        {
                            sw.WriteLine("User :" + name);
                        }
                        sw.Flush();
                    }
                    else
                    {
                        sender(username + "@" + ieCliente.Address + ":  " + message);
                    }
                }

                cliente.Close();

            }
            catch (System.IO.IOException)
            {
                cliente.Close();
                sender("SYSTEM - " + username + "@" + ieCliente.Address + "  : LEFT THE ROOM");
                lock (k)
                {
                    streamWriters.Remove(sw);
                }
                users.Remove(username);
            }
            finally
            {
                sw.Close();
                sr.Close();
                ns.Close();
            }
        }

        public static void sender(string message)
        {
            if (streamWriters.Count > 0)
            {
                try
                {
                    lock (k)
                    {
                        foreach (StreamWriter user in streamWriters)
                        {
                            user.WriteLine(message);
                            try
                            {
                                user.Flush();
                            }
                            catch (IOException)
                            {
                                Console.WriteLine("IOException launched");
                            }
                        }
                    }
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("InvalidOperationException launched");
                }


            }
            Console.WriteLine(message);
        }
    }
}
