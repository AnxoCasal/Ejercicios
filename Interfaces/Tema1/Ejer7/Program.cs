class ejer7
{
    static void Main()
    {
        bool game = true;
        bool win = false;
        int x = 0;
        int y = 0;
        int playerX = 20;
        int playerY = 31;
        bool shoot = false;
        int shootX = 0;
        int shootY = 0;
        ConsoleKeyInfo cki;
        try
        {
            do
            {
                Console.Clear(); ;
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.LeftArrow)
                    {
                        if (playerX > 0)
                        {
                            playerX--;
                        }
                    }
                    if (cki.Key == ConsoleKey.RightArrow)
                    {
                        if (playerX < 40)
                        {
                            playerX++;
                        }
                    }
                    if (cki.Key == ConsoleKey.Spacebar && shoot == false)
                    {
                        shoot = true;
                        shootX = playerX;
                        shootY = playerY - 1;
                    }
                }
                Console.SetCursorPosition(0, 20);
                Console.Write("-----------------------------------");
                Console.SetCursorPosition(x, y);
                Console.Write("*");
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("A");
                if (shoot)
                {
                    Console.SetCursorPosition(shootX, shootY);
                    Console.Write("¡");
                    shootY--;
                    if (shootX == x && shootY == y)
                    {
                        y = 20;
                        game = false;
                        win = true;
                    }
                    else if (shootY == 0)
                    {
                        shoot = false;
                    }
                }
                Thread.Sleep(300);
                x++;
                if (x > 40) { y++; x = 0; }
            } while (y < 20);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Console.WriteLine("ERROR");
        }
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        if (win)
        {
            Console.WriteLine("VICTORY");
        }
        else
        {
            Console.WriteLine("GAME OVER");
        }
    }

}