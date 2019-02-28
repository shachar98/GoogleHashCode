using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    public class Solver : SolverBase<ProblemInput, ProblemOutput>
    {
        protected override ProblemOutput Solve(ProblemInput input)
        {
            // Sort the input for preformance
            // Split the input for preformance

            SortedDictionary<int, List<PhotoPair>> pairsRank = CreateAllPairs(input);

            List<List<PhotoPair>> allPairsConnections = new List<List<PhotoPair>>();
            while (true)
            {
                var first = pairsRank.First();

                foreach (var item in first.Value)
                {
                    AddPair(allPairsConnections, item);
                }

                pairsRank.Remove(first.Key);
            }

            // Solve the problem
            throw new NotImplementedException();
        }

        private void AddPair(List<List<PhotoPair>> allPairsConnections, PhotoPair pairToAdd)
        {
        }

        private SortedDictionary<int, List<PhotoPair>> CreateAllPairs(ProblemInput input)
        {
            // TODO: Handle Verticals

            SortedDictionary<int, List<PhotoPair>> pairsRank = new SortedDictionary<int, List<PhotoPair>>();
            foreach (var curr in input.Photos)
            {
                foreach (var curr2 in input.Photos)
                {
                    var score = CalcScore(curr, curr2);
                    var photoPair = new PhotoPair() { Second = curr, First = curr2 };
                    if (pairsRank.TryGetValue(score, out List<PhotoPair> currList))
                    {
                        currList.Add(photoPair);
                    }
                    else
                    {
                        pairsRank.Add(score, new List<PhotoPair>() { photoPair });
                    }
                }
            }

            return pairsRank;
        }

        private int CalcScore(Photo first, Photo second)
        {
            int together = first.Tags.Count(_ => second.Tags.Any(__ => __ == _));
            int onlySecond = second.Tags.Count - together;
            int onlyFirst = first.Tags.Count - together;

            return Math.Min(together, Math.Min(onlyFirst, onlySecond));
        }
    }

    public class PhotoPair
    {
        public Photo First { get; set; }
        public Photo Second { get; set; }
    }
}
