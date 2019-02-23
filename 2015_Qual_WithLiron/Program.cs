using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015_Qual_WithLiron
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner<ProblemInput, ProblemOutput> runner1 = new Runner<ProblemInput, ProblemOutput>(
                "2015", new Parser(), new Solver(), new Printer(), new Calculator());
            runner1.Run(Properties.Resources.Input, "2015_example", 1, true);

            ZipCreator.CreateCodeZip("2015_example");

            Console.Read();
        }
    }
}
