using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5.Models;

namespace Assignment_5.Controllers
{
    class GameManager
    {
        Game currentGame = null;

        public void CreateGame(GameType gameType)
        {
            currentGame = new Game(gameType);
        }
    }
}
