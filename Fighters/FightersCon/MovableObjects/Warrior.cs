
namespace FightersCon
{
    public class Warrior : Character
    {
        private const int WarriorLife = 200;

        private static char[,] WarriorBody = new char[,] {{' ', '@', '@', '@', '@', '@', ' '},
                                                      {'(', '|', '.',' ', '.', '|', ')'},
                                                      {' ', '\\', ' ','V', ' ', '/', ' '},
                                                      {' ', ' ', '\\','~', '/', ' ', ' '}};
       
        public Warrior(MatrixCoords topLeft, MatrixCoords speed, int attackPower = 20, int defencePower = 200)
            : base(topLeft, WarriorBody, speed, attackPower, defencePower)
        {
            this.Life = WarriorLife;
        }
    }
}
