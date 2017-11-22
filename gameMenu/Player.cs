using System.Drawing;
using System.Windows.Shapes;

namespace gameMenu
{
    public class Player : ILocation
    {
        public int Health;
        public Ellipse player;
        public double X, Y;

        public Player(int health, Ellipse player, double x, double y)
        {
            Health = health;
            this.player = player;
            X = x;
            Y = y;
        }

        double ILocation.X { get => X; set => X = value; }
        double ILocation.Y { get => Y; set => Y = value; }
    }
}