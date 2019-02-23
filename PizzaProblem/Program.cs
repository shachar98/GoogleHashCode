using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner<ProblemInput, ProblemOutput> runner1 = new Runner<ProblemInput, ProblemOutput>(
                "Pizza", new Parser(), new Solver(), new Printer()); //, new Calcutaor());
            runner1.Run(Properties.Resources.exampleText, "charleston_road", 1, true);

            ZipCreator.CreateCodeZip("PizzaProblem");
        }
    }
}
