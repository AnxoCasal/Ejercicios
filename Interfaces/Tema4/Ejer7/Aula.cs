using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer7
{
    internal class Aula
    {
        Random random = new Random();
        private int[,] Notas;
        private string[] Alumnos;
        public int this[int alumno, int asignatura]
        {
            get
            {
                alumno--;
                asignatura--;
                return Notas[alumno, asignatura];
            }
        }

        public Aula(string[] alumnos)
        {
            Notas = new int[alumnos.Length, 4];

            for (int i = 0; i < Notas.GetLength(0); i++)
            {
                for (int j = 0; j < Notas.GetLength(1); j++)
                {
                    Notas[i, j] = random.Next(1, 10);
                }
            }

            Alumnos = new string[alumnos.Length];
            int cont = 0;

            foreach (string s in alumnos)
            {
                Alumnos[cont] = (s.Trim(' ')).ToUpper();
                cont++;
            }
        }

        public Aula(string alumnos)
        {
            Alumnos = alumnos.Split(',');
            int cont = 0;

            foreach (string s in alumnos.Split(','))
            {
                Alumnos[cont] = (s.Trim(' ')).ToUpper();
                cont++;
            }

            Notas = new int[Alumnos.Length, 4];

            for (int i = 0; i < Notas.GetLength(0); i++)
            {
                for (int j = 0; j < Notas.GetLength(1); j++)
                {
                    Notas[i, j] = random.Next(1, 10);
                }
            }
        }

        public void minsAndMaxs(int alumno, ref int minimo, ref int maximo)
        {
            alumno--;
            minimo = Notas[alumno, 0];
            maximo = Notas[alumno, 0];

            for (int j = 0; j < Notas.GetLength(1); j++)
            {
                if (Notas[alumno, j] > maximo)
                {
                    maximo = Notas[alumno, j];
                }
                if (Notas[alumno, j] < minimo)
                {
                    minimo = Notas[alumno, j];
                }
            }
        }

        public float media()
        {
            float media = 0;
            int cont = 0;
            foreach (int i in Notas)
            {
                media += i;
            }
            media = media / Notas.Length;
            return media;
        }

        public float mediaAlumno(int alumno)
        {
            float media = 0;
            int cont = 0;
            alumno--;
            for (int i = 0; i < Notas.GetLength(1); i++)
            {
                media += Notas[alumno, i];
            }
            media = media / Notas.GetLength(1);
            return media;
        }

        public float mediaAsignatura(int asignatura)
        {
            float media = 0;
            int cont = 0;
            asignatura--;
            for (int i = 0; i < Notas.GetLength(0); i++)
            {
                media += Notas[i, asignatura];
            }
            media = media / Notas.GetLength(0);
            return media;
        }

        public int[] mostrarAlumno(int alumno)
        {
            alumno--;

            int[] notasAlumnos = new int[Notas.GetLength(1)];

            for (int j = 0; j < Notas.GetLength(1); j++)
            {
                notasAlumnos[j] = Notas[alumno, j];
            }

            return notasAlumnos;
        }

        public string[,] mostrarAsignatura(int asignatura)
        {
            string[,] alumnosYnotas = new string[Alumnos.Length,2];

            for (int i = 0; i < Alumnos.Length; i++)
            {
                alumnosYnotas[i, 0] = Alumnos[i];
            }

            for (int j = 0; j < Notas.GetLength(0); j++)
            {
                alumnosYnotas[j, 1] = Notas[j, asignatura].ToString();
            }

            return alumnosYnotas;
        }

        public int[,] mostrarTabla()
        {
            int[,] result = new int[Alumnos.Length,4];


            for (int i = 0; i < Notas.GetLength(0); i++)
            {
                for (int j = 0; j < Notas.GetLength(1); j++)
                {
                    result[i, j] = Notas[i, j];
                }
            }

            return result;
        }
    }
}
