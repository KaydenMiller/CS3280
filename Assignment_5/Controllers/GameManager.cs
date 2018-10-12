namespace Assignment_5.Controllers
{
    public class GameManager
    {
        public Game CreateGame(GameType gameType)
        {
            return new Game(gameType);
        }
    }
}
