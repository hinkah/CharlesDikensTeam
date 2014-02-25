
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
            : base(topLeft, rabbitBody, speed, AnimalAttack, 0)
        {
            this.Life = AnimalLife;
            this.Bonus = AnimalBonus;
        }
    }
}
