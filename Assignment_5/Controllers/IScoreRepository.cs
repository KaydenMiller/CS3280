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
        // Read
        Score GetScore(int index);
        IEnumerable<Score> GetScores();
        // Update
        void UpdateScore(int index, Score updatedScore);
        void UpdateScores(IEnumerable<Score> updatedScores);
        // Delete
        void Delete(int index);
    }
}
