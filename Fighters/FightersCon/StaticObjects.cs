using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public abstract class StaticObject : WorldObject
    {
        protected StaticObject(MatrixCoords topLeft, char[,] body, int size)
            : base(topLeft, body)
        {
            this.Size = size;
        }

        public int Size { get; set; }
    }
}
