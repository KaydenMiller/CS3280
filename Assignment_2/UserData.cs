using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    /// <summary>
    /// This is the UserData DTO that will be updated in order to update the UI with correct information. 
    /// It implements the INotifyPropertyChanged Interface in order to supply update information about 
    /// individual properties within the DTO.
    /// </summary>
    public class UserData : INotifyPropertyChanged
    {
        private int face { get; set; }
        private int frequency { get; set; }
        private double accuracy { get; set; }
        private int timesGuessed { get; set; }

        /// <summary>
        /// An event required for INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This method will calculate and update the accuracy as a percentage. 
        /// It will also act as the Property changed notifier for the Accuracy Property.
        /// </summary>
        private void CalculateAccuracy()
        {
            if (timesGuessed <= 0)
                return;

            accuracy = ((double)frequency / (double)timesGuessed) * 100.0f;
            accuracy = Math.Round(accuracy, 2);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Accuracy)));
        }

        /// <summary>
        /// This is the value for the current face being represented.
        /// </summary>
        public int Face
        {
            get { return face; }
            set { face = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Face))); }
        }

        /// <summary>
        /// This is how often the face was shown to the user.
        /// </summary>
        public int Frequency
        {
            get { return frequency; }
            set
            {
                frequency = value;
                CalculateAccuracy();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Frequency)));
            }
        }

        /// <summary>
        /// The current accuracy based on how many times the face has been shown divided by how many times the user has selected said face.
        /// </summary>
        public double Accuracy
        {
            get { return accuracy; }
            private set { accuracy = value; }
        }

        /// <summary>
        /// How many times has the user chosen this side as the side that will be next.
        /// </summary>
        public int TimesGuessed
        {
            get { return timesGuessed; }
            set
            {
                timesGuessed = value;
                CalculateAccuracy();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimesGuessed)));
            }
        }
    }
}
