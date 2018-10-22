using Assignment_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5.Controllers
{
    class CSVUserRepository : IRepository<string, User>
    {
        private readonly string path;

        public CSVUserRepository()
        {
            var fileName = "Users.txt";
            path = AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

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

        public User GetValue(string key)
        {
            throw new NotImplementedException();
        }

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

        public void UpdateValue(string key, User updatedValue)
        {
            Delete(key);
            Add(updatedValue);
        }
    }
}
