using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class GameManager
    {
        public uint player1Score = 0;
        public uint player2Score = 0;
        public uint ties = 0;

        private RoundManager currentRoundManager;

        public delegate void GeneralGameEventHandler();
        public event GeneralGameEventHandler OnGameOver;
        public event GeneralGameEventHandler OnNextRound;

        public bool isGameOver = false;
        public string lastWinningPlayer = "NONE";

        private int roundId = 0;

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

        private void ResetGame()
        {
            player1Score = 0;
            player2Score = 0;
            ties = 0;
        }

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

        public void InvokeOnNextRound()
        {
            OnNextRound?.Invoke();
        }
        #endregion
    }
}
