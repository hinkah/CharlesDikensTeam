
namespace FightersCon
{
    public class Rabbit : Animal
    {
        //private const int RabbitLife = 100;         //Init.AnimalLife;
        private const int RabbitAttackPower = Init.AnimalAttack;
        private const int RabbitDefencePower = 0;
        private const int RabbitLife = Init.AnimalLife;
        private const int RabbitBonus = Init.AnimalBonus;//must initialize as Life!!!!!!!!
        private static char[,] rabbitBody = new char[,] {{'(', '\\', '_', '_','_',  '/', ')'},
                                                         {'(', '=', '\'', '.', '\'', '=', ')'},
                                                         {'(', '"', ')', '_', '(', '"', ')'}};

        public Rabbit(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, rabbitBody, speed,
            RabbitAttackPower, RabbitDefencePower)
        {
            this.Life = RabbitLife;
            this.Bonus = RabbitBonus;
        }
    }
}
