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
        GameManager gameManager = new GameManager();

        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void btnAdditionGame_Click(object sender, RoutedEventArgs e)
        {
            gameManager.CreateGame(GameType.Addition);
            LoadGameWindow();
        }

        private void btnSubtractionGame_Click(object sender, RoutedEventArgs e)
        {
            gameManager.CreateGame(GameType.Subtraction);
            LoadGameWindow();
        }

        private void btnMultiplicationGame_Click(object sender, RoutedEventArgs e)
        {
            gameManager.CreateGame(GameType.Multiplication);
            LoadGameWindow();
        }

        private void btnDivisionGame_Click(object sender, RoutedEventArgs e)
        {
            gameManager.CreateGame(GameType.Division);
            LoadGameWindow();
        }

        private void LoadGameWindow()
        {
            GameWindow gameWindow = new GameWindow(ref gameManager, this);
            Hide();
            gameWindow.Show();
        }
    }
}
