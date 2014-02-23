
namespace FightersCon
{
    public class Rabbit : Animal
    {
        //private const int RabbitLife = 100;         //Init.AnimalLife;
        private const int RabbitAttackPower = 0;
        private const int RabbitDefencePower = 0;
        private const int RabbitLife = Init.AnimalLife;
        private const int RabbitBonus = Init.AnimalBonus;//must initialize as Life!!!!!!!!
        

        public Rabbit(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed,
            RabbitAttackPower, RabbitDefencePower)
        {
            this.Life = RabbitLife;
            this.Bonus = RabbitBonus;
        }
    }
}
