using System.Net;

namespace ChatClient
{
    using System.Net.Sockets;
    using System.Net;
    using System.ComponentModel;
    class ChatClient
    {

        static readonly object k = new object();

        public static void Main()
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 31416);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Username:");
            string username = Console.ReadLine();

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
                using (NetworkStream ns = new NetworkStream(s))
                using (StreamWriter sw = new StreamWriter(ns))
                using (StreamReader sr = new StreamReader(ns))
                {
                    sw.WriteLine(username);
                    sw.Flush();

                    Thread hiloReceiver = new Thread(receiver);
                    hiloReceiver.IsBackground = true;
                    hiloReceiver.Start(sr);

                    Thread hiloSender = new Thread(sender);
                    hiloSender.Start(sw);
                    lock (k)
                    {
                        Monitor.Wait(k);
                    }
                }
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Imposible conectarse");
            }
        }
        static void sender(Object swo)
        {
            StreamWriter sw = (StreamWriter)swo;
            string message;
            while (true)
            {
                message = Console.ReadLine();
                sw.WriteLine(message);
                sw.Flush();
                if (message == "#exit")
                {
                    lock (k)
                    {
                        Monitor.Pulse(k);
                    }
                    break;
                }
            }
        }

        static void receiver(Object sro)
        {
            StreamReader sw = (StreamReader)sro;
            string message = sw.ReadLine();
            Console.WriteLine(message);
            while (true)
            {
                message = sw.ReadLine();
                Console.WriteLine(message);
            }
        }
    }
}
