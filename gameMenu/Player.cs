using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using gameMenu.Debug;

namespace gameMenu
{

    //TODO: CODE SIMPLIFICATION
    public class Player : ILocation
    {
        public int Health;

        public BitmapImage[] player;
        public double X, Y;
        public Canvas canvas;
        public Image currentImage { get; set; }

        private int currentDown = 0, currentUp = 5, currentLeft = 10, currentRight = 15;
        private int AnimTick = 0;

        public Player(int health, BitmapImage[] player, double x, double y, ref Canvas gameCanvas)
        {
            Health = health;
            this.player = player;
            X = x;
            Y = y;
            canvas = gameCanvas;
        }

        public Player(int health, BitmapImage[] player, ref Canvas gameCanvas)
        {
            Health = health;
            this.player = player;
            gameWindow.GetCanvasCenter(out X, out Y);
            canvas = gameCanvas;
        }

        public Player(BitmapImage[] player, ref Canvas gameCanvas)
        {
            Health = 3;
            this.player = player;
            gameWindow.GetCanvasCenter(out X, out Y);
            canvas = gameCanvas;
            currentImage.Source = new BitmapImage(new Uri("cogwheel.png",UriKind.Relative));
        }

        public void InitPlayer(ref Image playerInstance)
        {
            currentImage = playerInstance;
            ChImSrc(player[0]); //Player Standby For the first time
        }
        
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
                if (Y + 3 > canvas.MaxHeight)
                {
                   SetLocation(X, Y);
                   AnimateDown();
                }
                else
                {
                    SetLocation(X, Y+3);
                    AnimateDown();
                }
             }
            else if (mve == "fel")
            {
                if(Y - 3 < canvas.MinHeight)
                {
                    SetLocation(X, Y);
                    AnimateUp();
                }
                else
                {
                    SetLocation(X, Y - 3);
                    AnimateUp();
                }
            }
            else if(mve == "bal")
            {
                if(X + 3 > canvas.MaxHeight - 50)
                {
                    SetLocation(X, Y);
                    AnimateLeft();
                }
                else
                {
                    SetLocation(X - 3, Y);
                    AnimateLeft();
                }
            }
            else if(mve == "jobb")
            {
                if(X - 3 < canvas.MinWidth)
                {
                    SetLocation(X, Y);
                    AnimateRight();
                }
                else
                {
                    SetLocation(X + 3, Y);
                    AnimateRight();
                }
            }
            if (moving() == "jobble")
            {
                if (Y + 3 > canvas.MaxHeight - 50)
                {
                    SetLocation(X + 1.5, Y);
                    AnimateDown();
                }
                else if (X + 3 > canvas.MaxWidth - 50)
                {
                    SetLocation(X, Y + 1.5);
                    AnimateDown();
                }
                else
                {
                    SetLocation(X + 1.5, Y + 1.5);
                    AnimateDown();
                }
            }
            else if (mve == "balle")
            {
                if (Y + 3 > canvas.MaxHeight - 50)
                {
                    SetLocation(X - 1.5, Y);
                    AnimateDown();

                }
                else if (X - 3 < canvas.MinWidth)
                {
                    SetLocation(X, Y + 1.5);
                    AnimateDown();
                }
                else
                {
                    SetLocation(X - 1.5, Y + 1.5);
                    AnimateDown();
                }
            }
            else if (mve== "jobbfel")
            {
                if (Y - 3 < canvas.MinHeight)
                {
                    SetLocation(X + 1.5, Y);
                    AnimateUp();

                }
                else if (X + 3 > canvas.MaxWidth - 50)
                {
                    SetLocation(X, Y - 1.5);
                    AnimateUp();
                }
                else
                {
                    SetLocation(X + 1.5, Y - 1.5);
                    AnimateUp();
                }
            }
            else if (mve == "balfel")
            {
                if (X - 3 < canvas.MinWidth)
                {
                    SetLocation(X, Y - 1.5);
                    AnimateUp();
                }
                else if (Y - 3 < canvas.MinHeight)
                {
                    SetLocation(X - 1.5, Y);
                    AnimateUp();
                }
                else
                {
                    SetLocation(X - 1.5, Y - 1.5);
                    AnimateUp();
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
            //Logging.WriteLog(String.Format("Player is at X[{0}] Y[{1} and moving to X[{2}] Y[{3}]",X,Y,x,y)); Memory can't handle this #SadPanda
            Canvas.SetLeft(currentImage, x);
            Canvas.SetTop(currentImage, y);
            X = x;
            Y = y;
        }

        private void AnimateDown()
        {
            if (AnimTick == 5)
            {
                ChImSrc(player[currentDown]);
                if (currentDown >= 4) currentDown = 0;
                else currentDown++;
                AnimTick = 0;
            }
            else
            {
                AnimTick++;

            }
        }
        private void AnimateUp()
        {
            if (AnimTick == 5)
            {
                ChImSrc(player[currentUp]);
                if (currentUp >= 9) currentUp = 5;
                else currentUp++;
                AnimTick = 0;
            }
            else
            {
                AnimTick++;

            }
        }
        private void AnimateLeft()
        {
            if (AnimTick == 5)
            {
                ChImSrc(player[currentLeft]);
                if (currentLeft >= 14) currentLeft = 10;
                else currentLeft++;
                AnimTick = 0;
            }
            else
            {
                AnimTick++;
            }

        }
        private void AnimateRight()
        {
            if (AnimTick == 5)
            {
                ChImSrc(player[currentRight]);
                if (currentRight >= 19) currentRight = 15;
                else currentRight++;
                AnimTick = 0;
            }
            else
            {
                AnimTick++;
            }
        }
        private void ChImSrc(BitmapImage bim)
        {
            currentImage.Source = bim;
        }
    }
}