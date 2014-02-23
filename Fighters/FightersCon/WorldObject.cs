using System;
using System.Collections.Generic;

namespace FightersCon
{
    public abstract class WorldObject : IWorldObject, IRenderable, IObjectProducer
    {
        public const string CollisionGroupString = "object"; // all objects inherit this class called WorldObject.
        public const int InitialLife = 100;

        private MatrixCoords topLeft;
        protected char[,] body;

        protected WorldObject(MatrixCoords topLeft, char[,] body) 
        {
            this.TopLeft = topLeft;
            this.body = body;
            this.IsDestroyed = false;
            this.Life = InitialLife;
        }

        public int Life { get; protected set; }             //IWorldObject interface
        public bool IsDestroyed { get; protected set; }     //IWorldObject interface
        public ConsoleColor Color { get; set; }

        public MatrixCoords TopLeft                         //IRenderable interface
        {
            get
            {
                return new MatrixCoords(topLeft.Row, topLeft.Col); // returns the coordinates of the top left point of the object when required.
            }

            set// protected set
            {
                this.topLeft = new MatrixCoords(value.Row, value.Col); // through the coordinates we move the object to the desired place.
            }
        }

        public abstract void Update(); // update which is used by all objects which inherit this class.

        public virtual MatrixCoords GetTopLeft() 
        {
            return this.TopLeft;
        }

        // this method returns the same matrix as the previous method but as a public one,
        //so other objects could also be able to use it. 
        public virtual char[,] GetImage()                   //IRenderable interface
        {
            return this.CopyBodyMatrix(this.body);  
        }

        public virtual void RespondToCollision(CollisionData collisionData) // this method returns an answer to what happens after collision.
        {
        }

        public virtual bool CanCollideWith(string otherCollisionGroupString) // this method returns an answer to whether collisions with other objects are possible.
        {
            return WorldObject.CollisionGroupString == otherCollisionGroupString;
        }

        public virtual string GetCollisionGroupString() // returns the name the objects.
        {
            return WorldObject.CollisionGroupString;
        }

        public virtual List<MatrixCoords> GetCollisionProfile() // returns the profile containing the points at which a collision is posiible.
        {
            List<MatrixCoords> profile = new List<MatrixCoords>(); // a list containing all the collision positions

            int bodyRows = this.body.GetLength(0);
            int bodyCols = this.body.GetLength(1);

            for (int row = 0; row < bodyRows; row++)
            {
                for (int col = 0; col < bodyCols; col++)
                {
                    if (body[row, col] == ' ') continue;
                    profile.Add(new MatrixCoords(row + this.topLeft.Row, col + this.topLeft.Col));
                }
            }

            return profile;
        }
        public virtual IEnumerable<WorldObject> ProduceObjects() // this method returns a list of the game objects.
        {
            return new List<WorldObject>();
        }
        // this method makes a copy of the matrix of the object body and returns a new matrix with a different name
        private char[,] CopyBodyMatrix(char[,] matrixToCopy) 
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);

            char[,] result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = matrixToCopy[row, col];
                }
            }

            return result;
        }

    }
}
