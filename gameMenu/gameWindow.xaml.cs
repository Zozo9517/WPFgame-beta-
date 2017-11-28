using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace gameMenu
{
    /// <summary>
    /// Interaction logic for gameWindow.xaml
    /// </summary>
    public partial class gameWindow : Window
    {
        private DispatcherTimer mainTimer = new DispatcherTimer();
        private DispatcherTimer minionTimer = new DispatcherTimer();
        private DispatcherTimer spawnTimer = new DispatcherTimer();
        private Player player;
        private List<Minion> Enemies = new List<Minion>();

        //One Minion
        bool onespawned = false;
        public gameWindow()
        {
            InitializeComponent();
            gameCanvas.Background = new ImageBrush(new BitmapImage(StaticURIs.FirstMap));
            mainTimer.Tick += MainTimer_Tick;
        }
        public gameWindow(Player p)
        {
            InitializeComponent();
            gameCanvas.Background = new ImageBrush(new BitmapImage(StaticURIs.FirstMap));
            mainTimer.Tick += MainTimer_Tick;
            spawnTimer.Tick += SpawnTimer_Tick;
            minionTimer.Tick += MinionTimer_Tick;
            player = p;
            player.canvas = gameCanvas;
            Canvas.SetLeft(playerCurrentImage, 375);
            Canvas.SetTop(playerCurrentImage, 375);
           
          }

        private void MinionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Move(player);
            }
        }

        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            if(!onespawned)
            {
                Imp i = new Imp(1, StaticURIs.Imp_BitMaps);
                Image imp_image = new Image();
                imp_image.Height = 50;
                imp_image.Width = 50;
                i.InitMinion(ref imp_image, ref gameCanvas);
                gameCanvas.Children.Add(imp_image);
                Canvas.SetTop(imp_image, 375);
                Canvas.SetLeft(imp_image, 50);
                onespawned = true;
                Enemies.Add(i);
            }
        }

        /// <summary>
        /// Game Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            player.Move(Player.moving());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //move m = new move(ref mooving, ref gameCanvas, ref rekt1, ref rekt2, ref rekt3, ref rekt4, ref rekt5, ref rekt6, ref rekt7, ref rekt8, ref eli);
            //m.t.Interval = TimeSpan.FromMilliseconds(10);
            // m.t.Start();
            mainTimer.Interval = TimeSpan.FromMilliseconds(10);
            minionTimer.Interval = TimeSpan.FromMilliseconds(5);
            spawnTimer.Interval = TimeSpan.FromMilliseconds(200);
            mainTimer.Start();
            minionTimer.Start();
            spawnTimer.Start();
        }

        public static void GetCanvasCenter(out double x, out double y)
        {
            x = 375;
            y = 375;
        }

    }
}
