using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Assignment_5.Models;

namespace Assignment_5.Controllers
{
    /// <summary>
    /// The score CSV repo for storing data about each score
    /// This data is stored in a .txt file with the .exe of the app
    /// </summary>
    public class CSVScoreRepository : IRepository<int, Score>
    {
        private string path;

        /// <summary>
        /// Repo ctor
        /// </summary>
        public CSVScoreRepository()
        {
            var fileName = "Scores.txt";
            path = AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        /// <summary>
        /// Add a score to the repo
        /// </summary>
        /// <param name="value"></param>
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

        /// <summary>
        /// not used
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// not used
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Score GetValue(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all score values from the repo
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// not used
        /// </summary>
        /// <param name="index"></param>
        /// <param name="updatedValue"></param>
        public void UpdateValue(int index, Score updatedValue)
        {
            throw new NotImplementedException();
        }
    }
}
