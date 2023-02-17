using Ejer5;

namespace ejer5
{
    class executable
    {
        static readonly private object k = new object();
        static bool end = false;
        static bool exit = false;
        static Random rand= new Random();    

        static void Main()
        {
            do
            {
                bool okay = true;
                end = false;
                exit = false;
                int apuesta = 0;

                Thread[] hilos = new Thread[5];
                Caballo[] caballos = new Caballo[5];
                ConsoleColor[] colores = { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Magenta };

                do
                {
                    Console.Clear();
                    if (!okay)
                    {
                        Console.SetCursorPosition(91, 27);
                        Console.WriteLine("ESO ES UNA GIRAFA NO UN CABALLO ;)");
                    }
                    Console.SetCursorPosition(100, 24);
                    Console.WriteLine("¡ELIJE TU CABALLO!");
                    Console.SetCursorPosition(106, 25);
                    Console.WriteLine("(1-5)");
                    Console.SetCursorPosition(98, 29);
                    Console.WriteLine("ESCRIBE EXIT PARA SALIR");
                    Console.SetCursorPosition(108, 26);
                    string respuesta = Console.ReadLine();
                    if (respuesta.ToLower()=="exit")
                    {
                        exit = true;
                        okay = true;
                    }
                    else
                    {
                        okay = Int32.TryParse(respuesta, out apuesta);
                        Console.Clear();
                        if (apuesta < 1 || apuesta > 5) { okay = false; }
                    }


                } while (!okay);

                Console.Clear();
                if (!exit)
                {
                    for (int i = 5; i < 55; i++)
                    {
                        Console.SetCursorPosition(159, i);
                        if (i % 2 == 0)
                        {
                            Console.Write("//");
                        }
                        else
                        {
                            Console.Write("\\\\");
                        }
                    }

                    for (int i = 0; i < 160; i++)
                    {
                        Console.SetCursorPosition(i, 4);
                        Console.Write("_");
                        Console.SetCursorPosition(i, 5);
                        Console.Write("_");
                        Console.SetCursorPosition(i, 53);
                        Console.Write("_");
                        Console.SetCursorPosition(i, 54);
                        Console.Write("_");

                    }

                    for (int i = 0; i < hilos.Length; i++)
                    {
                        lock (k)
                        {

                            hilos[i] = new Thread(juego);
                            caballos[i] = new Caballo(i + 1, colores[i]);
                            caballos[i].dibujar();
                            hilos[i].Start(caballos[i]);
                        }
                    }
                    lock (k)
                    {
                        Monitor.Wait(k);
                    }
                    foreach (Caballo caballo in caballos)
                    {
                        if (caballo.posicion > 150)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                caballo.correr();
                                caballo.dibujar();
                                Thread.Sleep(100);
                            }

                            Console.SetCursorPosition(185, 29);
                            Console.Write("¡EL CABALLO Nº" + caballo.num + " GANÓ LA CARRERA!");
                            Console.SetCursorPosition(190, 30);
                            if (apuesta.Equals(caballo.num.ToString()))
                            {
                                Console.Write("¡HAS GANADO LA APUESTA!");
                            }
                            else
                            {
                                Console.Write("¡HAS PERDIDO LA APUESTA!");
                            }
                            Console.ReadKey();
                        }
                    }
                    Console.ResetColor();

                }
            } while (!exit);
        }

        static void juego(object a)
        {
            do
            {
                lock (k)
                {
                    if (!end)
                    {
                        ((Caballo)a).correr();
                        ((Caballo)a).dibujar();
                        if (((Caballo)a).posicion > 150)
                        {
                            end = true;
                        }
                    }
                    else
                    {
                        Monitor.Pulse(k);
                    }
                }
                    Thread.Sleep(rand.Next(10,40));
            } while (!end);
        }
    }
}