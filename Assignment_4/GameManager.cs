using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class GameManager
    {
        /// <summary>
        /// Player1's score
        /// </summary>
        public uint player1Score = 0;
        /// <summary>
        /// Player2's score
        /// </summary>
        public uint player2Score = 0;
        /// <summary>
        /// How many ties
        /// </summary>
        public uint ties = 0;

        /// <summary>
        /// The current round manager
        /// </summary>
        private RoundManager currentRoundManager;

        /// <summary>
        /// delegate to control the games events
        /// </summary>
        public delegate void GeneralGameEventHandler();
        /// <summary>
        /// OnGameOver event
        /// </summary>
        public event GeneralGameEventHandler OnGameOver;
        /// <summary>
        /// OnNextRound event
        /// </summary>
        public event GeneralGameEventHandler OnNextRound;

        /// <summary>
        /// boolean representing if the game is over
        /// </summary>
        public bool isGameOver = false;
        /// <summary>
        /// who was the last player to win
        /// </summary>
        public string lastWinningPlayer = "NONE";

        /// <summary>
        /// what is the roundId value
        /// </summary>
        private int roundId = 0;

        /// <summary>
        /// This will start a new game and clear the old round manager.
        /// </summary>
        public void StartNewGame()
        {
            if (currentRoundManager != null)
            {
                currentRoundManager.Close();
                currentRoundManager = null;
            }
                

            currentRoundManager = new RoundManager(this, roundId++);
            isGameOver = false;
        }

        /// <summary>
        /// This will reset the current scores of the players.
        /// </summary>
        private void ResetGame()
        {
            player1Score = 0;
            player2Score = 0;
            ties = 0;
        }

        /// <summary>
        /// This will send the Row Col data to the Round manager and request the current playerID
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int SelectPosition(int x, int y)
        {
            if (!isGameOver)
            {
                int player = currentRoundManager.SelectPosition(x, y);
                InvokeOnNextRound();
                return player;
            }
            else
            {
                return -1;
            }
        }

        #region EventHandlers
        /// <summary>
        /// This is the function to call the OnGameOver event
        /// </summary>
        /// <param name="winnerID"></param>
        public void InvokOnGameOver(int winnerID)
        {
            // WinnerID (0 = player1; 1 = player2; 2 = tie)
            switch (winnerID)
            {
                case 0:
                    lastWinningPlayer = "1";
                    player1Score++;
                    break;
                case 1:
                    lastWinningPlayer = "2";
                    player2Score++;
                    break;
                case 2:
                    lastWinningPlayer = "TIE";
                    ties++;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            isGameOver = true;

            OnGameOver?.Invoke();
        }

        /// <summary>
        /// This is the funciton to call the OnNextRound event
        /// </summary>
        public void InvokeOnNextRound()
        {
            OnNextRound?.Invoke();
        }
        #endregion
    }
}
