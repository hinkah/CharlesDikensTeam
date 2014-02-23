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
        private const int RabbitLife = Init.AnimalLife;
        private const int RabbitBonus = Init.AnimalBonus;//must initialize as Life!!!!!!!!
        //private char[,] shit = new char[,] {{'(', '\\', '_', '_','_',  '/', ')'},
        //                               {'(', '=', '\'', '.', '\'', '=', ')'},
        //                               {'(', '"', ')', '_', '(', '"', ')'}};

        public Rabbit(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed,
            RabbitAttackPower, RabbitDefencePower)
        {
            this.Life = RabbitLife;
            this.Bonus = RabbitBonus;
            //this.body = new char[,] {{'(', '\\', '_', '_', '/', ')'},
            //                         {'(', '=', '\'', '.', '\'', '=', ')'},
            //                         {'(', '"', ')', '_', '(', '"', ')'}};
        }
    }
}
