using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5.Models;

namespace Assignment_5.Controllers
{
    public enum GameType { Addition, Subtraction, Multiplication, Division }

    public struct RoundInfo
    {
        public int FirstOperand { get; set; }
        public int SecondOperand { get; set; }
        public int Answer { get; set; }
        public string Operator { get; set; }
    }

    public class Game
    {
        const int TOTAL_ROUNDS = 10;
        const int DIFFICULTY_MAX = 10;
        const int DIFFICULTY_MIN = 0;

        public int CurrentRound { get; private set; }
        public GameType CurrentGameType { get; private set; }
        public int RoundsCorrect { get; private set; }
        public bool GameOver { get; private set; }

        private DateTime startTime, endTime;
        private RoundInfo[] rounds = new RoundInfo[TOTAL_ROUNDS];
        private User currentUser;

        private delegate RoundInfo MakeRoundFunction(Random rand);
        private class MakeRoundArgs
        {
            public Random rand;

            public MakeRoundArgs(Random rand)
            {
                this.rand = rand;
            }
        }

        public Game(GameType levelType)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            GameOver = false;

            currentUser = UserManager.GetCurrentUser();

            switch (levelType)
            {
                case GameType.Addition:
                    CurrentGameType = GameType.Addition;
                    rounds = MakeRounds(MakeAdditionRound, new MakeRoundArgs(rand));
                    break;
                case GameType.Subtraction:
                    CurrentGameType = GameType.Subtraction;
                    rounds = MakeRounds(MakeSubtractionRound, new MakeRoundArgs(rand));
                    break;
                case GameType.Multiplication:
                    CurrentGameType = GameType.Multiplication;
                    rounds = MakeRounds(MakeMultiplicationRound, new MakeRoundArgs(rand));
                    break;
                case GameType.Division:
                    CurrentGameType = GameType.Division;
                    rounds = MakeRounds(MakeDivisionRound, new MakeRoundArgs(rand));
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
            GameOver = true;
            endTime = DateTime.Now;
            ScoreManager.AddScore(new Score
            {
                Username = currentUser.Username,
                Value = ((int)Math.Pow(RoundsCorrect, 3) / (int)Math.Floor(Math.Sqrt(GetElapsedTime().Seconds)))
            });
        }

        /// <summary>
        /// This function will return the elasped time of the current game.
        /// If the game is not over it is the time elapsed so far, if it is over
        /// then it is the total elasped time for that game.
        /// </summary>
        /// <returns>Seconds Elapsed</returns>
        public TimeSpan GetElapsedTime()
        {
            if (!GameOver)
            {
                return DateTime.Now.Subtract(startTime);
            }
            else
            {
                return endTime.Subtract(startTime);
            }
        }

        public void NextRound()
        {
            if (CurrentRound + 1 < TOTAL_ROUNDS)
                CurrentRound++;
            else
                EndGame();
        }

        public bool ValidateUserAnswer(int answer)
        {
            if (answer == rounds[CurrentRound].Answer)
            {
                RoundsCorrect++;
                return true;
            }
            return false;
        }

        public RoundInfo GetCurrentRoundInfo()
        {
            return rounds[CurrentRound];
        }

        private RoundInfo[] MakeRounds(MakeRoundFunction makeRoundFunction, MakeRoundArgs args)
        {
            RoundInfo[] rounds = new RoundInfo[TOTAL_ROUNDS];
            for (int i = 0; i < TOTAL_ROUNDS; i++)
            {
                rounds[i] = makeRoundFunction(args.rand);
            }
            return rounds;
        }

        private RoundInfo MakeAdditionRound(Random rand)
        {
            RoundInfo round = new RoundInfo();

            round.FirstOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.SecondOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.Answer = round.FirstOperand + round.SecondOperand;
            round.Operator = "+";

            return round;
        }

        private RoundInfo MakeSubtractionRound(Random rand)
        {
            RoundInfo round = new RoundInfo();
            bool validFlag = false;

            do
            {
                round.FirstOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
                round.SecondOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
                if (round.FirstOperand >= round.SecondOperand)
                    validFlag = true;
            } while (!validFlag);

            round.Answer = round.FirstOperand - round.SecondOperand;
            round.Operator = "-";

            return round;
        }

        private RoundInfo MakeMultiplicationRound(Random rand)
        {
            RoundInfo round = new RoundInfo();

            round.FirstOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.SecondOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.Answer = round.FirstOperand * round.SecondOperand;
            round.Operator = "*";

            return round;
        }

        private RoundInfo MakeDivisionRound(Random rand)
        {
            RoundInfo round = new RoundInfo();
            bool validFlag = false;

            do
            {
                round.FirstOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
                round.SecondOperand = rand.Next(DIFFICULTY_MIN + 1, DIFFICULTY_MAX + 1);
                if (round.FirstOperand % round.SecondOperand == 0)
                    validFlag = true;
            } while (!validFlag);

            round.Answer = round.FirstOperand / round.SecondOperand;
            round.Operator = "/";

            return round;
        }
    }
}
