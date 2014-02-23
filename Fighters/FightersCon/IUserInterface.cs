using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public interface IUserInterface
    {
        void ProcessInput(WorldObject hero, List<WorldObject> otherObjects);
    }
}
