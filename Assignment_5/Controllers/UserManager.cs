using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5.Models;
using Assignment_5.Utilities;

namespace Assignment_5.Controllers
{
    public static class UserManager
    {
        private static User currentUser = null;
        private readonly static IRepository<User> userRepo = new CSVUserRepository();

        public static OperationResult LoginUser(string username, int age)
        {
            OperationResult operationResult = new OperationResult();
            username = username.ToUpper();

            if (GetUserFromRepo(username) != Enumerable.Empty<User>())
            {
                List<User> users = GetUserFromRepo(username).ToList();
                currentUser = users[0];
            }
            else
            {
                // No user in file, create one
                userRepo.Add(new User() { Username = username, Age = age });
                currentUser = GetUserFromRepo(username).ToList()[0];
            }

            if (currentUser == null)
            {
                operationResult.Status = OperationStatus.Falure;
                operationResult.AddMessage("The current user could not be set");
            }

            return operationResult;
        }

        private static void AddUserToRepo(User user)
        {
            userRepo.Add(user);
        }

        private static IEnumerable<User> GetUserFromRepo(string username)
        {
            var query =
                from user in userRepo.GetValues()
                where user.Username == username
                select user;

            if (query.Count() == 0)
                return Enumerable.Empty<User>();

            return query.Take(1);
        }

        public static User GetCurrentUser()
        {
            return currentUser;
        }
    }
}
