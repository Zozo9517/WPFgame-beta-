using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace gameMenu
{
    public partial class move
    {
        public DispatcherTimer t = new DispatcherTimer();
        public move(ref Ellipse e, ref Canvas c)
        {
            t.Tick += t_Tick;
            mooving = e;
            gameCanvas = c;
        }
        private Ellipse mooving;
        private Canvas gameCanvas;
        static public String moving()
        {
            if (Keyboard.IsKeyDown(Key.Down) && !Keyboard.IsKeyDown(Key.Right) && !Keyboard.IsKeyDown(Key.Left))
            {
                return "le";
            }
            else if (Keyboard.IsKeyDown(Key.Up) && !Keyboard.IsKeyDown(Key.Right) && !Keyboard.IsKeyDown(Key.Left))
            {
                return "fel";
            }
            else if (Keyboard.IsKeyDown(Key.Left) && !Keyboard.IsKeyDown(Key.Down) && !Keyboard.IsKeyDown(Key.Up))
            {
                return "bal";
            }
            else if (Keyboard.IsKeyDown(Key.Right) && !Keyboard.IsKeyDown(Key.Down) && !Keyboard.IsKeyDown(Key.Up))
            {
                return "jobb";
            }
            if ((Keyboard.IsKeyDown(Key.Up) && Keyboard.IsKeyDown(Key.Right)) || (Keyboard.IsKeyDown(Key.Right) && Keyboard.IsKeyDown(Key.Up)))
            {
                return "jobbfel";
            }
            else if ((Keyboard.IsKeyDown(Key.Down) && Keyboard.IsKeyDown(Key.Left)) || (Keyboard.IsKeyDown(Key.Left) && Keyboard.IsKeyDown(Key.Down)))
            {
                return "balle";
            }
            else if ((Keyboard.IsKeyDown(Key.Up) && Keyboard.IsKeyDown(Key.Left)) || (Keyboard.IsKeyDown(Key.Left) && Keyboard.IsKeyDown(Key.Up)))
            {
                return "balfel";
            }
            else if ((Keyboard.IsKeyDown(Key.Down) && Keyboard.IsKeyDown(Key.Right)) || (Keyboard.IsKeyDown(Key.Right) && Keyboard.IsKeyDown(Key.Down)))
            {
                return "jobble";
            }
            else
            {
                return "semmi";
            }

        }
        static double x;
        static double y;
        public void t_Tick(object sender, EventArgs e)
        {
            x = Canvas.GetLeft(mooving);
            y = Canvas.GetTop(mooving);
            if (moving() == "le")
            {
                if (y + 3 > gameCanvas.MaxHeight)
                {
                    y += 0;
                }
                else
                {
                    y += 3;
                }

            }
            else if (moving() == "fel")
            {
                if (y + 3 > gameCanvas.MaxHeight)
                {
                    y -= 0;
                }
                else
                {
                    y -= 3;
                }
            }
            else if (moving() == "jobb")
            {
                if (x + 3 > gameCanvas.ActualWidth)
                {
                    x += 0;
                }
                else
                {
                    x += 3;
                }
            }
            else if (moving() == "bal")
            {
                if (x - 3 < gameCanvas.MinWidth)
                {
                    x += 0;
                }
                else
                {
                    x -= 3;
                }
            }
            if (moving() == "jobble")
            {
                if ((y - 3 < gameCanvas.MinHeight && x + 3 > gameCanvas.ActualWidth))
                {
                    x += 0;
                    y -= 0;
                }
                else
                {
                    x += 1.5;
                    y += 1.5;
                }
            }
            if (moving() == "balle")
            {
                if ((y - 3 < gameCanvas.MinHeight && x + 3 > gameCanvas.MinWidth))
                {
                    x += 0;
                    y -= 0;
                }
                else
                {
                    x -= 1.5;
                    y += 1.5;
                }
            }
            if (moving() == "jobbfel")
            {
                if ((y - 3 < gameCanvas.MinHeight && x + 3 > gameCanvas.ActualWidth))
                {
                    x += 0;
                    y -= 0;
                }
                else
                {
                    x += 1.5;
                    y -= 1.5;
                }
            }
            if (moving() == "balfel")
            {
                if ((y - 3 < gameCanvas.MinHeight && x + 3 > gameCanvas.ActualWidth))
                {
                    x += 0;
                    y -= 0;
                }
                else
                {
                    x -= 1.5;
                    y -= 1.5;
                }
            }
            Canvas.SetLeft(mooving, x);
            Canvas.SetTop(mooving, y);

        }
    }
}
