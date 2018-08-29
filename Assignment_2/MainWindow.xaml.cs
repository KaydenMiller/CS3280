using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int DICE_SIDES = 6;

        public VirtualDie D6 = new VirtualDie(DICE_SIDES);
        private BindingList<UserData> userData = new BindingList<UserData>();

        private BitmapImage[] diceImages = new BitmapImage[6];

        private int timesPlayed = 0;
        private int timesCorrect = 0;
        private int timesIncorrect = 0;

        public BindingList<UserData> UserData
        {
            get { return this.userData; }
            set { this.userData = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < DICE_SIDES; i++)
            {
                UserData.Add(new UserData());
                UserData[i].Face = i + 1;
            }

            diceImages[0] = new BitmapImage(new Uri(@"Resources/Dice_1.png", UriKind.RelativeOrAbsolute));
            diceImages[1] = new BitmapImage(new Uri(@"Resources/Dice_2.png", UriKind.RelativeOrAbsolute));
            diceImages[2] = new BitmapImage(new Uri(@"Resources/Dice_3.png", UriKind.RelativeOrAbsolute));
            diceImages[3] = new BitmapImage(new Uri(@"Resources/Dice_4.png", UriKind.RelativeOrAbsolute));
            diceImages[4] = new BitmapImage(new Uri(@"Resources/Dice_5.png", UriKind.RelativeOrAbsolute));
            diceImages[5] = new BitmapImage(new Uri(@"Resources/Dice_6.png", UriKind.RelativeOrAbsolute));

            DataContext = this;
        }
        
        private void RollDiceIcon(int endOn)
        {
            Random rand = new Random();
            endOn -= 1;

            for (int i = 0; i < rand.Next(1, 10); i++)
            {
                imgDice.Source = diceImages[rand.Next(0, 6)];
                imgDice.InvalidateVisual();
                Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { }));

                // System.Threading.Thread.Sleep causes main thread to sleep so the thread will not update the UI
                System.Threading.Thread.Sleep(100);
            }

            imgDice.Source = diceImages[endOn];

            
        }

        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            int sideRolled = 0;
            int sideGuessed = 0;

            if (int.TryParse(txtGuess.Text, out sideGuessed))
            {
                // The value given by the user was valid
                ++timesPlayed;
                sideRolled = D6.Roll();

                UserData[sideRolled - 1].Frequency++;
                UserData[sideGuessed - 1].TimesGuessed++;

                if (sideGuessed == sideRolled)
                    timesCorrect++;
                else
                    timesIncorrect++;

                txtTimesPlayed.Text = timesPlayed.ToString();
                txtTimesCorrect.Text = timesCorrect.ToString();
                txtTimesIncorrect.Text = timesIncorrect.ToString();

                RollDiceIcon(sideRolled);
            }
            else
            {
                // The parse did not succeed alert the user
                MessageBox.Show("Please enter a valid number (1-6) into the textbox!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            D6.Reset();
            UserData.Clear();
            for (int i = 0; i < DICE_SIDES; i++)
            {
                UserData.Add(new UserData());
                UserData[i].Face = i + 1;
            }
            timesPlayed = 0;
            timesCorrect = 0;
            timesIncorrect = 0;

            txtTimesPlayed.Text = timesPlayed.ToString();
            txtTimesCorrect.Text = timesCorrect.ToString();
            txtTimesIncorrect.Text = timesIncorrect.ToString();
        }
    }
}
