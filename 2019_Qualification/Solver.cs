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


            foreach (var curr in input.Photos)
            {
                foreach(var curr2 in input.Photos)
                {
                    var score = CalcScore(curr,curr2);
                }
            }

            // Solve the problem
            throw new NotImplementedException();
        }

        private int CalcScore(Photo first, Photo second)
        {
            int together = first.Tags.Count(_ => second.Tags.Any(__ => __ == _));
            int onlySecond = second.Tags.Count - together;
            int onlyFirst = first.Tags.Count - together;

            return Math.Min(together, Math.Min(onlyFirst, onlySecond));
        }
    }
}
