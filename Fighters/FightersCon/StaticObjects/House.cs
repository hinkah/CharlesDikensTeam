namespace FightersCon.StaticObjects
{
    public class House : StaticObject
    {
        public House(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
            IsDestroyable = false;
        }
    }
}
