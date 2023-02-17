namespace ejer6
{
    class ejer6
    {
        public static bool factorial(int n, ref int result)
        {
            if (n < 10 && n > 0)
            {
                int i = 1;
                while (i != n)
                {
                    i++;
                    result = result * i;
                }
                return true;
            }
            else
            {

                return false;
            }
        }

        public static void asteriscos(int n=10)
        {
            Random r = new Random();
            try
            {
                for (int i = 0; i < n; i++)
                {
                    Console.SetCursorPosition(r.Next(21),r.Next(11));
                    Console.WriteLine("*");
                }
                Console.SetCursorPosition(0, 11);
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        static void Main()
        {
            int result = 1;
            if (factorial(51, ref result))
            {
                Console.WriteLine("Resultado de la factorial {0}", result);
            }

            asteriscos();

        }

    }
}