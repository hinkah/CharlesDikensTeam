using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public class Wolf : Animal
    {
        private const int WolfAttackPower = Init.AnimalAttack;
        private const int WolfDefencePower = 0;
        private const int WolfLife = Init.AnimalLife;
        public const int WolfBonus = Init.AnimalBonus;//must initialize as Attack!!!!!!!!

        public Wolf(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed, WolfAttackPower, WolfDefencePower)
        {
            this.Life = WolfLife;
            this.AttackPower = WolfAttackPower;
            this.Bonus = WolfBonus;
            
        }
    }
}
