using System;

namespace FightersCon.StaticObjects
{
    public class Fence : StaticObject
    {
        public Fence(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
            IsDestroyable = true;
            this.Life = Init.StaticLife;
        }
        public override void Update()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
