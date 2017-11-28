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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

using gameMenu.Debug;

namespace gameMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Settings Params
        static bool DebugMode = SettingsListener.DebugMode();
        #endregion
        bool playmenu = true;
        static private MediaPlayer playsong = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();

            #region Init Uris
            cogwheel_png.Source = new BitmapImage(StaticURIs.Cogwheel);
            help_png.Source = new BitmapImage(StaticURIs.Help);

            #endregion

            Logging.CreateLogDir();
            if(DebugMode) Logging.ShowDebugLog();
            playS();

            Logging.WriteLog("Playing background video...");
            menubck.Source = StaticURIs.MenuVideo;
            menubck.Play();
            
        }
        /// <summary>
        /// Playing song...
        /// </summary>
        private void playS()
        {
            Logging.WriteLog("Playing Music...");
            Uri uri = StaticURIs.MenuMusic;
            playsong.Open(uri);
            playsong.MediaEnded += Playsong_MediaEnded;
            playsong.Play();
        }
        /// <summary>
        /// Helps for the background music to be infinite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void Playsong_MediaEnded(object sender, EventArgs e)
        {
            if (playmenu)
            {
                Logging.WriteLog("Looping music!");
                playsong.Position = TimeSpan.Zero;
                playsong.Play();
            }
            else
            {
                playsong.Stop();
                Logging.WriteLog("Stopped background music!");
            }
        }
        
        /// <summary>
        /// Helps for the background to be infinite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (playmenu)
            {
                Logging.WriteLog("Looping background!");
                menubck.Position = TimeSpan.Zero;
            }
            else
            {
                menubck.Stop();
                Logging.WriteLog("Stopped background!");
            }

        }

        private void newGame_btn_Click(object sender, RoutedEventArgs e)
        {
            Logging.WriteLog("Hide MainMenu!");
            Hide();
            CharacterSelection cs = new CharacterSelection();
            playmenu = false;
            Logging.WriteLog("Stopped music");
            playsong.Stop();
            Logging.WriteLog("Character selection");
            cs.Show();
        }

        private void score_btn_Click(object sender, RoutedEventArgs e)
        {
            Logging.WriteLog("Not yet implemented!", LogType.WARNING);
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Logging.WriteLog("Exiting the app!");
            string CurrentTime = DateTime.Now.ToString().Replace(':', '-').Replace('/','-');
            string path = Directory.GetCurrentDirectory() + "\\logs" + "\\" ;
            string file = CurrentTime + "_Log.txt";
            StreamWriter streamWriter = new StreamWriter(path+file);
            List<string> log = Logging.GetLog();
            for (int i = 0; i < log.Count; i++)
            {
                streamWriter.WriteLine(log[i]);
            }
            streamWriter.Close();
            Environment.Exit(0);
        }

        private void cogwheel_png_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Logging.WriteLog("Showing settings...");
            SettingsListener.ShowSettings();
        }

        private void help_png_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Logging.WriteLog("Showing Help Window....");
            Help help = new Help();
            help.Show();
        }
    }
}