using System;
bool enter = false;
bool exit = false;
int opt = 0;

do
{
    do
    {
        try
        {
            Console.WriteLine("\n\rSELECTOR DE JUEGOS");
            Console.WriteLine("------------------");
            Console.WriteLine("1- DELVIL´S DICES");
            Console.WriteLine("2- GUESS THE NUMBER");
            Console.WriteLine("3- Quiniela");
            Console.WriteLine("4- JUGAR A TODOS");
            Console.WriteLine("5- EXIT\r\n");
            opt = Int16.Parse(Console.ReadLine());
            if (opt < 1 || opt > 5)
            {
                throw new FormatException("");
            }
            else
            {
                enter = true;
            }
            Console.WriteLine("" + opt);

        }
        catch (FormatException)
        {
            Console.WriteLine("CARACTER INVALIDO\r\n");
        }
        catch (OverflowException)
        {
            Console.WriteLine("CARACTER INVALIDO\r\n");
        }
    } while (!enter);

    switch (opt)
    {
        case 1:
            juego1();
            if (opt == 4)
            {
                goto case 2;
            }
            break;

        case 2:
            juego2();
            if (opt == 4)
            {
                goto case 3;
            }
            break;

        case 3:
            juego3();
            break;

        case 4:
            goto case 1;
        case 5:
            exit = true;
            break;

        default:
            break;
    }
} while (!exit);

static void juego1()
{
    bool good = false;
    int caras;
    int guess = 0;
    do
    {
        try
        {
            Random random = new Random();


            Console.WriteLine("\r\nCUANTAS CARAS TIENE TU DADO?");
            caras = Int16.Parse(Console.ReadLine());
            if (caras < 2)
            {
                Console.WriteLine("Dado imposible");
            }
            else
            {
                Console.WriteLine("\r\nQUE VA A SACAR TU DADO?");
                guess = Int16.Parse(Console.ReadLine());
                if (guess > caras || guess < 1)
                {
                    Console.WriteLine("ASI NO PUEDES GANAR");
                }
                else
                {
                    good = true;

                    int cont = 0;

                    int[] resultados = new int[10];
                    for (int i = 0; i < 10; i++)
                    {
                        resultados.SetValue(random.Next(1, caras + 1), i);
                    }
                    Console.WriteLine("\r\nEl dado se lanza 10 veces y salen los siguientes resultados");
                    foreach (int i in resultados)
                    {
                        Console.WriteLine("" + i);

                        if (i == guess)
                        {
                            cont++;
                        }
                    }
                    if (cont == 0)
                    {
                        Console.WriteLine("\r\nQUE MALA SUERTE, FALLASTE TODAS!");
                    }
                    else
                    {
                        Console.WriteLine("\r\nHAS ACERTADO " + cont + " VECES");
                    }
                }
            }
        }

        catch (FormatException)
        {
            Console.WriteLine("CARACTER INVALIDO\r\n");
        }
        catch (OverflowException)
        {
            Console.WriteLine("CARACTER INVALIDO\r\n");
        }
    } while (!good);
}

static void juego2()
{
    Random random = new Random();
    bool good = false;

    Console.WriteLine("\r\nAdivina el numero! (1-100)");
    int objetivo = random.Next(0, 101);
    int intento = -1;


    for (int i = 5; i >= 1; i--)
    {
        do
        {
            try
            {
                Console.WriteLine("\n\rTienes " + i + " intentos" + objetivo);
                intento = Int16.Parse(Console.ReadLine());
                if (intento < 1 || intento > 100)
                {
                    throw new FormatException("");
                }
                if (intento == objetivo)
                {
                    i = 0;
                    Console.WriteLine("\r\nHAS ACERTADO!\r\n");
                }
                else if (i == 1)
                {
                    Console.WriteLine("\r\nHAS PERDIDO!\r\n");
                }
                else if (intento < objetivo)
                {
                    Console.WriteLine("El numero es mas grande que " + intento);
                }
                else if (intento > objetivo)
                {
                    Console.WriteLine("El numero es mas pequeño que " + intento);
                }
                good = true;

            }
            catch (FormatException)
            {
                Console.WriteLine("CARACTER FUERA DE RANGO");
            }
            catch (OverflowException)
            {
                Console.WriteLine("CARACTER FUERA DE RANGO");
            }
        } while (!good);
    }

}

static void juego3()
{
    Random random = new Random();
    Console.WriteLine("\r\nJUGUEMOS A LA QUINIELA\r\n");

    for (int i = 0; i < 14; i++)
    {
        int posibilidades = random.Next(0, 101);

        switch (posibilidades)
        {
            case >= 1 and <= 60:
                Console.WriteLine("1");
                break;
            case >= 61 and <= 85:
                Console.WriteLine("X");
                break;
            case >= 86 and <= 100:
                Console.WriteLine("3");
                break;
        }
    }
}