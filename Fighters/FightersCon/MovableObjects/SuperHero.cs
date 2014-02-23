
namespace FightersCon
{
    public class SuperHero : Character
    {
        public const int SuperHeroLife = 1000;
        public const int SuperHeroAttackPower = 300;
        public const int SuperHeroDefencePower = 300;
        public const int SuperHeroShoot = 10;
        public const int SuperHeroGold = 100;
        public const int SuperHeroExperience = 1;

        public SuperHero(MatrixCoords topLeft, char[,] body, MatrixCoords speed,int attackPower, int defencePower)
            : base(topLeft, body, speed, SuperHeroAttackPower, SuperHeroDefencePower)
        {
            this.Life = SuperHeroLife;
            this.Gold = SuperHeroGold;
            this.Shoot = SuperHeroShoot;
            this.Experience = SuperHeroExperience;

        }

        public int Gold { get; private set; }
        public int Shoot { get; private set; }
        public int Experience { get; private set; } 
    }
}
