
namespace FightersCon
{
    public class Monkey : Animal
    {
        private static char[,] MonkeyBody = new char[,] {{' ', ' ', '/', '~', '\\', ' '},
                                                   {' ', 'C', ' ','o', 'o', ' '},
                                                   {' ', '_', '(',' ', '^', ')'},
                                                   {'/', ' ', ' ',' ', '~', '\\'}};

        public Monkey(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, MonkeyBody, speed, AnimalAttack, AnimalDefence)
        {
            this.Life = AnimalLife; 
            this.Bonus = AnimalDefence;
        }
    }
}
