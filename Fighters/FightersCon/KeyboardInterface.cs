using System;

namespace FightersCon
{
    public class KeyboardInterface : IUserInterface 
    {
        public void ProcessInput(WorldObject hero)
        {
            if (!Console.KeyAvailable) return;
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
            {
                if (hero.TopLeft.Col > 0)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(0, -2);
                }
                
            }
            else if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
            {
                if (hero.TopLeft.Col < 94)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(0, 2);
                }
                
            }
            else if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
            {
                if (hero.TopLeft.Row > 0)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(-1, 0);
                }
                
            }
            else if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
            {
                if (hero.TopLeft.Row < 28)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(1, 0);
                }
                
            }
            else if (keyInfo.Key.Equals(ConsoleKey.Spacebar)) // shooting
            {
                
            }
            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }
        }

        

    }
}
