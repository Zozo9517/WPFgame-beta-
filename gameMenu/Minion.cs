using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gameMenu
{
    abstract class Minion
    {
        public int hp { get; }
        public Image minion_image;
        public double move_speed = 1.0;

        public abstract void DamagePlayer(Player player);
        public abstract void Move(Player player);

    }
}
