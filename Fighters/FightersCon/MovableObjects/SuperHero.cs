
namespace FightersCon
{
    public class SuperHero : Character
    {
        private const int SuperHeroLife = 1000;
        public static char[,] HeroBody = new char[,] {{'/', '/', '-', '-', '\\'},
                                                      {'C', ' ', 'O',' ', 'O'},
                                                      {' ', '\\', ' ',' ', '>'},
                                                      {' ', ' ', '\\','_', '-'}};

        

        public SuperHero(MatrixCoords topLeft, MatrixCoords speed,int attackPower, int defencePower)
            : base(topLeft, HeroBody, speed, attackPower, defencePower)
        {
            this.Life = SuperHeroLife;
            this.Gold = 100;
            this.Shoot = 10;
            this.Experience = 1;
        }

        public int Gold { get; set; }
        public int Shoot { get; set; }
        public int Experience { get; set; }
        
    }
}


