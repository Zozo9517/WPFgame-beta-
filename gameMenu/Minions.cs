using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace gameMenu
{
    class Imp : Minion
    {

        public Imp(int hp, BitmapImage[] minion_image) : base(hp, minion_image)
        {
        }

        public Imp(int hp, BitmapImage[] minion_image, double move_speed) : base(hp, minion_image, move_speed)
        {
        }

        public override void DamagePlayer(Player player)
        {
            MessageBox.Show("Game over");
            Environment.Exit(0);
        }

        public override void Move(Player player)
        {
            double playX = player.X;
            double playY = player.Y;
            //Up right (diagonal)
            if(X>playX && Y > playY)
            {
                SetLocation(X - 1.5 * move_speed, Y - 1.5 * move_speed);
                AnimateUp();
            }
            //Down-Left (diagonal)
            if(X>playX && Y < playY)
            {
                SetLocation(X - 3 * move_speed, Y + 1.5 * move_speed);
                AnimateDown();

            }
            //Up Right (diagonal)
            if(X<playX && Y > playY)
            {
                SetLocation(X + 3 * move_speed, Y - 1.5 * move_speed);
                AnimateUp();
            }
            //Down Right (diagonal)
            if(X<playX && Y < playY)
            {
                SetLocation(X + 3 * move_speed, Y + 1.5 * move_speed);
                AnimateDown();
            }
            //Right
            if (X < playX && Y == playY) { SetLocation(X + 3 * move_speed, Y); AnimateRight(); }
            //Left
            if (X > playX && Y == playY) { SetLocation(X - 3 * move_speed, Y); AnimateLeft(); }
            //Down
            if (X == playX && Y < playY) { SetLocation(X, Y + 3 * move_speed); AnimateDown(); }
            //Up
            if (X == playX && Y > playY) { SetLocation(X, Y - 3 * move_speed); AnimateUp(); }
            //Damage Kills the player if in one line
           // if (X + 3 == playX || Y + 3 == playY || X - 3 == playX || Y - 3 == playY) DamagePlayer(player);
        }
    }
}
