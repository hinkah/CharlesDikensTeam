using System;

namespace FightersCon.StaticObjects
{
    public class Tree : StaticObject
    {
        public Tree(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
            IsDestroyable = false;
            this.Life = int.MaxValue;
        }
        public override void Update()
        {
        }
    }
}
