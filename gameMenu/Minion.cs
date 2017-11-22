using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gameMenu
{
    abstract class Minion: ILocation
    {
        public int hp { get; }
        public Image minion_image;
        public double move_speed = 1.0;

        public abstract void DamagePlayer(Player player);
        public abstract void Move(Player player);
        protected double X, Y;

        public Minion(int hp, Image minion_image, double move_speed)
        {
            this.hp = hp;
            this.minion_image = minion_image;
            this.move_speed = move_speed;
        }
        public Minion(int hp, Image minion_image)
        {
            this.hp = hp;
            this.minion_image = minion_image;
        }
        double ILocation.X { get => X; set => X = value; }
        double ILocation.Y { get => Y; set => Y = value; }
    }
}
