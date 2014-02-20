using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public interface IControllable
    {
        int AttackPower
        {
            get;
            set;
        }

        int DefensePower
        {
            get;
            set;
        }

        int GetTargetIndex(List<WorldObject> availableTargets);
    }
}
