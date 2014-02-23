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
                hero.TopLeft = hero.TopLeft + new MatrixCoords(0, -2);
            }
            else if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
            {
                hero.TopLeft = hero.TopLeft + new MatrixCoords(0, 2);
            }
            else if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
            {
                hero.TopLeft = hero.TopLeft + new MatrixCoords(-1, 0);
            }
            else if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
            {
                hero.TopLeft = hero.TopLeft + new MatrixCoords(1, 0);
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
