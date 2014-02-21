using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public class SuperHero : Character
    {
        private const int SuperHeroLife = 1000;
        private const int SuperHeroAttackPower = 300;
        public const int SuperHeroDefencePower = 300;

        public SuperHero(MatrixCoords topLeft, char[,] body, MatrixCoords speed,int attackPower, int defencePower)
            : base(topLeft, body, speed, SuperHeroAttackPower, SuperHeroDefencePower)
        {
            this.Life = SuperHeroLife;
        }
    }
}
