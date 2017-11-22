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
namespace gameMenu
{
    /// <summary>
    /// Interaction logic for gameWindow.xaml
    /// </summary>
    public partial class gameWindow : Window
    {
        public gameWindow()
        {
            InitializeComponent();
            gameCanvas.Background =new ImageBrush(new BitmapImage(new Uri(Directory.GetCurrentDirectory()+"\\FirstMap.png",UriKind.Absolute)));
                        
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            move m = new move(ref mooving, ref gameCanvas);
            m.t.Interval = TimeSpan.FromMilliseconds(10);
            m.t.Start();
        }
    }
}
