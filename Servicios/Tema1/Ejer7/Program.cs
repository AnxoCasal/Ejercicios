namespace ejer7
{
    class ejer7
    {

        static readonly private object k = new object();
        static readonly private object w = new object();
        static Random rand = new Random();
        static int cont = 0;
        static bool stop = false;
        static bool first = false;
        static bool finish = false;
        static string animation = "|/-\\";
        static int contAnimation = 0;

        static void Main()
        {
            Console.SetCursorPosition(2, 4);
            Console.Write("Player1");
            Console.SetCursorPosition(16, 4);
            Console.Write("Player2");
            Console.SetCursorPosition(12, 7);
            Console.Write(cont);


            Thread hilo1 = new Thread(Player1);
            Thread hilo2 = new Thread(Player2);
            Thread hilo3 = new Thread(Display);
            hilo1.IsBackground = true;
            hilo2.IsBackground = true;
            hilo3.IsBackground = true;
            hilo1.Start();
            hilo2.Start();
            hilo3.Start();
            lock (k)
            {
                Monitor.Wait(k);
            }

            Console.SetCursorPosition(6, 8);
            if (cont <= -20)
            {
                Console.Write("GANO EL PLAYER-2");
            }
            else if (cont >= 20)
            {
                Console.Write("GANO EL PLAYER-1");
            }
            Console.ReadKey();
        }

        static private void Player1()
        {
            int num = 0;


            while (!finish)
            {
                lock (k)
                {
                    if (!finish)
                    {
                        Console.SetCursorPosition(5, 5);
                        num = rand.Next(1, 10);
                        if (num == 5 || num == 7)
                        {
                            if (stop)
                            {
                                cont += 5;
                            }
                            else
                            {
                                cont++;
                                stop = true;
                                first = true;
                            }
                        }
                        Console.Write(num);
                        Console.SetCursorPosition(11, 7);
                        Console.Write(" " + cont + " ");
                        if (cont >= 20)
                        {
                            finish = true;
                            Monitor.Pulse(k);
                        }
                    }
                }
                Thread.Sleep(rand.Next(100, num * 100));
            }
        }
        static private void Player2()
        {
            int num = 0;

            while (!finish)
            {
                lock (k)
                {
                    if (!finish)
                    {
                        Console.SetCursorPosition(19, 5);
                        num = rand.Next(1, 10);
                        if (num == 5 || num == 7)
                        {
                            if (!stop && first)
                            {
                                cont -= 5;
                            }
                            else
                            {
                                cont--;
                                stop = false;
                                lock (w)
                                {
                                    Monitor.Pulse(w);
                                }
                            }
                        }
                        Console.Write(num);
                        Console.SetCursorPosition(11, 7);
                        Console.Write(" " + cont + " ");
                        if (cont <= -20)
                        {
                            finish = true;
                            Monitor.Pulse(k);
                        }
                    }
                }
                Thread.Sleep(rand.Next(100, num * 100));
            }
        }
        static private void Display()
        {
            do
            {
                if (!stop)
                {

                    lock (k)
                    {
                        Console.SetCursorPosition(12, 5);

                        Console.Write(animation[contAnimation%4]);
                        contAnimation++;
                    }
                    Thread.Sleep(200);
                }
                else
                {
                    lock (w)
                    {
                        Monitor.Wait(w);
                    }
                }
            } while (!finish);
        }
    }
}