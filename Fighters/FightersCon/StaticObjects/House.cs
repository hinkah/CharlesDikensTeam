using System;

namespace FightersCon.StaticObjects
{
    public class House : StaticObject
    {
        public House(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
            IsDestroyable = false;
            this.Life = int.MaxValue;
        }
        public override void Update()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
