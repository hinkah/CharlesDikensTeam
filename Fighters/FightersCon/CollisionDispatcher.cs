using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public static class CollisionDispatcher
    {
        public static void HandleCollisions(List<MovableObject> movingObjects, List<StaticObject> staticObjects) // this method calls a second method for a collision of moving andstatic onjects
        {
            //HandleMovingWithStaticCollisions(movingObjects, staticObjects);

            var movingObjectWithoutHero = new List<MovableObject>();

            int superHeroIndex = 0;
            int index = 0;
            foreach (var hero in movingObjects)
            {
                if (hero is SuperHero)
                {
                    superHeroIndex = index;
                }
                else
                {
                    movingObjectWithoutHero.Add(hero);
                }
                index++;
            }

            SuperHero superHero = (SuperHero)movingObjects[superHeroIndex];

            foreach (var movingObject in movingObjectWithoutHero)
            {
                if (IsCollision(superHero, movingObject, true))
                {
                    //movingObject.IsDestroyed = true;
                }
            }

            foreach (var staticObject in staticObjects)
            {
                if (IsCollision(superHero, staticObject, false))
                {

                }
            }

            foreach (var moving in movingObjectWithoutHero)
            {
                foreach (var staticObject in staticObjects)
                {
                    if (IsCollision(moving, staticObject, false))
                    {
                        MatrixCoords newSpeed = new MatrixCoords(moving.Speed.Row, moving.Speed.Col);
                        newSpeed.Row *= -1;
                        newSpeed.Col *= -1;
                        moving.Speed = newSpeed;
                    }
                }
            }

            for (int i = 0; i < movingObjectWithoutHero.Count; i++)
            {
                for (int j = i + 1; j < movingObjectWithoutHero.Count; j++)
                {
                    MovableObject obj1 = movingObjectWithoutHero[i];
                    MovableObject obj2 = movingObjectWithoutHero[j];

                    if (IsCollision(obj1, obj2, false))
                    {
                        MatrixCoords newSpeed = new MatrixCoords(obj1.Speed.Row, obj1.Speed.Col);
                        newSpeed.Row *= -1;
                        newSpeed.Col *= -1;
                        obj1.Speed = newSpeed;
                        newSpeed = new MatrixCoords(obj2.Speed.Row, obj2.Speed.Col);
                        newSpeed.Row *= -1;
                        newSpeed.Col *= -1;
                        obj2.Speed = newSpeed;
                    }
                }
            }
        }

        private static bool IsCollision(WorldObject first, WorldObject second, bool overlap)
        {
            int overlapSize = 0;
            if (overlap)
            {
                overlapSize = 1;
            }

            int firstStartRow = first.TopLeft.Row - overlapSize;
            int firstStartCol = first.TopLeft.Col - overlapSize;
            int firstEndRow = first.TopLeft.Row + first.GetImage().GetLength(0) + overlapSize;
            int firstEndCol = first.TopLeft.Col + first.GetImage().GetLength(1) + overlapSize;

            int secondStartRow = second.TopLeft.Row;
            int secondStartCol = second.TopLeft.Col;
            int secondEndRow = second.TopLeft.Row + second.GetImage().GetLength(0);
            int secondEndCol = second.TopLeft.Col + second.GetImage().GetLength(1);

            bool topLeft = secondStartRow > firstStartRow && secondStartRow < firstEndRow &&
                           secondStartCol > firstStartCol && secondStartCol < firstEndCol;
            bool topRight = secondStartRow > firstStartRow && secondStartRow < firstEndRow &&
                            secondEndCol > firstStartCol && secondEndCol < firstEndCol;
            bool bottomLeft = secondEndRow > firstStartRow && secondEndRow < firstEndRow &&
                              secondStartCol > firstStartCol && secondStartCol < firstEndCol;
            bool bottomRight = secondEndRow > firstStartRow && secondEndRow < firstEndRow &&
                               secondEndCol > firstStartCol && secondEndCol < firstEndCol;
            return (topLeft || topRight || bottomLeft || bottomRight);
        }
    }
}
