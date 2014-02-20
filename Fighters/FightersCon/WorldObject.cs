using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public abstract class WorldObject : IWorldObject, IRenderable
    {
        public const int InitialLife = 100;

        protected MatrixCoords topLeft;                     
        protected char[,] body;

        protected WorldObject(MatrixCoords topLeft, char[,] body) 
        {
            this.TopLeft = topLeft;
            this.body = this.CopyBodyMatrix(body);
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

            protected set
            {
                this.topLeft = new MatrixCoords(value.Row, value.Col); // through the coordinates we move the object to the desired place.
            }
        }

        // this method returns the same matrix as the previous method but as a public one,
        //so other objects could also be able to use it. 
        public virtual char[,] GetImage()                   //IRenderable interface
        {
            return this.CopyBodyMatrix(this.body);  
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
