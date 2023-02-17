using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer5
{
    internal class Caballo
    {
        private int NUM;
        public int num
        {
            get => NUM;
        }

        private ConsoleColor color;

        private string figura1 =  "           _/\\___";
        private string figura2 = "    ______/   0__|";
        private string figura3;
        private string figura4 = "  /_________/";
        private string figura5 = "   / |   | \\";
        private string figura6 = "  /  |   |  \\";

        private int POSICION;
        public int posicion
        {
            get => POSICION;
        }
        public void correr()
        {
            POSICION++;
        }

        public void dibujar()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(POSICION, ((num - 1) * 10)+7);
            Console.Write(figura1);
            Console.SetCursorPosition(POSICION, ((num - 1) * 10)+8);
            Console.Write(figura2);
            Console.SetCursorPosition(POSICION, ((num - 1) * 10)+9);
            Console.Write(figura3);
            Console.SetCursorPosition(POSICION, ((num - 1) * 10)+10);
            Console.Write(figura4);
            Console.SetCursorPosition(POSICION, ((num - 1) * 10)+11);
            Console.Write(figura5);
            Console.SetCursorPosition(POSICION, ((num - 1) * 10)+12);
            Console.Write(figura6);
        }

        public Caballo(int numero, ConsoleColor color)
        {
            NUM = numero;
            POSICION = 0;
            figura3 = " --/  /" + NUM + "/    /";
            this.color = color;
        }
    }
}
