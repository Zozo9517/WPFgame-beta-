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
        public Image minion_image { get; }


        public abstract void DamagePlayer(Player player);
        
    }
}
