namespace Assignment_5.Controllers
{
    public class GameManager
    {
        public Game CreateGame(GameType gameType)
        {
            if (UserManager.GetCurrentUser() != null)
                return new Game(gameType);
            else
                throw new Assignment_5.Exceptions.UserNotAuthenticatedException();
        }
    }
}
