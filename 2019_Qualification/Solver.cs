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
                for (int i = 0; i < verticals.Count - 1; i += 2)
                {
                    var slide = new Slide();
                    slide.AddPhoto(verticals[i]);
                    slide.AddPhoto(verticals[i + 1]);
                    slides.Add(slide);
                }
            }
            return slides;
        }
        

        private int CalcScore(Slide first, Slide second)
        {
            int together = first.Tags.Intersect(second.Tags).Count();
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
