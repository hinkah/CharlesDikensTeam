using System;
using System.Collections.Generic;
using System.Linq;
using FightersCon.StaticObjects;

namespace FightersCon
{
    public class Engine
    {
        private readonly IRenderer renderer;                // the interface which prints on the console.
        private readonly IUserInterface userInterface;      // the user control on the console via keyboard.
        private readonly List<WorldObject> allObjects;     // the list of all objects currently on the console.
        private readonly List<MovableObject> movingObjects; // the list of all MOVING objects currently ivate ontherconsole.
        private readonly List<StaticObject> staticObjects; // the list of all STATIC objects currently on the console.

        public Engine(IRenderer renderer, IUserInterface userInterface) // constructor - creates an on object of the Engine type
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<WorldObject>();
            this.movingObjects = new List<MovableObject>();
            this.staticObjects = new List<StaticObject>();
        }

        public virtual void AddObject(WorldObject obj) // we check whether this is a static, a moving object or our ship and we add it to the respective list of objects (containers).
        {
            if (obj is MovableObject)
            {
                this.movingObjects.Add((MovableObject)obj);
                this.allObjects.Add(obj);
            }
            else
            {
                this.staticObjects.Add((StaticObject)obj);
                this.allObjects.Add(obj);
            }
        }

        public virtual void Run(int sleepTime) // the engine of the game - this is where the starts.
        {
            int level = 1;
            while (true)
            {
                FillTheMap(level);

                while (true)
                {
                    List<WorldObject> newObjects = StartGame.RuntimeCreatedObjects();

                    foreach (var gameObject in newObjects)
                    {
                        this.AddObject(gameObject); // we add newly created objects to the list of objects.
                    }

                    this.renderer.RenderAll(); // prints all objects on the console.

                    PrintHeroDetails(5, 101);

                    System.Threading.Thread.Sleep(sleepTime); // delays the game so we coul play at a normal speed.
                    foreach (var hero in this.allObjects)
                    {
                        if (hero is SuperHero)
                        {
                            this.userInterface.ProcessInput(hero, allObjects); // checkes if a key is pressed and if so, it executes its function.
                            break;
                        }
                    }

                    CheckMovingBoundarys();

                    this.renderer.ClearQueue(); // we clean the string which is printed on the whole console.

                    foreach (var obj in this.allObjects)
                    {
                        obj.Update(); // we update all rellevant parameters for the specific objects.
                        this.renderer.EnqueueForRendering(obj); // the updated parameters are now added to the string containing all objects that are printed on theconsole at each iteration.
                    }

                    CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects); // we check all collisions that have occured and we process them.

                    List<WorldObject> producedObjects = new List<WorldObject>();

                    foreach (var obj in this.allObjects)
                    {
                        producedObjects.AddRange(obj.ProduceObjects()); // we add the newly created objects to the list of objects
                    }

                    this.allObjects.RemoveAll(obj => obj.IsDestroyed); // we check whether all objects have been deleted and the ones that have not been deleted are rempoved from the existing objects list. 
                    this.movingObjects.RemoveAll(obj => obj.IsDestroyed); // the same
                    this.staticObjects.RemoveAll(obj => obj.IsDestroyed); // the same

                    foreach (var obj in producedObjects)
                    {
                        this.AddObject(obj); // we send the newly created objects to the respective class.
                    }

                    if (Init.changeLevel)
                    {
                        level = 2;
                        Init.changeLevel = false;
                        break;
                    }
                }
            }

        }

        private void PrintHeroDetails(int startRow, int startCol)
        {
            for (int i = 0; i < 39; i++)
            {
                Console.SetCursorPosition(startCol-1, i);
                Console.Write('|');
            }

            SuperHero ourHero = (SuperHero)this.allObjects.Find(h => h is SuperHero);

            Console.SetCursorPosition(startCol, startRow);
            Console.Write("Attack");
            Console.SetCursorPosition(startCol, startRow + 1);
            Console.Write(ourHero.AttackPower);

            Console.SetCursorPosition(startCol, startRow + 3);
            Console.Write("Life");
            Console.SetCursorPosition(startCol, startRow + 4);
            Console.Write(ourHero.Life);

            Console.SetCursorPosition(startCol, startRow + 6);
            Console.Write("Experience");
            Console.SetCursorPosition(startCol, startRow + 7);
            Console.Write(ourHero.Experience);
        }

        private void CheckMovingBoundarys()
        {
            foreach (var obj in this.movingObjects)
            {
                if (obj is SuperHero == false)
                {
                    MatrixCoords newCoords = obj.Speed;
                    if ((obj.TopLeft.Col <= 0 && newCoords.Col < 0) ||
                        (obj.TopLeft.Col >= (Program.consoleCols - obj.GetImage().GetLength(1))) && newCoords.Col > 0)
                    {
                        newCoords.Col *= -1;
                    }
                    if ((obj.TopLeft.Row <= 0 && newCoords.Row < 0) ||
                        (obj.TopLeft.Row >= (Program.consoleRows - obj.GetImage().GetLength(0)) && newCoords.Row > 0))
                    {
                        newCoords.Row *= -1;
                    }
                    obj.Speed = newCoords;
                }
            }
        }

        public void FillTheMap(int i)
        {
            if (i == 1)
            {
                this.AddObject(new SuperHero(new MatrixCoords(34, 0), new MatrixCoords(0, 0), 500, 300));

                this.AddObject(new House(new MatrixCoords(0, 86)));
                this.AddObject(new Tree(new MatrixCoords(28, 42)));
                this.AddObject(new Tree(new MatrixCoords(5, 20)));
                this.AddObject(new Tree(new MatrixCoords(9, 50)));

                this.AddObject(new Warrior(new MatrixCoords(25, 100), new MatrixCoords(1, -1)));
                this.AddObject(new Wolf(new MatrixCoords(32, 60), new MatrixCoords(-1, 0)));
                this.AddObject(new Rabbit(new MatrixCoords(0, 26), new MatrixCoords(1, 1)));
                this.AddObject(new Monkey(new MatrixCoords(15, 0), new MatrixCoords(-1, -1)));
            }
            else if (i == 2)
            {                
                SuperHero ourHero = (SuperHero)this.allObjects.Find(h => h is SuperHero);
                ourHero.TopLeft = new MatrixCoords(34, 0);
                this.staticObjects.Clear();
                this.allObjects.Clear();
                this.movingObjects.Clear();

                this.AddObject(ourHero);
                this.AddObject(new House(new MatrixCoords(0, 86)));
                this.AddObject(new Tree(new MatrixCoords(0, 72)));
                this.AddObject(new Tree(new MatrixCoords(7, 72)));
                this.AddObject(new Tree(new MatrixCoords(7, 82)));
                this.AddObject(new Tree(new MatrixCoords(25, 42)));
                this.AddObject(new Tree(new MatrixCoords(5, 10)));
                this.AddObject(new Tree(new MatrixCoords(9, 50)));

                this.AddObject(new Warrior(new MatrixCoords(25, 100), new MatrixCoords(0, -1)));
                this.AddObject(new Wolf(new MatrixCoords(32, 60), new MatrixCoords(-1, 0)));
                this.AddObject(new Rabbit(new MatrixCoords(0, 26), new MatrixCoords(1, 0)));
                this.AddObject(new Monkey(new MatrixCoords(15, 0), new MatrixCoords(0, 1)));
            }
        }
    }

}
