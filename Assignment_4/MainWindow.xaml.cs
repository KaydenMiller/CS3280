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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// the gameManager
        /// </summary>
        GameManager gameManager = new GameManager();
        /// <summary>
        /// The images to place into the button.content property
        /// </summary>
        string[] images = System.IO.Directory.GetFiles("../../Resources/Images");
        /// <summary>
        /// an image list to store the images.
        /// </summary>
        List<BitmapImage> imageList = new List<BitmapImage>();

        /// <summary>
        /// The main window init funciton.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
            foreach (string path in images)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path, UriKind.Relative);
                bitmap.EndInit();
                imageList.Add(bitmap);
            }
            imageList.Reverse();

            btnRow0Col0.IsEnabled = false;
            btnRow0Col1.IsEnabled = false;
            btnRow0Col2.IsEnabled = false;
            btnRow1Col0.IsEnabled = false;
            btnRow1Col1.IsEnabled = false;
            btnRow1Col2.IsEnabled = false;
            btnRow2Col0.IsEnabled = false;
            btnRow2Col1.IsEnabled = false;
            btnRow2Col2.IsEnabled = false;

            // Attach event listeners
            gameManager.OnNextRound += UpdateDisplay;
            gameManager.OnGameOver += UpdateDisplay;
            gameManager.OnGameOver += OnGameOver;
        }

        /// <summary>
        /// Initalizes the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            gameManager.StartNewGame();

            ClearButtonContent();

            btnRow0Col0.IsEnabled = true;
            btnRow0Col1.IsEnabled = true;
            btnRow0Col2.IsEnabled = true;
            btnRow1Col0.IsEnabled = true;
            btnRow1Col1.IsEnabled = true;
            btnRow1Col2.IsEnabled = true;
            btnRow2Col0.IsEnabled = true;
            btnRow2Col1.IsEnabled = true;
            btnRow2Col2.IsEnabled = true;
        }

        // The following functions are all buttons on the UI that are associated with a ROW and COL.
        #region TicTacToe_Cell_Buttons
        private void btnRow0Col0_Click(object sender, RoutedEventArgs e)
        {
            if (!gameManager.isGameOver)
                btnRow0Col0.Content = GetPlayerImage(SelectGridPosition(0, 0));
        }

        private void btnRow0Col1_Click(object sender, RoutedEventArgs e)
        {
            if (!gameManager.isGameOver)
                btnRow0Col1.Content = GetPlayerImage(SelectGridPosition(1, 0));
        }

        private void btnRow0Col2_Click(object sender, RoutedEventArgs e)
        {
            if (!gameManager.isGameOver)
                btnRow0Col2.Content = GetPlayerImage(SelectGridPosition(2, 0));
        }

        private void btnRow1Col0_Click(object sender, RoutedEventArgs e)
        {
            if (!gameManager.isGameOver)
                btnRow1Col0.Content = GetPlayerImage(SelectGridPosition(0, 1));
        }

        private void btnRow1Col1_Click(object sender, RoutedEventArgs e)
        {
            if (!gameManager.isGameOver)
                btnRow1Col1.Content = GetPlayerImage(SelectGridPosition(1, 1));
        }

        private void btnRow1Col2_Click(object sender, RoutedEventArgs e)
        {
            if (!gameManager.isGameOver)
                btnRow1Col2.Content = GetPlayerImage(SelectGridPosition(2, 1));
        }

        private void btnRow2Col0_Click(object sender, RoutedEventArgs e)
        {
            if (!gameManager.isGameOver)
                btnRow2Col0.Content = GetPlayerImage(SelectGridPosition(0,2));
        }

        private void btnRow2Col1_Click(object sender, RoutedEventArgs e)
        {
            if (!gameManager.isGameOver)
                btnRow2Col1.Content = GetPlayerImage(SelectGridPosition(1, 2));
        }

        private void btnRow2Col2_Click(object sender, RoutedEventArgs e)
        {
            if (!gameManager.isGameOver)
                btnRow2Col2.Content = GetPlayerImage(SelectGridPosition(2, 2));
        }
        #endregion

        /// <summary>
        /// Selects the grid position from the gameManager based on the button position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int SelectGridPosition(int x, int y)
        {
            int player = gameManager.SelectPosition(x, y);
            return player;
        }

        /// <summary>
        /// Selects the image corrisponding with the player id
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        private Image GetPlayerImage(int playerId)
        {
            Image img = new Image();
            img.Source = imageList[playerId];
            return img;
        }

        public void OnGameOver()
        {
            lblLog.Text = String.Format("PLAYER {0} HAS WON!", gameManager.lastWinningPlayer);
        }

        /// <summary>
        /// Updates the scores and other aspects of the display
        /// </summary>
        private void UpdateDisplay()
        {
            lblPlayer1Score.Text = "Player 1: " + gameManager.player1Score.ToString();
            lblPlayer2Score.Text = "Player 2: " + gameManager.player2Score.ToString();
            lblTies.Text = "Ties: " + gameManager.ties.ToString();
        }

        /// <summary>
        /// This function will find all grid buttons and clear the images inside them.
        /// </summary>
        private void ClearButtonContent()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    object wantedNode = buttonGrid.FindName(String.Format("btnRow{0}Col{1}", row, col));
                    if (wantedNode is Button)
                    {
                        Button gridButton = wantedNode as Button;
                        gridButton.Content = null;
                        gridButton.Background = Brushes.Tan;
                    }
                }
            }
        }
    }
}
