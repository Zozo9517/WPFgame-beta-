using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace gameMenu
{
    abstract class Minion: ILocation
    {
        public int hp { get; }
        public BitmapImage[] minion;
        public double move_speed = 0.5;
        private int currentDown = 0, currentUp = 3, currentLeft = 7, currentRight = 11;
        public abstract void DamagePlayer(Player player);
        public abstract void Move(Player player);
        protected double X, Y;
        protected int AnimTick = 0;
        protected Image minionInstance;
        protected Canvas canvasInstance;

        public Minion(int hp, BitmapImage[] minion_image, double move_speed)
        {
            this.hp = hp;
            this.minion = minion_image;
            this.move_speed = move_speed;
        }
        public Minion(int hp, BitmapImage[] minion_image)
        {
            this.hp = hp;
            this.minion = minion_image;
        }
        public void InitMinion(ref Image image, ref Canvas canvas)
        {
            minionInstance = image;
            canvasInstance = canvas;
            ChImSrc(minion[0]);
        }
        //Change required
        public void SetLocation(double x, double y)
        {
            Canvas.SetLeft(minionInstance, x);
            Canvas.SetTop(minionInstance, y);
            X = x;
            Y = y;
        }
        public BitmapImage GetStandby()
        {
            return minion[0];
        }
        protected void AnimateDown()
        {
            if (AnimTick == 5)
            {
                ChImSrc(minion[currentDown]);
                if (currentDown >= 3) currentDown = 0;
                else currentDown++;
                AnimTick = 0;
            }
            else
            {
                AnimTick++;

            }
        }
        protected void AnimateUp()
        {
            if (AnimTick == 5)
            {
                ChImSrc(minion[currentUp]);
                if (currentUp >= 7) currentUp = 4;
                else currentUp++;
                AnimTick = 0;
            }
            else
            {
                AnimTick++;

            }
        }
        protected void AnimateLeft()
        {
            if (AnimTick == 5)
            {
                ChImSrc(minion[currentLeft]);
                if (currentLeft >= 11) currentLeft = 8;
                else currentLeft++;
                AnimTick = 0;
            }
            else
            {
                AnimTick++;
            }

        }
        protected void AnimateRight()
        {
            if (AnimTick == 5)
            {
                ChImSrc(minion[currentRight]);
                if (currentRight >= 15) currentRight = 12;
                else currentRight++;
                AnimTick = 0;
            }
            else
            {
                AnimTick++;
            }
        }
        public void ChImSrc(BitmapImage bim)
        {
            minionInstance.Source = bim;
        }
        double ILocation.X { get => X; set => X = value; }
        double ILocation.Y { get => Y; set => Y = value; }
    }
}
