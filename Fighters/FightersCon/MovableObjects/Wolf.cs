
namespace FightersCon
{
    public class Wolf : Animal
    {
        public static char[,] WolfBody = new char[,] {{' ', '_', '_', '_', '_', '|', '\\', ' ', ' ', ' '},
                                                       {'`', '_', '/', ' ', ' ', ' ', ' ', '\\', ' ', ' '},
                                                       {' ', '(', '\\', '_', '/', ')', ' ', ' ', '\\', ' '},
                                                       {' ', '/', '_', ' ', ' ', '_', ' ', ' ', ' ', '|'},
                                                       {' ', '\\', '/', '_', '/', '|', '|', ')', ' ', '/'},
                                                       {' ', ' ', ' ', ' ', '\'', '_', '_', '_', '\'', ' '}};
        public Wolf(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, WolfBody, speed, Init.AnimalAttack, 0)
        {
            this.Life = Init.AnimalLife;
            this.Bonus = Init.AnimalAttack;
        }
    }
}
