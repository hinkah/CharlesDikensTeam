
namespace FightersCon
{
    public class Trader : Character
    {
        public const int TraderLife = 200;

        public Trader(MatrixCoords topLeft, char[,] body, MatrixCoords speed,
            int attackPower, int defencePower, int gold)
            : base(topLeft, body, speed, attackPower, defencePower)
        {
            this.Life = TraderLife;
            this.Gold = gold;
        }

        public int Gold { get; private set; }
    }
}
