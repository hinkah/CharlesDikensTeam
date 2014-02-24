﻿
namespace FightersCon
{
    public class Villager : Character
    {
        public const int VillagerLife = 200;

        public Villager(MatrixCoords topLeft, char[,] body, MatrixCoords speed, 
            int attackPower, int defencePower, int gold)
            : base(topLeft, body, speed, attackPower, defencePower)
        {
            this.Life = VillagerLife;
            this.Gold = gold;
        }

        public int Gold { get; set; }
    }
}
