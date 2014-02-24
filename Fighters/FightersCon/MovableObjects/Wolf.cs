
namespace FightersCon
{
    public class Wolf : Animal
    {
        private const int WolfLife = 100;       //Init.AnimalLife;
        private const int WolfAttackPower = 50; //Init.AnimalAttack;
        private const int WolfDefencePower = 0;
        public static char[,] wolfBody = new char[,] {{' ', '_', '_', '_', '_', '|', '\\', ' ', ' ', ' '},
                                                       {'`', '_', '/', ' ', ' ', ' ', ' ', '\\', ' ', ' '},
                                                       {' ', '(', '\\', '_', '/', ')', ' ', ' ', '\\', ' '},
                                                       {' ', '/', '_', ' ', ' ', '_', ' ', ' ', ' ', '|'},
                                                       {' ', '\\', '/', '_', '/', '|', '|', ')', ' ', '/'},
                                                       {' ', ' ', ' ', ' ', '\'', '_', '_', '_', '\'', ' '}};
        public Wolf(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, wolfBody, speed, WolfAttackPower, WolfDefencePower)
        {
            this.Life = WolfLife;
            this.Bonus = WolfAttackPower;
        }
    }
}
