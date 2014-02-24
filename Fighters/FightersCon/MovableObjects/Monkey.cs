
namespace FightersCon
{
    public class Monkey : Animal
    {
        private const int TurtleLife = 100;             //Init.AnimalLife;
        private const int TurtleAttackPower = 0;
        private const int TurtleDefencePower = 100;      //Init.AnimalDefence;
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
