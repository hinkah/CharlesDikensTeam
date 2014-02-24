﻿
namespace FightersCon
{
    public class SuperHero : Character
    {
        public const int SuperHeroLife = 1000;
        public const int SuperHeroAttackPower = 500;
        public const int SuperHeroDefencePower = 300;
        public const int SuperHeroShoot = 10;
        public const int SuperHeroGold = 100;
        public const int SuperHeroExperience = 1;
        public static char[,] heroBody = new char[,] {{'/', '/', '-', '-', '\\'},
                                                      {'C', ' ', 'O',' ', 'O'},
                                                      {' ', '\\', ' ',' ', '>'},
                                                      {' ', ' ', '\\','_', '-'}};

        

        public SuperHero(MatrixCoords topLeft, MatrixCoords speed,int attackPower, int defencePower)
            : base(topLeft, heroBody, speed, SuperHeroAttackPower, SuperHeroDefencePower)
        {
            this.Life = SuperHeroLife;
            this.Gold = SuperHeroGold;
            this.Shoot = SuperHeroShoot;
            this.AttackPower = SuperHeroAttackPower;
            this.DefensePower = SuperHeroDefencePower;
            this.Experience = SuperHeroExperience;

        }

        public int Gold { get; set; }
        public int Shoot { get; set; }
        public int Experience { get; set; }
        
    }
}


