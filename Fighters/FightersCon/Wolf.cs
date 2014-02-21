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
        private const int WolfLife = 400;

        public Wolf(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed, WolfAttackPower, WolfDefencePower)
        {
            this.Life = WolfLife;
        }
    }
}
