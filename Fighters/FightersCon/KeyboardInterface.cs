using System;
using System.Collections.Generic;

namespace FightersCon
{
    public class KeyboardInterface : IUserInterface 
    {
        public void ProcessInput(WorldObject hero, List<WorldObject> otherObjects)
        {
            if (!Console.KeyAvailable) return;
            var keyInfo = Console.ReadKey();
            bool isCollision = true;
            foreach (var item in otherObjects)
            {
                if ((CollisionDispatcher.IsCollision(hero, item, false) == true && item is SuperHero == false))
                {
                    isCollision = false;
                }
            }
            if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
            {
                if (hero.TopLeft.Col > 0 && isCollision)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(0, -2);
                }
                
                
            }
            else if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
            {
                if (hero.TopLeft.Col < 94 && isCollision)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(0, 2);
                }
                
            }
            else if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
            {
                if (hero.TopLeft.Row > 0 && isCollision)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(-1, 0);
                }
                
            }
            else if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
            {
                if (hero.TopLeft.Row < 26 && isCollision)
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
