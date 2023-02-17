using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ShiftServer
{

    internal class Executer
    {
        public static void Main()
        {
            ShiftServer ss = new ShiftServer();
            ss.Init();
        }
    }


    class ShiftServer
    {
        static string[] users;
        static ArrayList waitQueue = new ArrayList();
        static String pinPath = (Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\shiftPass");
        static String usersPath = (Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\users.txt");
        static String waitQueuePath = (Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\waitQueue.txt");
        static bool socketError = true;
        static IPEndPoint ipend;
        static int port = 31416;
        static Socket s;

        public ShiftServer() { }

        public void Init()
        {
            while (socketError)
            {
                socketError = false;
                ipend = new IPEndPoint(IPAddress.Any, port);
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    s.Bind(ipend);
                    s.Listen(10);
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    if (port == 31416)
                    {
                        port = 1024;
                    }
                    else
                    {
                        port++;
                    }
                    socketError = true;
                }
            }

            Console.WriteLine("Server working on ip: "+ipend.Address+" & port: "+ipend.Port);

            ReadNames(usersPath);
            ReadWaitQueu(waitQueuePath);


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
            catch (System.Net.Sockets.SocketException)
            {
            }
        }

        public void ReadNames(string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                users = text.Split(";");
            }
            catch (IOException)
            {
                Console.WriteLine("File Error");
            }
        }
        public int ReadPin(string path)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.OpenOrCreate))
                {
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        int pin = br.ReadInt16();
                        if (pin < 10000 && pin >= 0)
                        {
                            return pin;
                        }
                    }
                }
                return -1;

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public void WritePin(string path, int pin)
        {

            using (Stream stream = File.Open(path, FileMode.OpenOrCreate))
            {
                using (BinaryWriter bw = new BinaryWriter(stream))
                {
                    bw.Write(pin);
                }
            }
        }

        public void ReadWaitQueu(String path)
        {
            using (Stream stream = File.Open(path, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    while (sr.Peek() != -1)
                    {
                        waitQueue.Add(sr.ReadLine());
                    }
                }
            }
        }

        public void saveQueue(String path)
        {

            using (Stream stream = File.Open(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter sr = new StreamWriter(stream))
                {
                    foreach (string item in waitQueue)
                    {
                        sr.WriteLine(item);
                    }
                }
            }
        }

        public void hiloCliente(Object socket)
        {
            string user;
            Socket cliente = (Socket)socket;
            IPEndPoint ieCliente = (IPEndPoint)cliente.RemoteEndPoint;
            Console.WriteLine("Connected with client {0} at port {1}", ieCliente.Address, ieCliente.Port);

            using (NetworkStream ns = new NetworkStream(cliente))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                try
                {
                    user = sr.ReadLine();
                    user = user.Substring(5);
                    if (user == "admin")
                    {
                        sw.WriteLine("Introduzca PIN");
                        sw.Flush();
                        if (sr.ReadLine() == ReadPin(pinPath).ToString())
                        {

                            sw.WriteLine("PIN OK");
                            sw.Flush();
                            while (true)
                            {
                                string msg = sr.ReadLine();
                                if (msg.StartsWith("del "))
                                {
                                    int pos;
                                    msg = msg.Substring(4);
                                    if (int.TryParse(msg, out pos) && pos <= waitQueue.Count && pos > 0)
                                    {
                                        waitQueue.RemoveAt(pos - 1);
                                        saveQueue(waitQueuePath);
                                    }
                                }
                                else if (msg.StartsWith("chpin "))
                                {
                                    int pin;
                                    msg = msg.Substring(6);
                                    if (int.TryParse(msg, out pin) && pin < 10000 && pin >= 0)
                                    {
                                        WritePin(pinPath, pin);
                                    }
                                }
                                else if (msg == "exit")
                                {
                                    break;
                                }
                                else if (msg == "shutdown")
                                {
                                    saveQueue(waitQueuePath);
                                    s.Close();
                                }

                            }
                        }
                        else
                        {
                            sw.WriteLine("PIN INCORRECTO");
                            sw.Flush();
                        }
                    }
                    else
                    {
                        foreach (string userName in users)
                        {
                            if (user == userName)
                            {
                                sw.WriteLine("OK");
                                sw.Flush();
                                string msg = sr.ReadLine();
                                if (msg == "list")
                                {
                                    sw.WriteLine("LISTA DE USUARIOS:");
                                    foreach (string entrada in waitQueue)
                                    {
                                        sw.WriteLine(entrada);
                                    }
                                    sw.Flush();
                                }
                                else if (msg == "add")
                                {
                                    waitQueue.Add(userName + " " + DateTime.Now.ToString());
                                    saveQueue(waitQueuePath);
                                    sw.WriteLine("OK");
                                    sw.Flush();
                                }
                            }
                        }
                    }
                    cliente.Close();
                }
                catch (InvalidEnumArgumentException e)
                {
                    sw.WriteLine(e.Message);
                    sw.Flush();
                }
                catch (IOException)
                {

                }
            }
        }

    }

}