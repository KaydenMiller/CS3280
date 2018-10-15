using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5.Models;

namespace Assignment_5.Controllers
{
    public static class UserManager
    {
        private static User currentUser = null;
        private readonly static IRepository<User> userRepo = new CSVUserRepository();

        public static void LoginUser(string username, int age)
        {
            if (GetUserFromRepo(username) != null)
            {
                List<User> users = GetUserFromRepo(username).ToList();
                currentUser = users[0];
            }
            else
            {
                // No user in file, create one
                userRepo.Add(new User() { Username = username, Age = age });
            }
        }

        private static IEnumerable<User> GetUserFromRepo(string username)
        {
            var query =
                from user in userRepo.GetValues()
                where user.Username == username
                select user;

            if (query.Count() == 0)
                return null;

            return query.Take(1);
        }

        public static User GetCurrentUser()
        {
            return currentUser;
        }
    }
}
