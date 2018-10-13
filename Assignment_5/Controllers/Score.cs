using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Controllers
{
    public class Score
    {
        public int TimeElapsed { get; set; }
        public int RoundsCompleted { get; set; }
        public int TotalScore { get; private set; }

        public Score(int timeElapsed, int roundsCompleted)
        {
            TimeElapsed = timeElapsed;
            RoundsCompleted = roundsCompleted;
            TotalScore = CalculateScore(timeElapsed, roundsCompleted);
        }

        private int CalculateScore(int timeElapsed, int rounds)
        {
            int output = 0;

            output = (int)Math.Pow(timeElapsed, 3) / (int)Math.Floor(Math.Sqrt(timeElapsed));

            return output;
        }
    }
}
