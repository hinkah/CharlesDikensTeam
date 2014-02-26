
namespace FightersCon
{
    public class Wolf : Animal
    {
        private static char[,] WolfBody = new char[,] {{' ', '_', '_', '_', '_', '|', '\\', ' ', ' ', ' '},
                                                       {'`', '_', '/', ' ', ' ', ' ', ' ', '\\', ' ', ' '},
                                                       {' ', '(', '\\', '_', '/', ')', ' ', ' ', '\\', ' '},
                                                       {' ', '/', '_', ' ', ' ', '_', ' ', ' ', ' ', '|'},
                                                       {' ', '\\', '/', '_', '/', '|', '|', ')', ' ', '/'},
                                                       {' ', ' ', ' ', ' ', '\'', '_', '_', '_', '\'', ' '}};
        public Wolf(MatrixCoords topLeft, MatrixCoords speed, int attackPower)
            : base(topLeft, WolfBody, speed, attackPower, 0)
        {
            this.Life = AnimalLife;
            this.Bonus = AnimalAttack;
        }
    }
}
