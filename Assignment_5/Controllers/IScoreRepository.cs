using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Controllers
{
    public interface IScoreRepository
    {
        // Add CRUD operations methods
        // Create
        void Add(Score score);
        void AddScores(IEnumerable<Score> scores);
        // Read
        Score GetScore(int index);
        IEnumerable<Score> GetScores();
        // Update
        void UpdateScores(IEnumerable<Score> scores);
        void UpdateScore(int index, Score score);
        // Delete
        void Delete(int index);
        void DeleteScores();
    }
}
