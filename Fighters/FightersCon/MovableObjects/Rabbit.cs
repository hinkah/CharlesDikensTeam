
namespace FightersCon
{
    public class Rabbit : Animal
    {
        private static char[,] rabbitBody = new char[,]
        {   { '(', '\\', '_',  '_', '_', '/',  ')'  },
            { '(', '=', '\'', '.', '\'', '=',  ')'  },
            { '(', '"', ')',  '_', '(',  '"',  ')'  }
        };

        public Rabbit(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, rabbitBody, speed, Init.AnimalAttack, 0)
        {
            this.Life = Init.AnimalLife;
            this.Bonus = Init.AnimalBonus;
        }
    }
}
