
namespace FightersCon
{
    public class Wolf : Animal
    {
        private const int WolfLife = Init.AnimalLife;
        private const int WolfAttackPower = Init.AnimalAttack;
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
