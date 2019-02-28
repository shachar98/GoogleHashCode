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
            int parts = 100;
            int splitSize = input.Photos.Count / parts;
            List<Slide> slides = new List<Slide>();
            ProblemInput newInput = new ProblemInput();
            foreach (var item in input.Photos)
            {
                if (newInput.Photos.Count == splitSize)
                {
                    slides.AddRange(solver.Solve(newInput, this.NumbersGenerator, this.ProblemName).Slideshow);
                    newInput = new ProblemInput();
                }

                newInput.Photos.Add(item);
            }

            return new ProblemOutput() { Slideshow = slides };
        }
    }
}
