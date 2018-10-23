using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5.Models;
using Assignment_5.Utilities;

namespace Assignment_5.Controllers
{
    /// <summary>
    /// This class manages the users
    /// </summary>
    public static class UserManager
    {
        private static User currentUser = null;
        private readonly static IRepository<string, User> userRepo = new CSVUserRepository();

        /// <summary>
        /// Connect to the user Repo and attempt to login the user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public static OperationResult LoginUser(string username, int age)
        {
            OperationResult operationResult = new OperationResult();
            username = username.ToUpper();

            if (GetUsersFromRepo(username) != Enumerable.Empty<User>())
            {
                List<User> users = GetUsersFromRepo(username).ToList();
                currentUser = users[0];
                if (currentUser.Age != age)
                {
                    // Update the user file
                    UpdateUser(new User() { Username = username, Age = age });
                }
            }
            else
            {
                // No user in file, create one
                userRepo.Add(new User() { Username = username, Age = age });
                currentUser = GetUsersFromRepo(username).ToList()[0];
            }

            if (currentUser == null)
            {
                operationResult.Status = OperationStatus.Falure;
                operationResult.AddMessage("The current user could not be set");
            }

            return operationResult;
        }

        /// <summary>
        /// Update a users values
        /// </summary>
        /// <param name="user"></param>
        private static void UpdateUser(User user)
        {
            userRepo.UpdateValue(user.Username, user);
        }

        /// <summary>
        /// Add a user to the repo
        /// </summary>
        /// <param name="user"></param>
        private static void AddUserToRepo(User user)
        {
            userRepo.Add(user);
        }

        /// <summary>
        /// Gets all of the users with the passed in username attribute.
        /// There should only be one user passed back. But it may be possible
        /// in a different situation to return multiple.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private static IEnumerable<User> GetUsersFromRepo(string username)
        {
            var query =
                from user in userRepo.GetValues()
                where user.Username == username
                select user;

            if (query.Count() == 0)
                return Enumerable.Empty<User>();

            return query.Take(1);
        }

        /// <summary>
        /// Returns the current user for the application.
        /// </summary>
        /// <returns></returns>
        public static User GetCurrentUser()
        {
            return currentUser;
        }
    }
}
