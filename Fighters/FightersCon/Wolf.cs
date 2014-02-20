using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public class Wolf : Animal
    {
        private const int WolfAttackPower = 200;
        private const int WolfDefencePower = 100;

        public Wolf(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body, WolfAttackPower, WolfDefencePower)
        {
        }
    }
}
