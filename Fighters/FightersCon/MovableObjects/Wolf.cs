
namespace FightersCon
{
    public class Wolf : Animal
    {
        private const int WolfLife = 100;       //Init.AnimalLife;
        private const int WolfAttackPower = 50; //Init.AnimalAttack;
        private const int WolfDefencePower = 0;

        public Wolf(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed, WolfAttackPower, WolfDefencePower)
        {
            this.Life = WolfLife;
            this.Bonus = WolfAttackPower;
        }
    }
}
