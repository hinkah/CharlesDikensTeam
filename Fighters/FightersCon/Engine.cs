using System;
using System.Collections.Generic;
using System.Linq;
using FightersCon.StaticObjects;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public class Engine
    {
        readonly IRenderer renderer; // the interface which prints on the console.
        readonly IUserInterface userInterface; // the user control on the console via keyboard.
        readonly List<WorldObject> allObjects; // the list of all objects currently on the console.
        readonly List<MovableObject> movingObjects; // the list of all MOVING objects currently on the console.
        readonly List<StaticObject> staticObjects; // the list of all STATIC objects currently on the console.
        //Ship _playerShip; // creation of the ship object.
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
            int intttt = 1;
            while (true)
            {
                FillTheMap(intttt);

                while (true)
                {
                    List<WorldObject> newObjects = StartGame.RuntimeCreatedObjects();

                    foreach (var gameObject in newObjects)
                    {
                        this.AddObject(gameObject); // we add newly created objects to the list of objects.
                    }

                    this.renderer.RenderAll(); // prints all objects on the console.

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
                    if (this.movingObjects.Count == 1)
                    {
                        intttt = 2;
                        break;
                    }
                }
            }
            
        }
        private void CheckMovingBoundarys()
        {
            foreach (var obj in this.movingObjects)
            {
                if (obj is SuperHero == false)
                {
                    if (obj.TopLeft.Col == 0)
                    {
                        obj.Speed = new MatrixCoords(0, 1);
                    }
                    if (obj.TopLeft.Col == 94)
                    {
                        obj.Speed = new MatrixCoords(0, -1);
                    }
                    if (obj.TopLeft.Row == 0)
                    {
                        obj.Speed = new MatrixCoords(1, 0);
                    }
                    if (obj.TopLeft.Row == 28)
                    {
                        obj.Speed = new MatrixCoords(-1, 0);
                    }
                }          
            }
        }
        public void FillTheMap(int i)
        {
            if (i == 1)
            {
                char[,] shit2 = new char[,] {{'(', '\'', '_', '_', '\'', ')'},
                                       {' ', 'H', 'E','R', 'O', ' '}};
                               
                this.AddObject(new Tree(new MatrixCoords(25, 40)));
                this.AddObject(new Rabbit(new MatrixCoords(0, 20), new MatrixCoords(1, 0)));
                this.AddObject(new SuperHero(new MatrixCoords(25, 50), new MatrixCoords(0, 0), 0, 0));
                this.AddObject(new Turtle(new MatrixCoords(25, 10), shit2, new MatrixCoords(0, -1)));
            }
            else if (i == 2)
            {
                char[,] shit2 = new char[,] {{'(', '\'', '_', '_', '\'', ')'},
                                       {' ', 'H', 'E','R', 'O', ' '}};
                this.AddObject(new Rabbit(new MatrixCoords(0, 20), new MatrixCoords(1, 0)));
                this.AddObject(new Turtle(new MatrixCoords(25, 10), shit2, new MatrixCoords(0, -1)));
            }
        }
    }
   
}
