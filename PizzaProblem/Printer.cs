using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProblem
{
    public class Printer : PrinterBase<ProblemOutput>
    {
        public override void PrintToConsole(ProblemOutput result)
        {
            foreach (var item in result.Slices)
            {
                Console.WriteLine($"{item.minRow} {item.minCol} {item.maxRow} {item.maxCol}");
            }
        }

        public override void PrintToFile(ProblemOutput result, string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine(result.Slices.ToString());
                foreach (var item in result.Slices)
                {
                    writer.WriteLine($"{item.minRow} {item.minCol} {item.maxRow} {item.maxCol}");
                }
            }
        }
    }
}
