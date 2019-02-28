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

            List<Slide> slides = new List<Slide>(input.Photos.Count);
            List<Slide> allSlides = CalcAllSlides(input.Photos);

            slides.Add(allSlides[0]);
            slides.Add(allSlides[1]);
            var leftPhotos = allSlides.Skip(2).ToList();
            while (leftPhotos.Count != 0)
            {
                var lastSlide = slides[slides.Count - 1];
                int max = -1;
                Slide maxphoto = null;
                foreach (var item in leftPhotos)
                {
                    int curr = CalcScore(lastSlide, item);
                    if (curr > max)
                    {
                        max = curr;
                        maxphoto = item;
                    }
                }

                leftPhotos.Remove(maxphoto);
                slides.Add(maxphoto);
            }

            return new ProblemOutput() { Slideshow = slides };
        }

        private List<Slide> CalcAllSlides(List<Photo> photos)
        {
            List<Slide> slides = new List<Slide>();
            var groups = photos.GroupBy(_ => _.Direction);
            var horizontals = groups.FirstOrDefault(_ => _.Key == Directions.Horizontal);

            if (horizontals != null)
            {
                foreach (var item in horizontals)
                {
                    var slide = new Slide();
                    slide.AddPhoto(item);
                    slides.Add(slide);
                }
            }

            var verticals = groups.FirstOrDefault(_ => _.Key == Directions.Vertical).ToList();
            if (verticals != null)
            {
                for (int i = 0; i < verticals.Count; i += 2)
                {
                    var slide = new Slide();
                    slide.AddPhoto(verticals[i]);
                    slide.AddPhoto(verticals[i + 1]);
                    slides.Add(slide);
                }
            }
            return slides;
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

        private int CalcScore(Slide first, Slide second)
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
