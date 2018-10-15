using Assignment_5.Controllers;
using System.Windows;

namespace Assignment_5.Views
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
