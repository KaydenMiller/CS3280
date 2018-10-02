using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class RoundManager
    {
        private int[,] gameBoard = new int[3, 3];
        private int currentRound = 0;
        
        private enum Player { Player1, Player2 }
        private Player currentPlayer = Player.Player1;

        private void NextRound()
        {
            ++currentRound;

            switch(currentPlayer)
            {
                case Player.Player1:
                    currentPlayer = Player.Player2;
                    break;
                case Player.Player2:
                    currentPlayer = Player.Player1;
                    break;
            }
        }
    }
}
