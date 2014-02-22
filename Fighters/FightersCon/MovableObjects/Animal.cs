﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public abstract class Animal: MovableObject
    {
        protected Animal(MatrixCoords topLeft, char[,] body, MatrixCoords speed, int attackPower, int defencePower)
            : base(topLeft, body, speed, attackPower, defencePower)
        {
            this.Bonus = attackPower;
        }
         public int Bonus { get; set; }   
    }
}