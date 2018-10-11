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
using Assignment_5.Controllers;

namespace Assignment_5.Windows
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameManager gameManager;
        MainMenuWindow mainMenu;

        public GameWindow(ref GameManager gm, MainMenuWindow mainMenu)
        {
            InitializeComponent();

            gameManager = gm;
            this.mainMenu = mainMenu;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gameManager.StartGame();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.Show();
            Close();
        }
    }
}
