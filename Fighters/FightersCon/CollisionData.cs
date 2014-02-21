using System.Collections.Generic;

namespace FightersCon
{
    public class CollisionData
    {
        public readonly MatrixCoords CollisionForceDirection;

        public readonly List<string> HitObjectsCollisionGroupStrings;

        // constructor - currently not in use
        public CollisionData(MatrixCoords collisionForceDirection, string objectCollisionGroupString)
        {
            this.CollisionForceDirection = collisionForceDirection;
            this.HitObjectsCollisionGroupStrings = new List<string> { objectCollisionGroupString };
        }
        // constructor - contains information in regrads to the coliisions, including force and direction.
        public CollisionData(MatrixCoords collisionForceDirection, IEnumerable<string> hitObjectsCollisionGroupStrings)
        {
            this.CollisionForceDirection = collisionForceDirection;

            this.HitObjectsCollisionGroupStrings = new List<string>();

            foreach (var str in hitObjectsCollisionGroupStrings)
            {
                this.HitObjectsCollisionGroupStrings.Add(str);
            }
        }
    }
}
