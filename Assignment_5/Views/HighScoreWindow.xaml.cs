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

namespace Assignment_5.Views
{
    /// <summary>
    /// Interaction logic for HighScoreWindow.xaml
    /// </summary>
    public partial class HighScoreWindow : Window
    {
        IEnumerable<Score> Top10Scores = Enumerable.Empty<Score>();
        MainMenuWindow mainMenu = null;

        public HighScoreWindow(MainMenuWindow mainMenu)
        {
            InitializeComponent();
            Top10Scores = ScoreManager.GetTop10Scores();
            this.mainMenu = mainMenu;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Score[] scores = Top10Scores.ToArray();
            lbxHighScores.ItemsSource = scores.Select((x, i) => new
            {
                Index = i + 1,
                x.Username,
                x.Value
            });
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.Show();
            this.Close();
        }
    }
}
