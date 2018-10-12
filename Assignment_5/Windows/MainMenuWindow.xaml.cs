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
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void btnAdditionGame_Click(object sender, RoutedEventArgs e)
        {
            LoadGameWindow(GameType.Addition);
        }

        private void btnSubtractionGame_Click(object sender, RoutedEventArgs e)
        {
            LoadGameWindow(GameType.Subtraction);
        }

        private void btnMultiplicationGame_Click(object sender, RoutedEventArgs e)
        {
            LoadGameWindow(GameType.Multiplication);
        }

        private void btnDivisionGame_Click(object sender, RoutedEventArgs e)
        {
            LoadGameWindow(GameType.Division);
        }

        private void LoadGameWindow(GameType gameType)
        {
            GameWindow gameWindow = new GameWindow(this, gameType);
            Hide();
            gameWindow.Show();
        }
    }
}
