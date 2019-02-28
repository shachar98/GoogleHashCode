using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    public class SolverSplitter : SolverBase<ProblemInput, ProblemOutput>
    {
        protected override ProblemOutput Solve(ProblemInput input)
        {
            Solver solver = new Solver();
            int parts = 1000;
            int splitSize = input.Photos.Count / parts;
            List<Slide> slides = new List<Slide>();
            ProblemInput newInput = new ProblemInput();
            int count = 0;
            foreach (var item in input.Photos)
            {
                if (newInput.Photos.Count == splitSize)
                {
                    Console.WriteLine(count++);
                    slides.AddRange(solver.Solve(newInput, this.NumbersGenerator, this.ProblemName).Slideshow);
                    newInput = new ProblemInput();
                }

                newInput.Photos.Add(item);
            }

            slides.AddRange(solver.Solve(newInput, this.NumbersGenerator, this.ProblemName).Slideshow);

            return new ProblemOutput() { Slideshow = slides };
        }
    }
}
