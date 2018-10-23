using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5.Models;

namespace Assignment_5.Controllers
{
    /// <summary>
    /// This class manages scores
    /// </summary>
    public static class ScoreManager
    {
        private static readonly IRepository<int, Score> scoreRepo = new CSVScoreRepository();

        /// <summary>
        /// Returns all score values that are within the score repo
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Score> GetAllScores()
        {
            return scoreRepo.GetValues();
        }

        /// <summary>
        /// Get the top 10 scores from the repo
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Score> GetTop10Scores()
        {
            var top10values =
                from score in scoreRepo.GetValues()
                orderby score.Value descending
                select score;
            return top10values.Take(10);
        }

        /// <summary>
        /// Add a score to the repo
        /// </summary>
        /// <param name="score"></param>
        public static void AddScore(Score score)
        {
            scoreRepo.Add(score);
        }

        /// <summary>
        /// What was the last score entered.
        /// This is the score of the last game played.
        /// </summary>
        /// <returns></returns>
        public static Score GetLastScore()
        {
            var query =
                from score in scoreRepo.GetValues()
                select score;

            var scores = query.ToList();
            scores.Reverse();

            return scores.ElementAt(0);
        }
    }
}
