using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Controllers
{
    public class FakeRepository : IScoreRepository
    {
        public void Add(Score score)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public Score GetScore(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Score> GetScores()
        {
            var scores = new List<Score>()
            {
                new Score(5, 10),
                new Score(10, 7),
                new Score(15, 8)
            };
            return scores;
        }

        public void UpdateScore(int index, Score updatedScore)
        {
            throw new NotImplementedException();
        }

        public void UpdateScores(IEnumerable<Score> updatedScores)
        {
            throw new NotImplementedException();
        }
    }
}
