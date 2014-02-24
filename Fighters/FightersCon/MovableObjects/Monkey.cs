
namespace FightersCon
{
    public class Monkey : Animal
    {
        public static char[,] MonkeyBody = new char[,] {{' ', ' ', '/', '~', '\\', ' '},
                                                   {' ', 'C', ' ','o', 'o', ' '},
                                                   {' ', '_', '(',' ', '^', ')'},
                                                   {'/', ' ', ' ',' ', '~', '\\'}};

        public Monkey(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, MonkeyBody, speed, Init.AnimalAttack, Init.AnimalDefence)
        {
            this.Life = Init.AnimalLife; 
            this.Bonus = Init.AnimalDefence;
        }
    }
}
