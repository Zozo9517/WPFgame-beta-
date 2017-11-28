
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gameMenu
{
    public class Player : ILocation
    {
        public int Health;
        //4 Pictures only!! Left-Up-Down-Right
        public Image[] player;
        public double X, Y;
        public Canvas canvas;
        public Image currentImage { get; set; }
        

        public Player(int health, Image[] player, double x, double y, ref Canvas gameCanvas)
        {
            Health = health;
            this.player = player;
            X = x;
            Y = y;
            canvas = gameCanvas;
        }
        public Player(int health, Image[] player, ref Canvas gameCanvas)
        {
            Health = health;
            this.player = player;
            gameWindow.GetCanvasCenter(out X, out Y);
            canvas = gameCanvas;
        }
        public Player(Image[] player, ref Canvas gameCanvas)
        {
            Health = 3;
            this.player = player;
            gameWindow.GetCanvasCenter(out X, out Y);
            canvas = gameCanvas;
            currentImage.Source = new BitmapImage(new Uri("cogwheel.png",UriKind.Relative));
        }
        /// <summary>
        /// ONLY IN TEST CASE
        /// </summary>
        public Player()
        {
            Health = 3;
            player = null;
            gameWindow.GetCanvasCenter(out X, out Y);           
        }
        double ILocation.X { get => X; set => X = value; }
        double ILocation.Y { get => Y; set => Y = value; }

        public void Move(string mve)
        {
            if(mve == "le")
            {
                if (Y + 3 > canvas.MaxHeight - 50)
                {
                   SetLocation(X, Y);
                }
                else
                {
                    SetLocation(0, Y+3);
                }
             }
            else if (mve == "fel")
            {
                if(Y - 3 < canvas.MinHeight)
                {
                    SetLocation(X, Y);
                }
                else
                {
                    SetLocation(X, Y - 3);
                }
            }
            else if(mve == "jobb")
            {
                if(X + 3 > canvas.MaxHeight - 50)
                {
                    SetLocation(X, Y);
                }
                else
                {
                    SetLocation(X - 3, Y);
                }
            }
            else if(mve == "bal")
            {
                if(X - 3 < canvas.MinWidth)
                {
                    SetLocation(X, Y);
                }
                else
                {
                    SetLocation(X + 3, Y);
                }
            }
            if (moving() == "jobble")
            {
                if (Y + 3 > canvas.MaxHeight - 50)
                {
                    SetLocation(X + 1.5, Y);
                }
                else if (X + 3 > canvas.MaxWidth - 50)
                {
                    SetLocation(X, Y + 1.5);
                }
                else
                {
                    SetLocation(X + 1.5, Y + 1.5);   
                }
            }
            else if (mve == "balle")
            {
                if (Y + 3 > canvas.MaxHeight - 50)
                {
                    SetLocation(X - 1.5, Y);

                }
                else if (X - 3 < canvas.MinWidth)
                {
                    SetLocation(X, Y + 1.5);
                }
                else
                {
                    SetLocation(X - 1.5, Y + 1.5);
                }
            }
            else if (mve== "jobbfel")
            {
                if (Y - 3 < canvas.MinHeight)
                {
                    SetLocation(X + 1.5, Y);

                }
                else if (X + 3 > canvas.MaxWidth - 50)
                {
                    SetLocation(X, Y - 1.5);
                }
                else
                {
                    SetLocation(X + 1.5, Y - 1.5);
                }
            }
            else if (mve == "balfel")
            {
                if (X - 3 < canvas.MinWidth)
                {
                    SetLocation(X, Y - 1.5);

                }
                else if (Y - 3 < canvas.MinHeight)
                {
                    SetLocation(X - 1.5, Y);
                }
                else
                {
                    SetLocation(X - 1.5, Y - 1.5);
                }
            }

        }
        static public string moving()
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

        public void SetLocation(double x, double y)
        {
            Canvas.SetLeft(currentImage, x);
            Canvas.SetTop(currentImage, y);
            X = x;
            Y = y;
        }
    }
}