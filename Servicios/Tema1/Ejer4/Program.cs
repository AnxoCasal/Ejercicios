using System.Runtime.CompilerServices;

class ejer4
{
    static readonly private object l = new object();
    static bool hiloEnd1 = false;
    static bool hiloEnd2 = false;
    static int i = 0;
    static void Main()
    {

        Thread thread = new Thread(() =>
        {
            do
            {

                lock (l)
                {
                    if (!hiloEnd1 && !hiloEnd2)
                    {
                        i++;
                        if (i < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (i >= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.Write(i);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tHILO 1");

                    }
                }
            } while (i < 1000 && !hiloEnd1 && !hiloEnd2);

            lock (l)
            {

                Monitor.Pulse(l);
                if (!hiloEnd2)
                {

                    hiloEnd1 = true;

                }
            }
        });
        thread.Start();



        Thread thread2 = new Thread(() =>
        {
            do
            {
                lock (l)
                {
                    if (!hiloEnd1 && !hiloEnd2)
                    {
                        i--;
                        if (i < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (i >= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.Write(i);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tHILO 2");
                    }
                }
            } while (i > -1000 && !hiloEnd1 && !hiloEnd2);
            lock (l)
            {
                Monitor.Pulse(l);
                if (!hiloEnd1)
                {

                    hiloEnd2 = true;

                }
            }
        });
        thread2.Start();
        lock (l)
        {
            Monitor.Wait(l);
        }
        if (hiloEnd1)
        {
            Console.WriteLine("Ganó el primer hilo");
        }
        else if (hiloEnd2)
        {
            Console.WriteLine("Ganó el segundo hilo");
        }

    }
}