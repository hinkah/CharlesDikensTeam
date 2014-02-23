
namespace FightersCon
{
    public class Turtle : Animal
    {
        private const int TurtleLife = 100;             //Init.AnimalLife;
        private const int TurtleAttackPower = 0;
        private const int TurtleDefencePower = 100;      //Init.AnimalDefence;

        public Turtle(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed, TurtleAttackPower, TurtleDefencePower)
        {
            this.Life = TurtleLife;
            this.Bonus = TurtleDefencePower;
        }
    }
}
