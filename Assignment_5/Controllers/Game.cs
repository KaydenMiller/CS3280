using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Controllers
{
    public enum GameType { Addition, Subtraction, Multiplication, Division }

    struct RoundInfo
    {
        public int FirstOperand { get; set; }
        public int SecondOperand { get; set; }
        public int Answer { get; set; }
    }

    class Game
    {
        const int TOTAL_ROUNDS = 10;
        const int DIFFICULTY_MAX = 10;
        const int DIFFICULTY_MIN = 0;

        public int CurrentRound { get; private set; }

        private DateTime startTime, endTime;
        private RoundInfo[] rounds = new RoundInfo[TOTAL_ROUNDS];

        private delegate RoundInfo MakeRoundFunction();

        public Game(GameType levelType)
        {
            switch (levelType)
            {
                case GameType.Addition:
                    rounds = MakeRounds(MakeAdditionRound);
                    break;
                case GameType.Subtraction:
                    rounds = MakeRounds(MakeSubtractionRound);
                    break;
                case GameType.Multiplication:
                    rounds = MakeRounds(MakeMultiplicationRound);
                    break;
                case GameType.Division:
                    rounds = MakeRounds(MakeDivisionRound);
                    break;
            }
        }

        public void StartGame()
        {
            CurrentRound = 0;
            startTime = DateTime.Now;
        }

        public void EndGame()
        {
            endTime = DateTime.Now;
        }

        /// <summary>
        /// This function will return the elasped time of the current game.
        /// If the game is not over it is the time elapsed so far, if it is over
        /// then it is the total elasped time for that game.
        /// </summary>
        /// <returns>Seconds Elapsed</returns>
        public int GetElapsedTime()
        {
            if (endTime != null)
                return endTime.Second - startTime.Second;
            else
                return DateTime.Now.Second - startTime.Second;
        }

        public void NextRound()
        {
            CurrentRound++;
        }

        public RoundInfo GetCurrentRoundInfo()
        {
            return rounds[CurrentRound];
        }

        private RoundInfo[] MakeRounds(MakeRoundFunction makeRoundFunction)
        {
            RoundInfo[] rounds = new RoundInfo[TOTAL_ROUNDS];
            for (int i = 0; i < TOTAL_ROUNDS; i++)
            {
                rounds[i] = makeRoundFunction();
            }
            return rounds;
        }

        private RoundInfo MakeAdditionRound()
        {
            RoundInfo round = new RoundInfo();
            Random rand = new Random();

            round.FirstOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.SecondOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.Answer = round.FirstOperand + round.SecondOperand;

            return round;
        }

        private RoundInfo MakeSubtractionRound()
        {
            RoundInfo round = new RoundInfo();
            Random rand = new Random();
            bool validFlag = false;

            do
            {
                round.FirstOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
                round.SecondOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
                if (round.FirstOperand >= round.SecondOperand)
                    validFlag = true;
            } while (!validFlag);

            round.Answer = round.FirstOperand - round.SecondOperand;

            return round;
        }

        private RoundInfo MakeMultiplicationRound()
        {
            RoundInfo round = new RoundInfo();
            Random rand = new Random();

            round.FirstOperand = rand.Next(DIFFICULTY_MIN * DIFFICULTY_MAX + 1);
            round.SecondOperand = rand.Next(DIFFICULTY_MIN * DIFFICULTY_MAX + 1);
            round.Answer = round.FirstOperand * round.SecondOperand;

            return round;
        }

        private RoundInfo MakeDivisionRound()
        {
            RoundInfo round = new RoundInfo();
            Random rand = new Random();
            bool validFlag = false;

            do
            {
                round.FirstOperand = rand.Next(DIFFICULTY_MIN * DIFFICULTY_MAX + 1);
                round.SecondOperand = rand.Next(DIFFICULTY_MIN + 1 * DIFFICULTY_MAX + 1);
                if (round.FirstOperand % round.SecondOperand == 0)
                    validFlag = true;
            } while (!validFlag);

            round.Answer = round.FirstOperand / round.SecondOperand;

            return round;
        }
    }
}
