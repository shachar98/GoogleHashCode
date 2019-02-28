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

            List<Photo> photos = new List<Photo>(input.Photos.Count);
            photos.Add(input.Photos[0]);
            photos.Add(input.Photos[1]);
            var leftPhotos = input.Photos.Skip(2).ToList();
            while (leftPhotos.Count != 0)
            {
                var lastPhoto = photos[photos.Count - 1];
                int max = -1;
                Photo maxphoto = null;
                foreach (var item in leftPhotos)
                {
                    int curr = CalcScore(lastPhoto, item);
                    if (curr > max)
                    {
                        max = curr;
                        maxphoto = item;
                    }
                }
                photos.Add(lastPhoto);
            }

            return new ProblemOutput() { };
        }

        /*
        private void AddPair(List<List<PhotoPair>> allPairsConnections, PhotoPair pairToAdd)
        {
            if (pairToAdd.First.TimesAdded == 2 || pairToAdd.Second.TimesAdded == 2)
                return;
            else if (pairToAdd.First.TimesAdded == 0 && pairToAdd.Second.TimesAdded == 0)
            {
                pairToAdd.First.TimesAdded++;
                pairToAdd.Second.TimesAdded++;
                return;
            }
            else if (pairToAdd.Second.TimesAdded == 1 && pairToAdd.First.TimesAdded == 1)
            {
                var firstList = allPairsConnections.FirstOrDefault(_ => _.Any(__ => __.First.Equals(pairToAdd.First) || __.First.Equals(pairToAdd.Second)));
                var secondList = allPairsConnections.FirstOrDefault(_ => _.Any(__ => __.Second.Equals(pairToAdd.First) || __.Second.Equals(pairToAdd.Second)));
                if (firstList == secondList)
                    return;

                allPairsConnections.Remove(secondList);
                firstList.AddRange(secondList);
                firstList.Add(pairToAdd);
                pairToAdd.First.TimesAdded++;
                pairToAdd.Second.TimesAdded++;
                return;
                // TODO
            }
            else if (pairToAdd.Second.TimesAdded == 1)
            {
                var temp = pairToAdd.First;
                pairToAdd.First = pairToAdd.Second;
                pairToAdd.Second = temp;
            }

            var firstList1 = allPairsConnections.FirstOrDefault(_ => _.Any(__ => __.First.Equals(pairToAdd.First) || __.First.Equals(pairToAdd.Second)));
            firstList1.Add(pairToAdd);
            pairToAdd.First.TimesAdded++;
            pairToAdd.Second.TimesAdded++;
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

    */

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
