using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5.Models;

namespace Assignment_5.Controllers
{
    public static class ScoreManager
    {
        private static readonly IRepository<Score> scoreRepo = new CSVScoreRepository();

        public static IEnumerable<Score> GetAllScores()
        {
            return scoreRepo.GetValues();
        }

        public static IEnumerable<Score> GetTop10Scores()
        {
            var top10values =
                from score in scoreRepo.GetValues()
                orderby score.Value descending
                select score;
            return top10values.Take(10);
        }

        public static void AddScore(Score score)
        {
            scoreRepo.Add(score);
        }
    }
}
