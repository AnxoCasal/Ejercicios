using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

namespace ejer1
{

    public interface IPastaGansa
    {
        public double ganarPasta(double beneficiosTotales);
    }
    abstract class Persona
    {
        private string nombre;
        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }

        private string apellido;
        public string Apellido
        {
            set
            {
                apellido = value;
            }
            get
            {
                return apellido;
            }
        }

        private int edad;
        public int Edad
        {
            set
            {
                if (value < 0)
                {
                    edad = 0;
                }
                else
                {
                    edad = value;
                }
            }
            get
            {
                return edad;
            }
        }

        private string dni;
        public string DNI
        {

            set
            {
                dni = value;
            }
            get
            {
                int letra = 0;
                string[] control = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
                try
                {
                    letra = Int32.Parse(dni) % 23;
                }
                catch (FormatException)
                {
                    return "";
                }
                return dni + control[letra];
            }


        }

        public virtual void mostrar()
        {
            Console.WriteLine("Nombre - " + Nombre);
            Console.WriteLine("Apellido - " + Apellido);
            Console.WriteLine("DNI - " + DNI);
            Console.WriteLine("Edad - " + Edad);
        }

        public virtual void introducir()
        {
            try
            {
                Console.WriteLine("Nombre?");
                Nombre = Console.ReadLine();
                Console.WriteLine("Apellido?");
                Apellido = Console.ReadLine();
                Console.WriteLine("DNI?");
                DNI = Console.ReadLine();
                Console.WriteLine("Edad?");
                Edad = Int32.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ERROR DE DATOS");
            }
            catch (OverflowException)
            {
                Console.WriteLine("ERROR DE DATOS");
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR DE DATOS");
            }
        }

        public abstract double hacienda();

        public Persona(string nombre, string apellido, int edad, string dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.DNI = dni;
        }

        public Persona() :
            this("", "", 0, "")
        { }
    }

    class Empleado : Persona
    {
        private int irpf;
        public int IRPF
        {
            get
            {
                return irpf;
            }
        }


        private double salario;
        public double Salario
        {
            set
            {
                if (value < 0)
                {
                    salario = 0;
                }
                salario = value;
                if (salario < 600)
                {
                    irpf = 7;
                }
                else if (salario < 3000)
                {
                    irpf = 15;
                }
                else
                {
                    irpf = 20;
                }
            }
            get
            {
                return salario;
            }
        }
        private string tlf;
        public string TLF
        {
            set
            {
                tlf = value;
            }
            get
            {
                return "+34" + tlf;
            }
        }

        public override void mostrar()
        {
            base.mostrar();
            Console.WriteLine("IRPF - " + IRPF + "%");
            Console.WriteLine("Salario - " + Salario);
            Console.WriteLine("Telefono - " + TLF);
            Console.WriteLine("Hacienda - " + hacienda());
        }

        public void mostrar(int opt)
        {//hola
            switch (opt)
            {
                case 1:
                    Console.WriteLine("Nombre - " + Nombre);
                    break;
                case 2:
                    Console.WriteLine("Apellido - " + Apellido);
                    break;
                case 3:
                    Console.WriteLine("DNI - " + DNI);
                    break;
                case 4:
                    Console.WriteLine("Edad - " + Edad);
                    break;
                case 5:
                    Console.WriteLine("IRPF - " + IRPF + "%");
                    break;
                case 6:
                    Console.WriteLine("Salario - " + Salario);
                    break;
                case 7:
                    Console.WriteLine("Telefono - " + TLF);
                    break;
                case 8:
                    Console.WriteLine("Hacienda - " + hacienda());
                    break;
                default:
                    Console.WriteLine("Fuera de rango");
                    break;
            }
        }

        public override double hacienda()
        {
            double valor = (irpf * salario) / 100;
            return valor;
        }

        public Empleado(String nombre, String apellidos, int edad, string dni, double salario, string tlf) : base(nombre, apellidos, edad, dni)
        {
            Salario = salario;
            TLF = tlf;
        }

        public Empleado() : base()
        {
            Salario = 0;
            TLF = "0";
        }
    }

    class Directivo : Persona, IPastaGansa
    {

        private string depart;
        public string Depart
        {
            set { depart = value; }
            get { return depart; }
        }

        private double beneficios;
        public double Beneficios
        {
            get { return beneficios; }
        }

        private int subordinados;
        public int Subordinados
        {
            set
            {
                subordinados = value;
                if (value < 10)
                {
                    beneficios = 2;
                }
                else if (value >= 10 && value <= 50)
                {
                    beneficios = 3.5;
                }
                else if (value > 50)
                {
                    beneficios = 4;
                }
            }
            get { return subordinados; }
        }

        public override void mostrar()
        {
            base.mostrar();
            Console.WriteLine("Depart - " + Depart);
            Console.WriteLine("Beneficios - " + Beneficios);
            Console.WriteLine("Subordinados - " + Subordinados);
            Console.WriteLine("Hacienda - " + hacienda());
        }
        public override void introducir()
        {
            base.introducir();
            try
            {
                Console.WriteLine("Depart?");
                Depart = Console.ReadLine();
                Console.WriteLine("Subordinados?");
                Subordinados = Int32.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ERROR DE DATOS");
            }
            catch (OverflowException)
            {
                Console.WriteLine("ERROR DE DATOS");
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR DE DATOS");
            }
        }
        public static Directivo operator --(Directivo directivo)
        {
            if (directivo.beneficios <= 1)
            {
                directivo.beneficios = 0;
            }
            else
            {
                directivo.beneficios = directivo.beneficios - 1;
            }
            return directivo;
        }
        private double PastaGanada = 0;

        public double ganarPasta(double beneficiosTotales)
        {
            Directivo directivo = this;// new Directivo();

            double beneficiosPersonales;
            if (beneficiosTotales < 0)
            {
                directivo--;
                beneficiosPersonales = 0;
                PastaGanada = PastaGanada + beneficiosPersonales;
                return beneficiosPersonales;
            }
            else
            {
                beneficiosPersonales = (beneficiosTotales * Beneficios) / 100;
                PastaGanada = PastaGanada + beneficiosPersonales;
                return PastaGanada;
            }
        }

        public override double hacienda()
        {
            double dineroLimpio = (PastaGanada * 30) / 100;
            return dineroLimpio;
        }
    }

    class EmpleadoEspecial : Empleado, IPastaGansa
    {
        public double ganarPasta(double beneficiosTotales)
        {
            if (beneficiosTotales <= 0)
            {
                return 0;
            }
            else
            {
                double beneficiosPersonales = (beneficiosTotales * 5) / 100;
                return beneficiosPersonales;
            }
        }

        public override double hacienda()
        {
            return (base.hacienda() * 5) / 100;
        }

    }

    class Prueba
    {
        static void Main()
        {
            Empleado empleado = new Empleado("Paco", "DeLucia", 22, "39491482", 2500, "652521552");
            empleado.mostrar(6);
            Console.WriteLine("\r\n");


            //    Directivo directivo = new Directivo();
            //    directivo.introducir();
            //    directivo.mostrar();
            //   Dineros(directivo);
            //    Console.WriteLine("\r\n");

            //   EmpleadoEspecial empleadoEspecial = new EmpleadoEspecial();
            //    empleadoEspecial.introducir();
            //    empleadoEspecial.mostrar();
            //    Dineros(empleadoEspecial);
            //    Console.WriteLine("\r\n");

        }

        public static void Dineros(IPastaGansa IPastaGansa)
        {
            Console.WriteLine("Cuanta pasta ah ganado la empresa");
            Console.WriteLine("Has ganado" + IPastaGansa.ganarPasta(Double.Parse(Console.ReadLine())) + "€");
        }
    }
}