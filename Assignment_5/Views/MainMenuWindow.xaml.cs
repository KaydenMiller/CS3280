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

        /// <summary>
        /// Main menu ctor
        /// </summary>
        /// <param name="loginWindow"></param>
        public MainMenuWindow(LoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;

            InitializeComponent();
        }

        /// <summary>
        /// Will load the addition game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Will load the subtraction game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Will load the multiplication game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Will load the division game ;)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Will load the game window with with the game type.
        /// </summary>
        /// <param name="gameType"></param>
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

        /// <summary>
        /// Open the high score menu 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Exit the program correctly and close all tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Go back to the login screen to allow the user to edit or change users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
