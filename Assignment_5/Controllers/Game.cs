using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5.Models;

namespace Assignment_5.Controllers
{
    public enum GameType { Addition, Subtraction, Multiplication, Division }

    /// <summary>
    /// Basic round information
    /// </summary>
    public struct RoundInfo
    {
        public int FirstOperand { get; set; }
        public int SecondOperand { get; set; }
        public int Answer { get; set; }
        public string Operator { get; set; }
    }

    /// <summary>
    /// The game
    /// </summary>
    public class Game
    {
        const int TOTAL_ROUNDS = 10;
        const int DIFFICULTY_MAX = 10;
        const int DIFFICULTY_MIN = 0;

        /// <summary>
        /// The games current round
        /// </summary>
        public int CurrentRound { get; private set; }
        /// <summary>
        /// The current games type
        /// </summary>
        public GameType CurrentGameType { get; private set; }
        /// <summary>
        /// Rounds has the user completed correctly
        /// </summary>
        public int RoundsCorrect { get; private set; }
        /// <summary>
        /// Stores the game over state
        /// </summary>
        public bool GameOver { get; private set; }

        private DateTime startTime, endTime;
        private RoundInfo[] rounds = new RoundInfo[TOTAL_ROUNDS];
        private User currentUser;

        private delegate RoundInfo MakeRoundFunction(Random rand);
        /// <summary>
        /// Arguments class for making a round.
        /// </summary>
        // This class is prob over kill for what i needed
        private class MakeRoundArgs
        {
            /// <summary>
            /// random value object
            /// </summary>
            public Random rand;

            /// <summary>
            /// Round Arg ctor
            /// </summary>
            /// <param name="rand"></param>
            public MakeRoundArgs(Random rand)
            {
                this.rand = rand;
            }
        }

        /// <summary>
        /// Game ctor
        /// </summary>
        /// <param name="levelType"></param>
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

        /// <summary>
        /// Starts the current game and time
        /// </summary>
        public void StartGame()
        {
            CurrentRound = 0;
            startTime = DateTime.Now;
        }

        /// <summary>
        /// Ends the game and stops the game timer
        /// </summary>
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

        /// <summary>
        /// Moves the game to the next round
        /// </summary>
        public void NextRound()
        {
            if (CurrentRound + 1 < TOTAL_ROUNDS)
                CurrentRound++;
            else
                EndGame();
        }

        /// <summary>
        /// Simple test to validate the users answer
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool ValidateUserAnswer(int answer)
        {
            if (answer == rounds[CurrentRound].Answer)
            {
                RoundsCorrect++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the current round info struct
        /// </summary>
        /// <returns></returns>
        public RoundInfo GetCurrentRoundInfo()
        {
            return rounds[CurrentRound];
        }

        /// <summary>
        /// Builds a new round
        /// </summary>
        /// <param name="makeRoundFunction"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private RoundInfo[] MakeRounds(MakeRoundFunction makeRoundFunction, MakeRoundArgs args)
        {
            RoundInfo[] rounds = new RoundInfo[TOTAL_ROUNDS];
            for (int i = 0; i < TOTAL_ROUNDS; i++)
            {
                rounds[i] = makeRoundFunction(args.rand);
            }
            return rounds;
        }

        /// <summary>
        /// Builds a round for the addition game
        /// </summary>
        /// <param name="rand"></param>
        /// <returns></returns>
        private RoundInfo MakeAdditionRound(Random rand)
        {
            RoundInfo round = new RoundInfo();

            round.FirstOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.SecondOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.Answer = round.FirstOperand + round.SecondOperand;
            round.Operator = "+";

            return round;
        }

        /// <summary>
        /// Builds a round for the subtraction game
        /// </summary>
        /// <param name="rand"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Builds a round for the multiplication game
        /// </summary>
        /// <param name="rand"></param>
        /// <returns></returns>
        private RoundInfo MakeMultiplicationRound(Random rand)
        {
            RoundInfo round = new RoundInfo();

            round.FirstOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.SecondOperand = rand.Next(DIFFICULTY_MIN, DIFFICULTY_MAX + 1);
            round.Answer = round.FirstOperand * round.SecondOperand;
            round.Operator = "*";

            return round;
        }

        /// <summary>
        /// Builds a round for the division game ;)
        /// </summary>
        /// <param name="rand"></param>
        /// <returns></returns>
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
