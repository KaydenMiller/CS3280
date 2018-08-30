using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Timers;

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int DICE_SIDES = 6;

        /// <summary>
        /// Defines a dice with 6 sides.
        /// </summary>
        public VirtualDie D6 = new VirtualDie(DICE_SIDES);
        private BindingList<UserData> userData = new BindingList<UserData>();

        private BitmapImage[] diceImages = new BitmapImage[6];
        private Task rollDiceImage;

        private int timesPlayed = 0;
        private int timesCorrect = 0;
        private int timesIncorrect = 0;

        /// <summary>
        /// This is the public attribute for binding the UserData DTO to the UI.
        /// </summary>
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
        

        // ------ THE FOLLOWING SECTION NEED IMPROVEMENT BY A LOT ----------

        private System.Timers.Timer timer = new System.Timers.Timer(400);
        private int rolledCount = 0, rollsToDo = 0, endOn = 0;
        Dispatcher dispatcherUI;

        /// <summary>
        /// This method will set how many rolls the dice on the screen should make.
        /// It will also tell the program which image to finish on to keep the dice accurate.
        /// The method will attach the ChangeDiceIconRandom() method to the timer.Elapsed Event of the timer.
        /// </summary>
        /// <param name="endOn"></param>
        private void RollDiceIcon(int endOn)
        {
            rollsToDo = 3;
            this.endOn = endOn;
            dispatcherUI = Dispatcher.CurrentDispatcher;

            timer.Elapsed += ChangeDiceIconRandom;

            timer.Start();
        }

        /// <summary>
        /// This method will control how the UI updates the dice image and use a 
        /// thread dispatcher to update on the UI thread from within the timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ChangeDiceIconRandom(object sender, ElapsedEventArgs args)
        {
            Random rand = new Random();

            Console.WriteLine(string.Format("The timer has elapsed, this is its {0}th count.", rolledCount));

            dispatcherUI.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                int randImage = rand.Next(0, 6);
                Console.WriteLine(string.Format("The die rolled a: {0}.", randImage + 1));
                imgDice.Source = diceImages[randImage];
                imgDice.InvalidateVisual();
            }));
            
            rolledCount++;

            if (rolledCount > rollsToDo)
            {
                timer.Elapsed -= ChangeDiceIconRandom;
                rolledCount = 0;
                dispatcherUI.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    imgDice.Source = diceImages[endOn - 1];
                    imgDice.InvalidateVisual();
                }));
            }
        }

        /// <summary>
        /// Will simulate rolling dice and Update the UI with information about the current session.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This will reset the current sessions information allowing the user to start over.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
