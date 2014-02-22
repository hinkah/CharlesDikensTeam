using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public class SuperHero : Character
    {
        private const int SuperHeroLife = Init.SuperHeroLife;
        private const int SuperHeroAttackPower = Init.SuperHeroAttack;
        public const int SuperHeroDefencePower = Init.SuperHeroDefence;

        public SuperHero(MatrixCoords topLeft, char[,] body, MatrixCoords speed,int attackPower, int defencePower)
            : base(topLeft, body, speed, SuperHeroAttackPower, SuperHeroDefencePower)
        {
            this.Life = SuperHeroLife;
        }
    }
}
