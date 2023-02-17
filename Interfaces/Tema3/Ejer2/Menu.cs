using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2
{
    internal class Menu
    {
        private Aula aula;

        public Menu(params string[] alumnos)
        {
            aula = new Aula(alumnos);
        }

        public void inicio()
        {
            bool exit = false;
            do
            {
                try
                {

                    Console.WriteLine("\r\n\r\n\r\nGESTION DE DATOS\r\n1- Calcular la media de notas de toda la tabla.\r\n2- Media de un alumno\r\n3- Media de una asignatura\r\n4- Visualizar notas de un alumno\r\n5- Visualizar notas de una asignatura\r\n6- Nota máxima y mínima de un alumno\r\n7- Visualizar tabla completa\r\n8- Salir");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("La media de la clase es {0:N2}", aula.media());
                            break;

                        case "2":
                            aula.indicesAlumnos();
                            Console.WriteLine("Que alumno quieres consultar?");
                            int alumno = Int16.Parse(Console.ReadLine());
                            Console.WriteLine("La media del alumno es {0:N2}", aula.mediaAlumno(alumno));
                            break;

                        case "3":
                            aula.indicesAsignaturas();
                            Console.WriteLine("Que asignatura quieres consultar?");
                            int asignatura = Int16.Parse(Console.ReadLine());
                            asignatura--;
                            Console.WriteLine("La media de la asignatura {0} es {1:N2}", (asignaturas)asignatura, aula.mediaAsignatura(asignatura));
                            break;

                        case "4":
                            aula.indicesAlumnos();
                            Console.WriteLine("Que alumno quieres consultar?");
                            alumno = Int16.Parse(Console.ReadLine());

                            for (int i = 0; i < 4; i++)
                            {
                                Console.Write("{0,15}", (asignaturas)i);
                            }

                            Console.WriteLine();

                            foreach (int i in aula.mostrarAlumno(alumno))
                            {
                                Console.Write("{0,15}", i);
                            }

                            break;

                        case "5":
                            aula.indicesAsignaturas();
                            Console.WriteLine("Que asignatura quieres consultar?");
                            asignatura = Int16.Parse(Console.ReadLine());
                            asignatura--;
                            Console.WriteLine("La asignatura " + (asignaturas)asignatura + " tiene los siguientes resultados");

                            string[,] result = aula.mostrarAsignatura(asignatura);

                            for (int i = 0; i < result.GetLength(0); i++)
                            {
                                for (int j = 0; j < result.GetLength(1); j++)
                                {
                                    Console.Write("{0,15}", result[i, j]);
                                }
                                Console.WriteLine();
                            }

                            break;

                        case "6":
                            aula.indicesAlumnos();
                            Console.WriteLine("Que alumno quieres consultar?");
                            alumno = Int16.Parse(Console.ReadLine());
                            int min = 0;
                            int max = 0;
                            aula.minsAndMaxs(alumno, ref min, ref max);
                            Console.WriteLine("El alumno tiene una nota minima de " + min + " y una nota maxima de " + max);
                            break;

                        case "7":
                            Console.Write("{0,30}", (asignaturas)0);
                            for (int i = 1; i < 4; i++)
                            {
                                Console.Write("{0,15}", (asignaturas)i);
                            }

                            Console.Write("\r\n");

                            string[,] tabla = aula.mostrarTabla();

                            for (int i = 0; i < tabla.GetLength(0); i++)
                            {
                                for (int j = 0; j < tabla.GetLength(1); j++)
                                {
                                    Console.Write("{0,15}", tabla[i, j]);
                                }
                                Console.Write("\r\n");
                            }

                            break;

                        case "8":
                            exit = !exit;
                            break;

                        default:
                            Console.WriteLine("Valor invalido");
                            break;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Indice invalido");
                }
            } while (!exit);

        }
    }
}
