using System;
using System.Reflection;

public delegate void MyDelegate();
class ejer2
{

    static bool MenuGenerator(string[] nombres, MyDelegate[] delegados)
    {
        if(nombres == null || delegados == null)
        {
            return false;
        }
        if (nombres.Length != delegados.Length)
        {
            return false;
        }
        else
        {
            bool exit = false;
            do
            {
                int cont = 0;
                Console.WriteLine("Choose your option\n\r");
                Array.ForEach(nombres, item =>
                {
                    cont++;
                    Console.WriteLine(cont + "- " + item);
                }
                );
                cont++;
                Console.WriteLine(cont + "- Exit");

                int opt;
                bool success = Int32.TryParse(Console.ReadLine().Trim(), out opt);

                if (success)
                {
                    if (cont == opt)
                    {
                        return true;
                    }
                    else
                    {
                        if (opt > delegados.Length || opt < 0)
                        {
                            Console.WriteLine("Opcion invalida");
                        }
                        else
                        {
                            delegados[opt - 1]();
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Opcion invalida");
                }

            } while (!exit);
            return true;

        }

    }

    static void Main(string[] args)
    {

        bool error = MenuGenerator(new string[] { "Op1", "Op2", "Op3" }, new MyDelegate[] {
            () => { Console.WriteLine("A"); },
            () => { Console.WriteLine("B"); },
            () => { Console.WriteLine("C"); }
});

        if (!error)
        {
            Console.WriteLine("Nombres y funciones de diferentes longitudes");
        }
    }
}