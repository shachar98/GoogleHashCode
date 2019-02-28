using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    public class Calculator : ScoreCalculatorBase<ProblemInput, ProblemOutput>
    {
        public override long Calculate(ProblemInput input, ProblemOutput output)
        {
            // Calculate score
            var result = 0;

            for (int i = 0; i < output.Slideshow.Count-1; i++)
            {
                int commonTags = 0;
                int diffTags1 = 0;
                int diffTags2 = 0;

                var tags1 = output.Slideshow[i].Tags;
                var tags2 = output.Slideshow[i + 1].Tags;
                commonTags = tags1.Intersect(tags2).Count();
                diffTags1 = tags1.Except(tags2).Count();
                diffTags2 = tags2.Except(tags1).Count();

                result += Math.Min(commonTags, (Math.Min(diffTags1, diffTags2)));
            }

            return result;
        }

        public override ProblemOutput GetResultFromReader(ProblemInput input, TextReader reader)
        {
            ProblemOutput output = new ProblemOutput();

            output.Slideshow = new List<Slide>();
            string str = reader.ReadLine();
            str = reader.ReadLine();
            while (str != null)
            {
                string[] splited = str.Split(' ');
                var slide = new Slide();
                var p = new List<Photo>();
                for (int i = 0; i < splited.Length; i++)
                {
                    p.Add(input.Photos[i]);
                }

                foreach (var item in p)
                {
                    slide.AddPhoto(item);
                }
                output.Slideshow.Add(slide);

                str = reader.ReadLine();
            }

            // Read  output from reader
            return output;
        }
    }
}
