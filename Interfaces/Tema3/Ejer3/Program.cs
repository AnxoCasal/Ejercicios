using System.Collections;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace ejer3
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

        public virtual bool introducir()
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
                return true;
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
            return false;
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
        {
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
        public override bool introducir()
        {
            base.introducir();
            try
            {
                Console.WriteLine("Depart?");
                Depart = Console.ReadLine();
                Console.WriteLine("Subordinados?");
                Subordinados = Int32.Parse(Console.ReadLine());
                return true;
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
            return false;
        }
        public Directivo()
        {

        }
        public Directivo(String nombre, String apellidos, int edad, string dni, string depart, double beneficios, int subordinados) : base(nombre, apellidos, edad, dni)
        {
            this.depart = depart;
            this.beneficios = beneficios;
            this.subordinados = subordinados;
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
            Directivo directivo = this;

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

    class GestorPersonas
    {

        public ArrayList personas = new ArrayList();
        public int posicion(int edad)
        {
            int cont = 0;

            for (int i = 0; i < personas.Count; i++)
            {
                if (((Persona)personas[i]).Edad > edad)
                {
                    return i;
                }
            }

            return -1;
        }

        public int posicion(string apellido)
        {

            int cont = 0;

            for (int i = 0; i < personas.Count; i++)
            {
                if (((Persona)personas[i]).Apellido.StartsWith(apellido))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool eliminar(int? min, int max)
        {

            if (min == null)
            {
                min = 0;
            }

            if (min < 0 || max < 0 || max <= min || min > personas.Count - 1 || max > personas.Count)
            {
                return false;
            }
            else
            {

                personas.RemoveRange((int)min, max);

                return true;
            }
        }
    }
    class IU
    {
        static GestorPersonas gestor = new GestorPersonas();

        public static void Inicio()
        {
            Empleado empleado = new Empleado("Carlos", "diaz", 12, "asdadas", 2441241, "124141");
            gestor.personas.Add(empleado);
            empleado = new Empleado("PAblo", "casal", 22, "asdadas", 2441241, "124141");
            gestor.personas.Add(empleado);
            Directivo directivo = new Directivo("Anxo", "Rodriguez", 30, "498591295", "Ventas", 421412, 2);
            gestor.personas.Add(directivo);

            int index;
            bool salir = false;
            int min = 0;
            int max = 0;
            bool okay;
            string menu = String.Format(
                "\n\r1- Insertar nueva persona" +
                "\n\r2- Eliminar personas" +
                "\n\r3- Visualizar lista" +
                "\n\r4- Visualizar persona" +
                "\n\r5- Salir\n\r");
            do
            {
                Console.Write(menu);
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        Console.WriteLine("¿Que clase de persona quiere agregar? (empleado/directivo)");
                        string tipo = Console.ReadLine();
                        switch (tipo)
                        {
                            case "empleado":
                                Empleado empleadoNew = new Empleado();
                                empleado.introducir();
                                index = gestor.posicion(empleado.Edad);
                                if (index == -1)
                                {
                                    gestor.personas.Add(empleado);
                                }
                                else
                                {
                                    gestor.personas.Insert(index, empleado);
                                }
                                break;
                            case "directivo":
                                Directivo directivoNew = new Directivo();
                                directivo.introducir();
                                index = gestor.posicion(directivo.Edad);
                                if (index == -1)
                                {
                                    gestor.personas.Add(directivo);
                                }
                                else
                                {
                                    gestor.personas.Insert(index, directivo);
                                }
                                break;
                            default:
                                Console.WriteLine("Opcion invalida");
                                break;
                        }
                        break;
                    case "2":

                        do
                        {
                            Console.WriteLine("Seleccione indices a eliminar");
                            okay = Int32.TryParse(Console.ReadLine(), out min);
                            if (okay)
                            {
                                okay = Int32.TryParse(Console.ReadLine(), out max);
                            }
                            if (!okay) Console.WriteLine("Indices invalidos");
                        } while (!okay);

                        if (gestor.eliminar(min, max))
                        {
                            Console.WriteLine("Se ah eliminado correctamente ");
                        }
                        else
                        {
                            Console.WriteLine("No se a podido eliminar");
                        }

                        break;
                    case "3":
                        string datos;
                        string name;
                        string surname;
                        datos = String.Format("{0,3} {1,-10} {2,-20} {3,-4} {4,4}", "COD", "Name", "Surname", "Type", "Age");
                        Console.WriteLine(datos);
                        foreach (Object persona in gestor.personas)
                        {
                            string type = "E";
                            if (persona.GetType() == typeof(Directivo))
                            {
                                type = "D";
                            }

                            name = ((Persona)persona).Nombre;
                            if (name.Length > 10)
                            {
                                name = name.Substring(0, 7) + "...";
                            }

                            surname = ((Persona)persona).Apellido;
                            if (surname.Length > 10)
                            {
                                surname = surname.Substring(0, 7) + "...";
                            }

                            datos = String.Format("{0,3} {1,-10} {2,-20} {3,4} {4,4}", gestor.personas.IndexOf(persona), name, surname, type, ((Persona)persona).Edad);
                            Console.WriteLine(datos);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Apellido de la persona que desea:");
                        index = gestor.posicion(Console.ReadLine());
                        if (index < 0)
                        {
                            Console.WriteLine("Persona no encontrada");
                        }
                        else
                        {

                            if (gestor.personas[index].GetType() == typeof(Directivo))
                            {
                                ((Directivo)gestor.personas[index]).mostrar();
                                ((Directivo)gestor.personas[index]).ganarPasta(100);
                            }
                            else
                            {
                                ((Empleado)gestor.personas[index]).mostrar();
                            }
                        }
                        break;
                    case "5":
                        salir = !salir;
                        break;
                    default:
                        break;
                }
            } while (!salir);
        }
    }

    class Prueba
    {
        static void Main()
        {
            IU.Inicio();
        }

        public static void Dineros(IPastaGansa IPastaGansa)
        {
            Console.WriteLine("Cuanta pasta ah ganado la empresa");
            Console.WriteLine("Has ganado" + IPastaGansa.ganarPasta(Double.Parse(Console.ReadLine())) + "€");
        }
    }
}
