using Assignment_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5.Controllers
{
    /// <summary>
    /// CSV Repository class for getting and saving data about the user to a CSV repo
    /// the files are stored with the .exe of the application
    /// </summary>
    class CSVUserRepository : IRepository<string, User>
    {
        private readonly string path;

        /// <summary>
        /// Repo ctor
        /// </summary>
        public CSVUserRepository()
        {
            var fileName = "Users.txt";
            path = AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        /// <summary>
        /// Add a user to the repo
        /// </summary>
        /// <param name="value"></param>
        public void Add(User value)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append | FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    var output = $"{value.Username.ToUpper()},{value.Age}";
                    sw.WriteLine(output);
                }
            }
        }


        /// <summary>
        /// Delete a user from the repo
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            var query = from users in GetValues()
                        where users.Username != key
                        select users;

            // Update the list of users
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate | FileMode.Truncate, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    foreach (User usr in query)
                    {
                        var output = $"{usr.Username.ToUpper()},{usr.Age}";
                        sw.WriteLine(output);
                    }
                }
            }
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public User GetValue(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all of the users within the repo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetValues()
        {
            if (!File.Exists(path))
                return Enumerable.Empty<User>();

            var users = from line in File.ReadAllLines(path)
                        let elems = line.Split(',')
                        select new User
                        {
                            Username = elems[0],
                            Age = int.Parse(elems[1])
                        };

            return users;
        }

        /// <summary>
        /// Update a users information
        /// </summary>
        /// <param name="key"></param>
        /// <param name="updatedValue"></param>
        public void UpdateValue(string key, User updatedValue)
        {
            Delete(key);
            Add(updatedValue);
        }
    }
}
