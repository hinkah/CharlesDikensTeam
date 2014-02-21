using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public class Turtle : Animal
    {
        private const int TurtleAttackPower = 0;
        private const int TurtleDefencePower = 100;
        private const int TurtleLife = 200;

        public Turtle(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed, TurtleAttackPower, TurtleDefencePower)
        {
            this.Bonus = DefensePower;
            this.Life = TurtleLife;
        }
    }
}
