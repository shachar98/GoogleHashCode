using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    public class Printer : PrinterBase<ProblemOutput>
    {
        public override void PrintToConsole(ProblemOutput result)
        {
            result.Slideshow = result.Slideshow.OrderBy(_ => _.Index).ToList();
            Console.WriteLine(result.Slideshow.Count);
            foreach (var item in result.Slideshow)
            {
                var str = string.Join(" ", item.Photos);
                Console.WriteLine(str); 
            }
        }

        public override void PrintToFile(ProblemOutput result, string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                result.Slideshow = result.Slideshow.OrderBy(_ => _.Index).ToList();
                writer.WriteLine(result.Slideshow.Count);
                foreach (var item in result.Slideshow)
                {
                    var str = string.Join(" ", item.Photos);
                    writer.WriteLine(str);
                }
            }
        }
    }
}
