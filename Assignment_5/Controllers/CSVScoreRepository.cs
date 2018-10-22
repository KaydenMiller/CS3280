using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Assignment_5.Models;

namespace Assignment_5.Controllers
{
    public class CSVScoreRepository : IRepository<int, Score>
    {
        private string path;

        public CSVScoreRepository()
        {
            var fileName = "Scores.txt";
            path = AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        public void Add(Score value)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append | FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    var output = $"{value.Username},{value.Value}";
                    sw.WriteLine(output);
                }
            }
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public Score GetValue(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Score> GetValues()
        {
            var scores = new List<Score>();

            if (File.Exists(path))
            {
                var streamReader = new StreamReader(path);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var elems = line.Split(',');
                    scores.Add(new Score() {
                        Username = elems[0],
                        Value = int.Parse(elems[1])
                    });
                }
                streamReader.Close();
            }
            
            return scores;
        }

        public void UpdateValue(int index, Score updatedValue)
        {
            throw new NotImplementedException();
        }
    }
}
