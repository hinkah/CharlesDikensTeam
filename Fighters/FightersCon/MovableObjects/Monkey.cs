
namespace FightersCon
{
    public class Monkey : Animal
    {
        private const int TurtleLife = Init.AnimalLife;
        private const int TurtleAttackPower = Init.AnimalAttack;
        private const int TurtleDefencePower = Init.AnimalDefence;
        public static char[,] monkeyBody = new char[,] {{' ', ' ', '/', '~', '\\', ' '},
                                                   {' ', 'C', ' ','o', 'o', ' '},
                                                   {' ', '_', '(',' ', '^', ')'},
                                                   {'/', ' ', ' ',' ', '~', '\\'}};
        public Monkey(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, monkeyBody, speed, TurtleAttackPower, TurtleDefencePower)
        {
            this.Life = TurtleLife;
            this.Bonus = TurtleDefencePower;
        }
    }
}
