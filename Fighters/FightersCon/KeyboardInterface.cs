using System;
using System.Collections.Generic;

namespace FightersCon
{
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput(WorldObject hero, List<WorldObject> otherObjects)
        {
            if (!Console.KeyAvailable) return;

            bool collisionLeft = false;
            bool collisionRight = false;
            bool collisionTop = false;
            bool collisionBottom = false;
            foreach (var item in otherObjects)
            {
                if ((item is SuperHero) == false)
                {
                    if (CollisionDispatcher.IsCollided(hero, item, DirectionType.Left)) 
                    {
                        collisionLeft = true;
                    }
                    if (CollisionDispatcher.IsCollided(hero, item, DirectionType.Rigth))
                    {
                        collisionRight = true;
                    }
                    if (CollisionDispatcher.IsCollided(hero, item, DirectionType.Top))
                    {
                        collisionTop = true;
                    }
                    if (CollisionDispatcher.IsCollided(hero, item, DirectionType.Bottom))
                    {
                        collisionBottom = true;
                    }
                }
            }

            var keyInfo = Console.ReadKey();
            if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
            {
                if (hero.TopLeft.Col > 0 && !collisionLeft)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(0, -2);
                }


            }
            else if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
            {
                if (hero.TopLeft.Col < 94 && !collisionRight)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(0, 2);
                }

            }
            else if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
            {
                if (hero.TopLeft.Row > 0 && !collisionTop)
                {
                    hero.TopLeft = hero.TopLeft + new MatrixCoords(-1, 0);
                }

            }
            else if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
            {
                if (hero.TopLeft.Row < 26 && !collisionBottom)
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
