using System;
using System.Collections.Generic;
using FightersCon.StaticObjects;

namespace FightersCon
{
    public class StartGame
    {
        public static void FillTheMap(int i, Engine engine)
        {
            if (i == 1)
            {
                engine.AddObject(new SuperHero(new MatrixCoords(34, 0), new MatrixCoords(0, 0), 500, 300));
                
                engine.AddObject(new House(new MatrixCoords(0, 86)));
                engine.AddObject(new Tree(new MatrixCoords(28, 42)));
                engine.AddObject(new Tree(new MatrixCoords(5, 20)));
                engine.AddObject(new Tree(new MatrixCoords(9, 50)));
                
                engine.AddObject(new Warrior(new MatrixCoords(25, 100), new MatrixCoords(1, -1)));
                engine.AddObject(new Wolf(new MatrixCoords(32, 60), new MatrixCoords(-1, 0)));
                engine.AddObject(new Rabbit(new MatrixCoords(0, 26), new MatrixCoords(1, 1)));
                engine.AddObject(new Monkey(new MatrixCoords(15, 0), new MatrixCoords(-1, -1)));
            }
            else if (i == 2)
            {
                engine.staticObjects.Clear();
                SuperHero ourHero = (SuperHero)engine.allObjects.Find(h => h is SuperHero);
                ourHero.TopLeft = new MatrixCoords(34, 0);

                engine.AddObject(new House(new MatrixCoords(0, 86)));
                engine.AddObject(new Tree(new MatrixCoords(0, 72)));
                engine.AddObject(new Tree(new MatrixCoords(7, 72)));
                engine.AddObject(new Tree(new MatrixCoords(7, 82)));
                engine.AddObject(new Tree(new MatrixCoords(25, 42)));
                engine.AddObject(new Tree(new MatrixCoords(5, 10)));
                engine.AddObject(new Tree(new MatrixCoords(9, 50)));

                engine.AddObject(new Warrior(new MatrixCoords(25, 100), new MatrixCoords(0, -1)));
                engine.AddObject(new Wolf(new MatrixCoords(32, 60), new MatrixCoords(-1, 0)));
                engine.AddObject(new Rabbit(new MatrixCoords(0, 26), new MatrixCoords(1, 0)));
                engine.AddObject(new Monkey(new MatrixCoords(15, 0), new MatrixCoords(0, 1)));
            }
        }
        static public List<WorldObject> RuntimeCreatedObjects()
        {
            return new List<WorldObject>();
        }
        // creation of objects throughout a game.
        //TODO
    }
}
