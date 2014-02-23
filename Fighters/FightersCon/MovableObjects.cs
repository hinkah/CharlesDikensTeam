
namespace FightersCon
{
    public abstract class MovableObject : WorldObject, IMovable, IControllable
    {
        protected MovableObject(MatrixCoords topLeft, char[,] body, MatrixCoords speed,int attackPower, int defencePower)
            : base(topLeft, body)
        {
            this.Speed = speed;
            this.AttackPower = attackPower;
            this.DefensePower = defencePower;

        }
        public MatrixCoords Speed { get; protected set; } 

        public int AttackPower { get; set; }

        public int DefensePower { get; set; }

        public virtual void UpdatePosition() // update of the current posiition at the speed predefined.
        {
            this.TopLeft += this.Speed;
        }

        public override void Update() // this method is called at each iteration of the game
        {
            this.UpdatePosition(); // update of the current posiition at the speed predefined.
        }
    }
}
