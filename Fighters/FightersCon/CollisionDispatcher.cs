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
                    //Environment.Exit(0);
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


        private static void HandleMovingWithStaticCollisions(List<MovableObject> movingObjects, List<StaticObject> staticObjects) // 
        {
            foreach (var movingObject in movingObjects) // there must be both a horizontal and vertical coincidence for a collision to happen.
            {
                int verticalIndex = VerticalCollisionIndex(movingObject, staticObjects);
                int horizontalIndex = HorizontalCollisionIndex(movingObject, staticObjects);

                MatrixCoords movingCollisionForceDirection = new MatrixCoords(0, 0);

                if (verticalIndex != -1)
                {
                    movingCollisionForceDirection.Row = -movingObject.Speed.Row;
                    staticObjects[verticalIndex].RespondToCollision(
                        new CollisionData(new MatrixCoords(movingObject.Speed.Row, 0),
                            movingObject.GetCollisionGroupString()));
                }

                if (horizontalIndex != -1)
                {
                    movingCollisionForceDirection.Col = -movingObject.Speed.Col;
                    staticObjects[horizontalIndex].RespondToCollision(
                        new CollisionData(new MatrixCoords(0, movingObject.Speed.Col),
                            movingObject.GetCollisionGroupString()));
                }

                int diagonalIndex = -1;
                if (horizontalIndex == -1 && verticalIndex == -1)
                {
                    diagonalIndex = DiagonalCollisionIndex(movingObject, staticObjects);
                    if (diagonalIndex != -1)
                    {
                        movingCollisionForceDirection.Row = -movingObject.Speed.Row;
                        movingCollisionForceDirection.Col = -movingObject.Speed.Col;

                        staticObjects[diagonalIndex].RespondToCollision(
                            new CollisionData(new MatrixCoords(movingObject.Speed.Row, 0),
                                movingObject.GetCollisionGroupString()));
                    }
                }

                List<string> hitByMovingCollisionGroups = new List<string>();

                if (verticalIndex != -1)
                {
                    hitByMovingCollisionGroups.Add(staticObjects[verticalIndex].GetCollisionGroupString());
                }

                if (horizontalIndex != -1)
                {
                    hitByMovingCollisionGroups.Add(staticObjects[horizontalIndex].GetCollisionGroupString());
                }

                if (diagonalIndex != -1)
                {
                    hitByMovingCollisionGroups.Add(staticObjects[diagonalIndex].GetCollisionGroupString());
                }

                if (verticalIndex != -1 || horizontalIndex != -1 || diagonalIndex != -1)
                {
                    movingObject.RespondToCollision(
                        new CollisionData(movingCollisionForceDirection,
                            hitByMovingCollisionGroups));
                }
            }
        }

        public static int VerticalCollisionIndex(MovableObject moving, List<StaticObject> objects) // returns the profile of all vertical collisions. A profile includes a list of coordinates of points in the matrix.
        {
            List<MatrixCoords> profile = moving.GetCollisionProfile();

            List<MatrixCoords> verticalProfile = new List<MatrixCoords>();

            foreach (var coord in profile)
            {
                verticalProfile.Add(new MatrixCoords(coord.Row + moving.Speed.Row, coord.Col));
            }

            int collisionIndex = GetCollisionIndex(moving, objects, verticalProfile);

            return collisionIndex;
        }

        public static int HorizontalCollisionIndex(MovableObject moving, List<StaticObject> objects) // returns the profile of all horizontal collisions. A profile includes a list of coordinates of points in the matrix.
        {
            List<MatrixCoords> profile = moving.GetCollisionProfile();

            List<MatrixCoords> horizontalProfile = new List<MatrixCoords>();

            foreach (var coord in profile)
            {
                horizontalProfile.Add(new MatrixCoords(coord.Row, coord.Col + moving.Speed.Col));
            }

            int collisionIndex = GetCollisionIndex(moving, objects, horizontalProfile);

            return collisionIndex;
        }

        public static int DiagonalCollisionIndex(MovableObject moving, List<StaticObject> objects) // returns the profile of all diagonal collisions. Not in use.
        {
            List<MatrixCoords> profile = moving.GetCollisionProfile();

            List<MatrixCoords> horizontalProfile = new List<MatrixCoords>();

            foreach (var coord in profile)
            {
                horizontalProfile.Add(new MatrixCoords(coord.Row + moving.Speed.Row, coord.Col + moving.Speed.Col));
            }

            int collisionIndex = GetCollisionIndex(moving, objects, horizontalProfile);

            return collisionIndex;
        }

        private static int GetCollisionIndex(MovableObject moving, ICollection<StaticObject> objects, List<MatrixCoords> movingProfile) // returns the index of the current collision.
        {
            int collisionIndex = 0;

            foreach (var obj in objects)
            {
                if (moving.CanCollideWith(obj.GetCollisionGroupString()) || obj.CanCollideWith(moving.GetCollisionGroupString()))
                {
                    List<MatrixCoords> objProfile = obj.GetCollisionProfile();

                    if (ProfilesIntersect(movingProfile, objProfile))
                    {
                        return collisionIndex;
                    }
                }

                collisionIndex++;
            }

            return -1;
        }

        private static bool ProfilesIntersect(List<MatrixCoords> firstProfile, List<MatrixCoords> secondProfile) // returns a bollean answer on whether a profile intersects with another profile.
        {
            foreach (var firstCoord in firstProfile)
            {
                foreach (var secondCoord in secondProfile)
                {
                    if (firstCoord.Equals(secondCoord))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
