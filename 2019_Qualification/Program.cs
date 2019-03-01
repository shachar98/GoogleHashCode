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
            Calculator calculator = new Calculator();

            Runner<ProblemInput, ProblemOutput> runner2 = new Runner<ProblemInput, ProblemOutput>(
                "2019", new Parser(), new Solver(), new Printer(), calculator);
            runner2.Run(Properties.Resources.a, "2019_a", 1, true);

            Console.WriteLine(DateTime.Now);

            Runner<ProblemInput, ProblemOutput> runner3 = new Runner<ProblemInput, ProblemOutput>(
               "2019", new Parser(), new Solver(), new Printer(), calculator);
            runner3.Run(Properties.Resources.b, "2019_b", 1, true);
            Console.WriteLine(DateTime.Now);

            Runner<ProblemInput, ProblemOutput> runner4 = new Runner<ProblemInput, ProblemOutput>(
               "2019", new Parser(), new Solver(), new Printer(), calculator);
            runner4.Run(Properties.Resources.c, "2019_c", 1, true);
            Console.WriteLine(DateTime.Now);

            Runner<ProblemInput, ProblemOutput> runner5 = new Runner<ProblemInput, ProblemOutput>(
               "2019", new Parser(), new Solver(), new Printer(), calculator);
            runner5.Run(Properties.Resources.d, "2019_d", 1, true);
            Console.WriteLine(DateTime.Now);

            Runner<ProblemInput, ProblemOutput> runner6 = new Runner<ProblemInput, ProblemOutput>(
               "2019", new Parser(), new Solver(), new Printer(), calculator);
            runner6.Run(Properties.Resources.e, "2019_e", 1, true);

            Console.WriteLine(DateTime.Now);

            ZipCreator.CreateCodeZip("2019");

            Console.Read();
        }
    }
}
