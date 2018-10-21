﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Assignment_5.Controllers;
using Assignment_5.Extensions;

namespace Assignment_5.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        MainMenuWindow mainMenu;
        GameManager gameManager = new GameManager();
        Game currentGame;
        RoundInfo currentRound;
        Timer uiUpdateTimer = new Timer();

        const int TIMER_REFRESH_RATE_MILLI = 500;

        public GameWindow(MainMenuWindow mainMenu, GameType gameType)
        {
            InitializeComponent();

            try
            {
                this.mainMenu = mainMenu;

                uiUpdateTimer.Interval = TIMER_REFRESH_RATE_MILLI;
                uiUpdateTimer.Elapsed += UpdateUiElapsed;

                currentGame = gameManager.CreateGame(gameType);
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                currentGame.StartGame();
                currentRound = currentGame.GetCurrentRoundInfo();
                UpdateDisplay();
                uiUpdateTimer.Start();
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
                uiUpdateTimer.Stop();
                uiUpdateTimer.Dispose();
                mainMenu.Show();
                Close();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void UpdateDisplay()
        {
            try
            {
                tbkFirstOperand.Text = currentRound.FirstOperand.ToString();
                tbkSecondOperand.Text = currentRound.SecondOperand.ToString();
                tbkOperation.Text = currentRound.Operator;
                tbkGameMode.Text = Enum.GetName(typeof(GameType), currentGame.CurrentGameType);
                tbkRoundInfo.Text = String.Format("Round: {0}/10", currentGame.CurrentRound + 1);
                UpdateTime();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void UpdateTime()
        {
            try
            {
                TimeSpan duration = currentGame.GetElapsedTime();
                tbkGameTime.Text = duration.ToString(@"mm\:ss");
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void UpdateUiElapsed(object source, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke(UpdateTime);
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int bob = int.Parse(txtUserAnswer.Text);
                bool isCorrect = currentGame.ValidateUserAnswer(bob);
                if (isCorrect)
                {
                    tbkResult.Text = "SUCCESS!";
                    tbkResult.Style = FindResource("TextBlockStyle_Success") as Style;
                    
                }
                else
                {
                    tbkResult.Text = "INCORRECT!";
                    tbkResult.Style = FindResource("TextBlockStyle_Failure") as Style;
                }
                tbkResult.Visibility = Visibility.Visible;
                btnSubmit.IsEnabled = false;
                btnNext.IsEnabled = true;
                btnNext.IsDefault = true;

                // Try to go to the next round
                currentGame.NextRound();
            }
            catch (FormatException fex)
            {
                // User entered invalid input notify the user
                MessageBox.Show("Please enter a valid numeric value into the answer field.", "Invalid User Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (ResourceReferenceKeyNotFoundException resourceEx)
            {
                resourceEx.Log();
                MessageBox.Show(resourceEx.Message, "Resource Not Found Exception!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!currentGame.GameOver)
                {
                    // The game is not yet over go to the next round
                    currentRound = currentGame.GetCurrentRoundInfo();
                    UpdateDisplay();
                    tbkResult.Visibility = Visibility.Hidden;
                    btnSubmit.IsEnabled = true;
                    btnNext.IsEnabled = false;
                    btnSubmit.IsDefault = true;
                    txtUserAnswer.Text = "";
                }
                else
                {
                    // The game is over go to the score screen
                    HighScoreWindow highScoreWind = new HighScoreWindow(mainMenu);
                    highScoreWind.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }
    }
}