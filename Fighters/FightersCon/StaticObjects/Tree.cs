using System;

namespace FightersCon.StaticObjects
{
    public class Tree : StaticObject
    {
        public static char[,] treeBody = new char[,] {{' ', '(', '~', '~', ')', ' '},
                                                  {'(', '~', '~', '~', '~', ')'},
                                                  {' ', '(', '~', '~', ')', ' '},
                                                  {' ', ' ', '|', '|', ' ', ' '},
                                                  {' ', '_', '|', '|', '_',' '}};
        public Tree(MatrixCoords topLeft)
            : base(topLeft, treeBody)
        {
            IsDestroyable = false;
            this.Life = int.MaxValue;
        }
        public override void Update()
        {
        }
    }
}
