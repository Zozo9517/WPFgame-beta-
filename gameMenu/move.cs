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
        public move(ref Ellipse e, ref Canvas c,ref Rectangle one, ref Rectangle two, ref Rectangle thr, ref Rectangle four, ref Rectangle five, ref Rectangle six, ref Rectangle sev, ref Rectangle eig, ref Ellipse ell)
        {
            t.Tick += t_Tick;
            mooving = e;
            gameCanvas = c;
            rekt1 = one;
            rekt2 = two;
            rekt3 = thr;
            rekt4 = four;
            rekt5 = five;
            rekt6 = six;
            rekt7 = sev;
            rekt8 = eig;
            eli = ell;
            
        }
        private Ellipse mooving;
        private Canvas gameCanvas;
        private Rectangle rekt1;
        private Rectangle rekt2;
        private Rectangle rekt3;
        private Rectangle rekt4;
        private Rectangle rekt5;
        private Rectangle rekt6;
        private Rectangle rekt7;
        private Rectangle rekt8;
        private Ellipse eli;
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
            if (moving() == "le" && !utkozes())
            {
                if (y + 3 > gameCanvas.MaxHeight-50)
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
                if (y - 3 < gameCanvas.MinHeight)
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
                if (x + 3 > gameCanvas.MaxHeight-50)
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
                if (y + 3 > gameCanvas.MaxHeight-50)
                {
                   
                    y -= 0;
                    x += 1.5;
                }
                else if (x + 3 > gameCanvas.MaxWidth-50)
                {
                    x += 0;
                    y += 1.5;
                }
                else
                {
                    x += 1.5;
                    y += 1.5;
                }
            }
            else if (moving() == "balle")
            {
                if (y + 3 > gameCanvas.MaxHeight -50 )
                {
                    x -= 1.5;
                    y += 0;
                }
                else if (x - 3 < gameCanvas.MinWidth)
                {
                    x -= 0;
                    y += 1.5;
                }
                else
                {
                    x -= 1.5;
                    y += 1.5;
                }
            }
           else if (moving() == "jobbfel")
            {
                if (y - 3 < gameCanvas.MinHeight)
                {
                    x += 1.5;
                    y -= 0;
                }
                else if (x + 3 > gameCanvas.MaxWidth - 50)
                {
                    x += 0;
                    y -= 1.5;
                }
                else
                {
                    x += 1.5;
                    y -= 1.5;
                }
            }
           else if (moving() == "balfel")
            {
                if ( x - 3 < gameCanvas.MinWidth)
                {
                    x -= 0;
                    y -= 1.5;

                }
                else if (y - 3 < gameCanvas.MinHeight)
                {
                    y -= 0;
                    x -= 1.5;
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
        public bool utkozes()
        {
          /*  if (moving() == "le")
            {
                if (Rect.Intersect(rekt1)
                {
                    return true;
                }
            }
            */
            return false;
        }
    }
}
