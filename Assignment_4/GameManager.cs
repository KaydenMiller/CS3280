using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class GameManager
    {
        private uint player1Score = 0;
        private uint player2Score = 0;
        private uint ties = 0;

        private RoundManager currentRoundManager;

        public delegate void GeneralGameEventHandler();
        public event GeneralGameEventHandler OnGameOver;
        public event GeneralGameEventHandler OnNextRound;

        public void StartNewGame()
        {
            currentRoundManager = new RoundManager(this);
        }

        private void ResetGame()
        {
            player1Score = 0;
            player2Score = 0;
            ties = 0;
        }

        public int SelectPosition(int x, int y)
        {
            int player = currentRoundManager.SelectPosition(x, y);
            InvokeOnNextRound();
            return player;
        }

        #region EventHandlers
        public void InvokOnGameOver(int winnerID)
        {
            // WinnerID (0 = player1; 1 = player2; 2 = tie)
            switch (winnerID)
            {
                case 0:
                    player1Score++;
                    break;
                case 1:
                    player2Score++;
                    break;
                case 2:
                    ties++;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            OnGameOver?.Invoke();
        }

        public void InvokeOnNextRound()
        {
            OnNextRound?.Invoke();
        }
        #endregion
    }
}
