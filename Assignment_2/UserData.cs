using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class UserData : INotifyPropertyChanged
    {
        private int face { get; set; }
        private int frequency { get; set; }
        private double accuracy { get; set; }
        private int timesGuessed { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // Calculate accuracy as a percentage
        private void CalculateAccuracy()
        {
            if (timesGuessed <= 0)
                return;

            accuracy = ((double)frequency / (double)timesGuessed) * 100.0f;
            accuracy = Math.Round(accuracy, 2);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Accuracy)));
        }

        public int Face
        {
            get { return face; }
            set { face = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Face))); }
        }

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

        public double Accuracy
        {
            get { return accuracy; }
            private set { accuracy = value; }
        }

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
