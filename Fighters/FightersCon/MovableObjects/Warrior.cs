
namespace FightersCon
{
    public class Warrior : Character
    {
        public const int WarriorLife = 200;
        public static char[,] warriorBody = new char[,] {{' ', '@', '@', '@', '@', '@', ' '},
                                                      {'(', '|', '.',' ', '.', '|', ')'},
                                                      {' ', '\\', ' ','V', ' ', '/', ' '},
                                                      {' ', ' ', '\\','~', '/', ' ', ' '}};
        public Warrior(MatrixCoords topLeft, MatrixCoords speed, int attackPower = 20, int defencePower = 200)
            : base(topLeft, warriorBody, speed, attackPower, defencePower)
        {
            this.Life = WarriorLife;
            this.AttackPower = attackPower;
            this.DefensePower = defencePower;

        }
    }
}
