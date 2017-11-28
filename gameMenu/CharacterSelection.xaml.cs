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

namespace gameMenu
{
    /// <summary>
    /// Interaction logic for CharacterSelection.xaml
    /// </summary>
    public partial class CharacterSelection : Window
    {
        public CharacterSelection()
        {
            InitializeComponent();
        }

        private void ChoosePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player p = new Player();
            gameWindow gw = new gameWindow(p);
            this.Close();
            gw.Show();
        }
    }
}
