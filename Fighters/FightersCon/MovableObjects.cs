using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public abstract class MovableObject : WorldObject, IControllable
    {
        protected MovableObject(MatrixCoords topLeft, char[,] body, int attackPower, int defencePower)
            : base(topLeft, body)
        {
            this.AttackPower = attackPower;
            this.DefensePower = defencePower;
        }

        public int AttackPower { get; set; }

        public int DefensePower { get; set; }

        public abstract int GetTargetIndex(List<WorldObject> availableTargets)
        {
            return 0;     ////????
        }
    }
}
