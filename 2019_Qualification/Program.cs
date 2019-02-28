using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    class Program
    {
        static void Main(string[] args)
        {

            Runner<ProblemInput, ProblemOutput> runner2 = new Runner<ProblemInput, ProblemOutput>(
                "2019", new Parser(), new Solver(), new Printer(), new Calculator());
            runner2.Run(Properties.Resources.a, "2019_input", 1, true);

            Runner<ProblemInput, ProblemOutput> runner3 = new Runner<ProblemInput, ProblemOutput>(
               "2019", new Parser(), new Solver(), new Printer(), new Calculator());
            runner3.Run(Properties.Resources.b, "2019_input", 1, true);


            Runner<ProblemInput, ProblemOutput> runner4 = new Runner<ProblemInput, ProblemOutput>(
               "2019", new Parser(), new Solver(), new Printer(), new Calculator());
            runner4.Run(Properties.Resources.c, "2019_input", 1, true);


            Runner<ProblemInput, ProblemOutput> runner5 = new Runner<ProblemInput, ProblemOutput>(
               "2019", new Parser(), new Solver(), new Printer(), new Calculator());
            runner5.Run(Properties.Resources.d, "2019_input", 1, true);


            Runner<ProblemInput, ProblemOutput> runner6 = new Runner<ProblemInput, ProblemOutput>(
               "2019", new Parser(), new Solver(), new Printer(), new Calculator());
            runner6.Run(Properties.Resources.e, "2019_input", 1, true);

            ZipCreator.CreateCodeZip("2019");

            Console.Read();
        }
    }
}
