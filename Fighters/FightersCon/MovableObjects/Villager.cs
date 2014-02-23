
namespace FightersCon
{
    public class Villager : Character
    {
        public const int VillagerLife = 200;
        public const int VillagerAttackPower = 0;
        public const int VillagerDefencePower = 0;

        public Villager(MatrixCoords topLeft, char[,] body, MatrixCoords speed,
                int attackPower, int defencePower, int gold)
            : base(topLeft, body, speed, VillagerAttackPower, VillagerDefencePower)
        {
            this.Life = VillagerLife;
            this.Gold = gold;

        }

        public int Gold { get; set; }
    }
}
