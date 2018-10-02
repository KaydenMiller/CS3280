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

        public delegate void GameEvent();
        public event GameEvent OnGameReset;

        public GameManager()
        {
            // Set up events
            OnGameReset += ResetGame;
        }

        public void StartNewGame()
        {
            currentRoundManager = new RoundManager();
        }

        private void ResetGame()
        {
            player1Score = 0;
            player2Score = 0;
            ties = 0;
        }
    }
}
