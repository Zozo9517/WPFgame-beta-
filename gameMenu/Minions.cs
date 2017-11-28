using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameMenu
{
    class Imp : Minion
    {
        public Imp(int hp, Image minion_image) : base(hp, minion_image)
        {

        }

        public override void DamagePlayer(Player player)
        {
            player.Health--;
        }

        public override void Move(Player player)
        {
            double playX = player.X;
            double playY = player.Y;
            Action DecreaseX = () =>
            {
               X -= 3 * move_speed;
            };
            Action DecreaseY = () =>
            {
               Y -= 3 * move_speed; 
            };
            Action IncreaseX = () =>
            {
                X += 3 * move_speed;
            };
            Action IncreaseY = () =>
            {
                Y += 3 * move_speed;
            };

            //Down right (diagonal)
            if(X>playX && Y > playY)
            {
                DecreaseX();
                DecreaseY();
            }
            //Up-Left (diagonal)
            if(X>playX && Y < playY)
            {
                DecreaseX();
                IncreaseY();
            }
            //Down Right (diagonal)
            if(X<playX && Y > playY)
            {
                IncreaseX();
                DecreaseY();
            }
            //Up Right (diagonal)
            if(X<playX && Y < playY)
            {
                IncreaseX();
                IncreaseY();
            }
            //Left
            if (X < playX && Y == playY) DecreaseX();
            //Right
            if (X > playX && Y == playY) IncreaseX();
            //Up
            if (X == playX && Y < playY) IncreaseY();
            //Down
            if (X == playX && Y > playY) DecreaseY();
            //Damage
            if (X + 3 == playX || Y + 3 == playY || X - 3 == playX || Y - 3 == playY) DamagePlayer(player);
        }
    }
}
