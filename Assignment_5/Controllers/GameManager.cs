namespace Assignment_5.Controllers
{
    /// <summary>
    /// The class to orcistrate the game and determine if the user is logged in or not.
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Will create a game of the passed in type.
        /// So long as the user is currently logged into the app.
        /// </summary>
        /// <param name="gameType"></param>
        /// <returns></returns>
        public Game CreateGame(GameType gameType)
        {
            if (UserManager.GetCurrentUser() != null)
                return new Game(gameType);
            else
                throw new Assignment_5.Exceptions.UserNotAuthenticatedException();
        }
    }
}
