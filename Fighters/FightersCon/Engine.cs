using System;
using System.Collections.Generic;
using System.Linq;
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

        private void AddStaticObject(StaticObject obj) // addition of a static object to the above-mentioned objects.
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public void AddMovingObject(MovableObject obj) // addition of a moving object to the above-mentioned objects.
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(WorldObject obj) // we check whether this is a static, a moving object or our ship and we add it to the respective list of objects (containers).
        {
            //if (obj is Ship)
            //{
            //    AddShip(obj);
            //}
        //    else if (obj is MovableObject)
        //    {
        //        this.AddMovingObject(obj as MovableObject);
        //    }
        //    else
        //    {
        //        this.AddStaticObject(obj);

        //    }
        //}

        //private void AddShip(GameObject obj) // addig the ship to the list of objects.
        //{
        //    this._playerShip = obj as Ship;
        //    this.AddStaticObject(obj);
        //}

        //public virtual void MovePlayerShipLeft() // moving the ship to the left
        //{
        //    this._playerShip.MoveLeft();
        //}

        //public virtual void MovePlayerShipRight() // moving the ship to the right
        //{
        //    this._playerShip.MoveRight();
        //}

        //public virtual void MovePlayerShipDown() // moving the ship downwards
        //{
        //    this._playerShip.MoveDown();
        //}

        //public virtual void MovePlayerShipUp() // moving the ship upwards
        //{
        //    this._playerShip.MoveUp();
        //}

        //public virtual void PlayerShipAction(Engine gameEngine) // shooting in stead of movement (movement of the object).
        //{
        //    this._playerShip.Shoot(gameEngine);
        }

        public virtual void Run(int sleepTime) // the engine of the game - this is where the starts.
        {
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
                        this.userInterface.ProcessInput(hero); // checkes if a key is pressed and if so, it executes its function.
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


    }
   
}
