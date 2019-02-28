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
            if (allSlides.Count < 2)
                return new ProblemOutput() { Slideshow = allSlides};

            slides.Add(allSlides[0]);
            var leftPhotos = allSlides.Skip(1).ToList();
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

            var verticals = groups.FirstOrDefault(_ => _.Key == Directions.Vertical)?.ToList();
            if (verticals != null)
            {
                SplitVerticals2(slides, verticals);
            }
            return slides;
        }

        private static void SplitVerticals2(List<Slide> slides, List<Photo> verticals)
        {
            List<Photo> usedVerticals = new List<Photo>();
            foreach (var item in verticals)
            {
                if (usedVerticals.Contains(item))
                    continue;

                usedVerticals.Add(item);
                var maxTags = -1;
                Photo maxPhoto = null;
                var coll = verticals.Except(usedVerticals);
                foreach (var item2 in coll)
                {
                    var x = item2.Tags.Union(item.Tags).Count();
                    if (maxTags < x)
                    {
                        maxTags = x;
                        maxPhoto = item2;
                    }
                }

                usedVerticals.Add(maxPhoto);

                var slide = new Slide();
                slide.AddPhoto(item);
                slide.AddPhoto(maxPhoto);
                slides.Add(slide);
            }
        }

        private static void SplitVerticals(List<Slide> slides, List<Photo> verticals)
        {
            for (int i = 0; i < verticals.Count - 1; i += 2)
            {
                var slide = new Slide();
                slide.AddPhoto(verticals[i]);
                slide.AddPhoto(verticals[i + 1]);
                slides.Add(slide);
            }
        }
        
        private int CalcScore(Slide first, Slide second)
        {
            int together = first.Tags.Count(_ => second.Tags.Contains(_));
            // int together = first.Tags.Count(_ => second.Tags.Any(__ => __ == _));
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
