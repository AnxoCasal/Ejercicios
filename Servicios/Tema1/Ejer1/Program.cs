namespace ejer1
{
    class ejer1
    {
        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
            Array.ForEach(v, item =>
            {
                Console.ForegroundColor = item >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Student grade: {item,3}.");
                Console.ResetColor();
            });
            int res = Array.FindIndex(v, item => item >= 5);
            //Falta Exist
            int res2 = Array.FindLastIndex(v, item => item >= 5);
            Console.WriteLine($"The first passing student is number {res + 1} in the list.");
            Console.WriteLine($"The last passing student is number {res2 + 1} in the list.");
            Array.ForEach(v, item =>
            {
                Console.WriteLine(1.0/item);
            });
            Console.ReadKey();
        }
    }
}