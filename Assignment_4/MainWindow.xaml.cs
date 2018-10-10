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
        GameManager gameManager = new GameManager();
        string[] images = System.IO.Directory.GetFiles("../../Resources/Images");
        List<BitmapImage> imageList = new List<BitmapImage>();

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

            btnRow0Col0.IsEnabled = false;
            btnRow0Col1.IsEnabled = false;
            btnRow0Col2.IsEnabled = false;
            btnRow1Col0.IsEnabled = false;
            btnRow1Col1.IsEnabled = false;
            btnRow1Col2.IsEnabled = false;
            btnRow2Col0.IsEnabled = false;
            btnRow2Col1.IsEnabled = false;
            btnRow2Col2.IsEnabled = false;
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            gameManager.StartNewGame();

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

        private void btnRow0Col0_Click(object sender, RoutedEventArgs e)
        {
            int player = gameManager.SelectPosition(0, 0);
            Image img = new Image();
            img.Source = imageList[player];
            btnRow0Col0.Content = img;
        }

        private void btnRow0Col1_Click(object sender, RoutedEventArgs e)
        {
            int player = gameManager.SelectPosition(0, 1);
            Image img = new Image();
            img.Source = imageList[player];
            btnRow0Col1.Content = img;
        }

        private void btnRow0Col2_Click(object sender, RoutedEventArgs e)
        {
            int player = gameManager.SelectPosition(0, 2);
            Image img = new Image();
            img.Source = imageList[player];
            btnRow0Col2.Content = img;
        }

        private void btnRow1Col0_Click(object sender, RoutedEventArgs e)
        {
            int player = gameManager.SelectPosition(1, 0);
            Image img = new Image();
            img.Source = imageList[player];
            btnRow1Col0.Content = img;
        }

        private void btnRow1Col1_Click(object sender, RoutedEventArgs e)
        {
            int player = gameManager.SelectPosition(1, 1);
            Image img = new Image();
            img.Source = imageList[player];
            btnRow1Col1.Content = img;
        }

        private void btnRow1Col2_Click(object sender, RoutedEventArgs e)
        {
            int player = gameManager.SelectPosition(1, 2);
            Image img = new Image();
            img.Source = imageList[player];
            btnRow1Col2.Content = img;
        }

        private void btnRow2Col0_Click(object sender, RoutedEventArgs e)
        {
            int player = gameManager.SelectPosition(2, 0);
            Image img = new Image();
            img.Source = imageList[player];
            btnRow2Col0.Content = img;
        }

        private void btnRow2Col1_Click(object sender, RoutedEventArgs e)
        {
            int player = gameManager.SelectPosition(2, 1);
            Image img = new Image();
            img.Source = imageList[player];
            btnRow2Col1.Content = img;
        }

        private void btnRow2Col2_Click(object sender, RoutedEventArgs e)
        {
            int player = gameManager.SelectPosition(2, 2);
            Image img = new Image();
            img.Source = imageList[player];
            btnRow2Col2.Content = img;
        }
    }
}
