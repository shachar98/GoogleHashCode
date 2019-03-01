using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    public class Solver : SolverBase<ProblemInput, ProblemOutput>
    {
        private bool[] m_Tags;
        protected override ProblemOutput Solve(ProblemInput input)
        {
            // Sort the input for preformance
            // Split the input for preformance

            m_Tags = new bool[input.NumOfTags];

            List<Slide> slides = new List<Slide>(input.Photos.Count);
            List<Slide> allSlides = CalcAllSlides(input.Photos).OrderBy(_ => _.Tags.Count).ToList();
            if (allSlides.Count < 2)
                return new ProblemOutput() { Slideshow = allSlides};

            slides.Add(allSlides[0]);
            var leftPhotos = new HashSet<Slide>(allSlides.Skip(1));
            while (leftPhotos.Count != 0)
            {
                if (leftPhotos.Count % 1000 == 0)
                    Console.WriteLine(leftPhotos.Count + ", " + this.ProblemName + ", solve, " + DateTime.Now);
                var lastSlide = slides[slides.Count - 1];

                foreach (var item in lastSlide.Tags)
                {
                    m_Tags[item] = true;
                }

                Slide maxphoto = GetMaxPhoto(leftPhotos, lastSlide);

                foreach (var item in lastSlide.Tags)
                {
                    m_Tags[item] = false;
                }

                leftPhotos.Remove(maxphoto);
                slides.Add(maxphoto);
            }

            return new ProblemOutput() { Slideshow = slides };
        }

        private Slide GetMaxPhoto(ICollection<Slide> leftPhotos, Slide lastSlide)
        {
            Slide maxphoto = null;
            double max = -10000;

            Parallel.ForEach(leftPhotos, new ParallelOptions() { MaxDegreeOfParallelism = 5 },  (item, state) =>
            {
                int curr = CalcScore(lastSlide, item);

                if (item.Tags.Count == lastSlide.Tags.Count && curr == item.Tags.Count / 2)
                {
                    state.Break();
                    maxphoto = item;
                }

                curr = curr * 100000 - item.Tags.Count;

                if (curr > max)
                {
                    max = curr;
                    maxphoto = item;
                }
            });

            return maxphoto;
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

            var verticals = groups.FirstOrDefault(_ => _.Key == Directions.Vertical)?.ToList();
            if (verticals != null)
            {
                SplitVerticals(slides, verticals);
            }
            return slides;
        }

        private void SplitVerticals(List<Slide> slides, List<Photo> verticals)
        {
            HashSet<Photo> remainigVerticals = new HashSet<Photo>(verticals);
            foreach (var item in verticals.OrderByDescending(_ => _.Tags.Count).ToList())
            {
                if (!remainigVerticals.Contains(item))
                    continue;

                if (remainigVerticals.Count % 1000 == 0 || remainigVerticals.Count % 1000 == 1)
                    Console.WriteLine(remainigVerticals.Count + ", " + this.ProblemName + ", verticals, " + DateTime.Now);

                remainigVerticals.Remove(item);
                
                var minTagsInBoth = 100000;
                Photo chosenPhoto = null;
                foreach (var item3 in item.Tags)
                {
                    m_Tags[item3] = true;
                }

                Parallel.ForEach(remainigVerticals, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, item2 =>
                {
                    var both = item2.Tags.Count(_ => m_Tags[_]);

                    if (minTagsInBoth > both)
                    {
                        minTagsInBoth = both;
                        chosenPhoto = item2;
                    }
                    else if (minTagsInBoth == both && item2.Tags.Count > chosenPhoto.Tags.Count)
                    {
                        chosenPhoto = item2;
                    }
                });

                foreach (var item3 in item.Tags)
                {
                    m_Tags[item3] = false;
                }

                remainigVerticals.Remove(chosenPhoto);

                var slide = new Slide();
                if (chosenPhoto != null)
                {
                    slide.AddPhoto(item);
                    slide.AddPhoto(chosenPhoto);
                    slides.Add(slide);
                }
            }
        }
       
        

        private int CalcScore(Slide first, Slide second)
        {
            var together = second.Tags.Count(_ => m_Tags[_]);

            int onlySecond = second.Tags.Count - together;
            int onlyFirst = first.Tags.Count - together;

            return Math.Min(together, Math.Min(onlyFirst, onlySecond));
        }
    }

    public enum TagState
    {
        First,
        Second,
        Both
    }

    public class PhotoPair
    {
        public Photo First { get; set; }
        public Photo Second { get; set; }
    }
}
