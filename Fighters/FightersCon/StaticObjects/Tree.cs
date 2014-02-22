namespace FightersCon.StaticObjects
{
    public class Tree : StaticObject
    {
        private const int FenceLife = 20;

        public Tree(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
            IsDestroyable = false;
            this.Life = FenceLife;
        }
    }
}
