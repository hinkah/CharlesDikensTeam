
namespace FightersCon
{
    public class Warrior : Character
    {
        public const int WarriorLife = 200;
        public const int WarriorAttackPower = 200;
        public const int WarriorDefencePower = 200;

        public Warrior(MatrixCoords topLeft, char[,] body, MatrixCoords speed,int attackPower, int defencePower)
            : base(topLeft, body, speed, WarriorAttackPower, WarriorDefencePower)
        {
            this.Life = WarriorLife;

        }
    }
}
