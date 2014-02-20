using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public class Rabbit : Animal
    {
        private const int RabbitAttackPower = 0;
        private const int RabbitDefencePower = 0;

        public Rabbit(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body, RabbitAttackPower, RabbitDefencePower)
        {
            this.Bonus = this.Life;
        }
    }
}
