using System;

namespace FightersCon
{
    public class House : StaticObject
    {
        public static char[,] houseBody = new char[,] {{' ', ' ', ' ', '@', ' ', '@', ' ', '@', ' ', ' ', ' ', ' ', ' '},
                                                       {' ', ' ', '[', ']', '_', '_', '_', ' ', ' ', ' ', ' ', ' ', ' '},
                                                       {' ', '/', ' ', ' ', ' ', ' ', '/', '\\', '_', '_', '_', '_', ' '},
                                                       {'/', '_', '/', '\\', '_', '/', '/', '_', '_', '_', '_', '/', '\\'},
                                                       {'|', ' ', '|', '|', ' ', '|', '|', '|', ' ', ' ', '|', '|', '|'},
                                                       {'|', ' ', '|', '|', ' ', '|', '|', '|', '_', '_', '|', '|', '|'}};
        public House(MatrixCoords topLeft)
            : base(topLeft, houseBody)
        {
            IsDestroyable = false;
            this.Life = int.MaxValue;
        }
        public override void Update()
        {
        }
    }
}
