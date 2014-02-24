
namespace FightersCon
{
    public class Warrior : Character
    {
        public const int WarriorLife = 200;
        public const int WarriorAttackPower = 20;
        public const int WarriorDefencePower = 200;
        public static char[,] warriorBody = new char[,] {{' ', '@', '@', '@', '@', '@', ' '},
                                                      {'(', '|', '.',' ', '.', '|', ')'},
                                                      {' ', '\\', ' ','V', ' ', '/', ' '},
                                                      {' ', ' ', '\\','~', '/', ' ', ' '}};
        public Warrior(MatrixCoords topLeft, MatrixCoords speed,int attackPower, int defencePower)
            : base(topLeft, warriorBody, speed, WarriorAttackPower, WarriorDefencePower)
        {
            this.Life = WarriorLife;

        }
    }
}
