using Assignment_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5.Controllers
{
    class CSVUserRepository : IRepository<User>
    {
        private string path;

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
                    var output = $"{value.Username},{value.Age}";
                    sw.WriteLine(output);
                }
            }
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public User GetValue(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetValues()
        {
            var users = new List<User>();

            if (File.Exists(path))
            {
                var streamReader = new StreamReader(path);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var elems = line.Split(',');
                    var score = new User()
                    {
                        Username = elems[0],
                        Age = int.Parse(elems[1])
                    };
                }
                streamReader.Close();
            }

            return users;
        }

        public void UpdateValue(int index, User updatedValue)
        {
            throw new NotImplementedException();
        }
    }
}
