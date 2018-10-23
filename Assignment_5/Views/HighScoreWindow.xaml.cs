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
using Assignment_5.Models;
using Assignment_5.Extensions;
using System.Media;

namespace Assignment_5.Views
{
    /// <summary>
    /// Interaction logic for HighScoreWindow.xaml
    /// </summary>
    public partial class HighScoreWindow : Window
    {
        IEnumerable<Score> Top10Scores = Enumerable.Empty<Score>();
        MainMenuWindow mainMenu = null;
        SoundPlayer soundPlayer = new SoundPlayer();

        /// <summary>
        /// The value of the score for use with DataBinding
        /// </summary>
        public int Value { get; set; } = 1000;

        /// <summary>
        /// The highscore windows ctor
        /// </summary>
        /// <param name="mainMenu"></param>
        public HighScoreWindow(MainMenuWindow mainMenu)
        {
            InitializeComponent();
            DataContext = this;

            try
            {
                Top10Scores = ScoreManager.GetTop10Scores();
                Value = ScoreManager.GetLastScore().Value;
                this.mainMenu = mainMenu;
                soundPlayer.SoundLocation = "Resources/Audio/StarWarsThemeEnd.wav";
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// When the window is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Score[] scores = Top10Scores.ToArray();
                lbxHighScores.ItemsSource = scores.Select((x, i) => new
                {
                    Index = i + 1,
                    x.Username,
                    x.Value
                });
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// When the main menu button is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainMenu.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        /// <summary>
        /// When the window is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                soundPlayer.Stop();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }
    }
}
