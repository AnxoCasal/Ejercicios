using System.Collections;

class ejer1
{
    static void Main()
    {

        bool exit = false;
        Hashtable datosRAM = new Hashtable();
        //datosRAM.Add("192.168.0.1", 16);
        //datosRAM.Add("192.168.0.2", 8);
        //datosRAM.Add("192.168.0.3", 4);
        //datosRAM.Add("192.168.0.4", 24);

        do
        {

            int opt;
            bool okay;

            do
            {
                Console.WriteLine("\n\rSistema de gestion de RAM\n\r1-Introducir\n\r2-Borrar\n\r3-Mostrar\n\r4-Mostrar todo\n\r5-Salir");
                okay = Int32.TryParse(Console.ReadLine(), out opt);
            } while (!okay || (opt > 5 || opt < 1));

            switch (opt)
            {
                case 1:
                    introducir(datosRAM);
                    break;
                case 2:
                    borrar(datosRAM);
                    break;
                case 3:
                    mostrar(datosRAM);
                    break;
                case 4:
                    mostrarTodo(datosRAM);
                    break;

                case 5:
                    exit = !exit;
                    break;
                default:
                    break;
            }
        } while (!exit);
    }

    public static void introducir(Hashtable tablaIP)
    {
        bool okay;
        String[] IP_security;
        string newIP;
        int intip;

        do
        {
            okay = true;
            Console.WriteLine("IP?");
            newIP = Console.ReadLine();
            IP_security = newIP.Split('.');

            foreach (String ip in IP_security)
            {
                if (ip.Length < 1 || ip.Length > 3 || !Int32.TryParse(ip, out intip) || IP_security.Length != 4 || intip > 255 || intip < 0)
                {
                    okay = false;
                }
            }

            if (!okay)
            {
                Console.WriteLine("IP INVALIDA");
            }

        } while (!okay);



        int newRam;
        do
        {

            Console.WriteLine("RAM?");
            okay = Int32.TryParse(Console.ReadLine(), out newRam);

            if (newRam < 0 || !okay)
            {
                okay = false;
                Console.WriteLine("Ram tiene que ser un numero entero y positivo");
            }
            else
            {
                try
                {

                    tablaIP.Add(newIP, newRam);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("ESTA IP ESTA DUPLICADA");
                    okay = true;
                }
            }

        } while (!okay);

    }

    public static void borrar(Hashtable tablaIP)
    {
        Console.WriteLine("Que IP quieres eliminar");
        string ip = Console.ReadLine();
        if (tablaIP.Contains(ip))
        {
            tablaIP.Remove(ip);
            Console.WriteLine("La IP " + ip + " ah sido borrada");
        }
        else
        {
            Console.WriteLine("La IP " + ip + " no existe");
        }
    }

    public static void mostrar(Hashtable tablaIP)
    {
        Console.WriteLine("Que IP quieres consultar");
        string ip = Console.ReadLine();
        if (tablaIP.Contains(ip))
        {
            Console.WriteLine("{0}", tablaIP[ip]);
        }
        else
        {
            Console.WriteLine("La IP " + ip + " no existe");
        }
    }

    public static void mostrarTodo(Hashtable tablaIP)
    {
        foreach (DictionaryEntry de in tablaIP)
        {
            Console.WriteLine("IP-{0}\r\nRAM-{1}\r\n", de.Key, de.Value);
        }
    }

}