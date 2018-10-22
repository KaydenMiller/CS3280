using Assignment_5.Controllers;
using System.Windows;
using Assignment_5.Extensions;
using System;

namespace Assignment_5.Views
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        LoginWindow loginWindow;

        public MainMenuWindow(LoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;

            InitializeComponent();
        }

        private void btnAdditionGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadGameWindow(GameType.Addition);
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void btnSubtractionGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadGameWindow(GameType.Subtraction);
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void btnMultiplicationGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadGameWindow(GameType.Multiplication);
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void btnDivisionGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadGameWindow(GameType.Division);
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void LoadGameWindow(GameType gameType)
        {
            try
            {
                GameWindow gameWindow = new GameWindow(this, gameType);
                Hide();
                gameWindow.Show();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void btnScore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                HighScoreWindow highScoreWindow = new HighScoreWindow(this);
                highScoreWindow.Show();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void btnLoginScreen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loginWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }
    }
}
