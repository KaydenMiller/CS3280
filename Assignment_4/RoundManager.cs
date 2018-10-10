using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class RoundManager
    {
        private GameManager gameManager;

        private Player[,] gameBoard = new Player[3, 3];
        private int currentRound = 1;
        
        public enum Player { Player1, Player2, None }
        public Player currentPlayer = Player.Player1;


        private int roundManagerId = -1;

        public RoundManager(GameManager gameManager, int roundManagerId)
        {
            this.gameManager = gameManager;
            this.roundManagerId = roundManagerId;

            gameManager.OnNextRound += NextRound;
            gameManager.OnNextRound += CheckForEndConditions;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    gameBoard[x, y] = Player.None;
                }
            }
        }

        public void Close()
        {
            gameManager.OnNextRound -= NextRound;
            gameManager.OnNextRound -= CheckForEndConditions;
            gameManager = null;
        }

        public int SelectPosition(int x, int y)
        {
            SetCurrentPlayer();
            if (gameBoard[x, y] == Player.None)
            {
                gameBoard[x, y] = currentPlayer;
                return (int)currentPlayer;
            }
            else
            {
                --currentRound;
                return (int)gameBoard[x, y];
            }
        }

        private void NextRound()
        {
            currentRound++;   
        }

        private void SetCurrentPlayer()
        {
            switch(currentRound % 2)
            {
                case 1:
                    currentPlayer = Player.Player1;
                    break;
                case 0:
                    currentPlayer = Player.Player2;
                    break;
            }
        }

        private void CheckForEndConditions()
        {
            Player player = CheckIfPlayerWon();
            bool tieFlag = CheckForTie();

            
            if (player == Player.Player1)
            {
                gameManager.InvokOnGameOver((int)Player.Player1);
            }
            else if (player == Player.Player2)
            {
                gameManager.InvokOnGameOver((int)Player.Player2);
            }
            else
            {
                if (tieFlag)
                {
                    gameManager.InvokOnGameOver((int)Player.None);
                }
            }
        }
#region VictoryConditionChecking
        private bool CheckForTie()
        {
            int totalFilledTiles = 0;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (gameBoard[x, y] == Player.Player1 ||
                        gameBoard[x, y] == Player.Player2)
                        totalFilledTiles++;
                }
            }

            if (totalFilledTiles == 9)
                return true;
            else
                return false;
        }

        private Player CheckIfPlayerWon()
        {
            // Check for player to have won
            Player[] playerWinArray = { Player.None, Player.None, Player.None };
            
            playerWinArray[0] = CheckDiagonals();
            playerWinArray[1] = CheckHorizontal();
            playerWinArray[2] = CheckVertical();

            for (int i = 0; i < 3; i++)
            {
                if (playerWinArray[i] != Player.None)
                {
                    return playerWinArray[i];
                }
            }

            return Player.None;
        }

        private Player CheckDiagonals()
        {
            if (gameBoard[0,0] != Player.None ||
                gameBoard[2,0] != Player.None ||
                gameBoard[0,2] != Player.None ||
                gameBoard[2,2] != Player.None)
            {
                if (gameBoard[0,0] == Player.Player1 &&
                    gameBoard[1,1] == Player.Player1 &&
                    gameBoard[2,2] == Player.Player1 ||
                    gameBoard[2,0] == Player.Player1 &&
                    gameBoard[1,1] == Player.Player1 &&
                    gameBoard[0,2] == Player.Player1)
                {
                    return Player.Player1;
                }
                
                if (gameBoard[0, 0] == Player.Player2 &&
                    gameBoard[1, 1] == Player.Player2 &&
                    gameBoard[2, 2] == Player.Player2 ||
                    gameBoard[2, 0] == Player.Player2 &&
                    gameBoard[1, 1] == Player.Player2 &&
                    gameBoard[0, 2] == Player.Player2)
                {
                    return Player.Player2;
                }
            }

            return Player.None;
        }

        private Player CheckHorizontal()
        {
            for (int y = 0; y < 3; y++)
            {
                int player1InRow = 0;
                int player2InRow = 0;

                for (int x = 0; x < 3; x++)
                {
                    if (gameBoard[x, y] == Player.Player1)
                        player1InRow++;
                    if (gameBoard[x, y] == Player.Player2)
                        player2InRow++;
                }

                if (player1InRow == 3)
                    return Player.Player1;
                else if (player2InRow == 3)
                    return Player.Player2;
            }

            return Player.None;
        }

        private Player CheckVertical()
        {
            for (int x = 0; x < 3; x++)
            {
                int player1InCol = 0;
                int player2InCol = 0;

                for (int y = 0; y < 3; y++)
                {
                    if (gameBoard[x, y] == Player.Player1)
                        player1InCol++;
                    if (gameBoard[x, y] == Player.Player2)
                        player2InCol++;
                }

                if (player1InCol == 3)
                    return Player.Player1;
                else if (player2InCol == 3)
                    return Player.Player2;
            }

            return Player.None;
        }
#endregion
    }
}
