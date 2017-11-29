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
using System.Threading;

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
      
        private List<Image> Enemies_Box = new List<Image>();
        private List<Minion> Enemies = new List<Minion>();
        private Spawner MainSpawner;
        //Wave Spawner
        Waves waves = new Waves();
        int currentWave = 0;
        int currentSpawn;
        
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
            MainSpawner = new Spawner(Enemies_Box, Enemies);
            MainSpawner.InitSpawner(ref gameCanvas);
            currentSpawn = 0;
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
            if(currentSpawn < waves[currentWave])
            {           
                MainSpawner.Spawn();
                currentSpawn++;
            }
            else
            {
                if(waves.Count() >= currentWave)
                {
                    waves.AddWaveExp();
                }
                else
                {
                    currentWave++;
                }
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
            spawnTimer.Interval = TimeSpan.FromMilliseconds(2000);
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
