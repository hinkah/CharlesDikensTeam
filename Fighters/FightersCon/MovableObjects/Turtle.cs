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
        private const int TurtleDefencePower = Init.AnimalDefence;
        private const int TurtleLife = Init.AnimalLife;
        public const int TurtleBonus = Init.AnimalBonus;//must initialize as Defence!!!!!!!!

        public Turtle(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed, TurtleAttackPower, TurtleDefencePower)
        {
            this.Life = TurtleLife;
            this.DefensePower = TurtleDefencePower;
            this.Bonus = TurtleBonus;
            
        }
    }
}
