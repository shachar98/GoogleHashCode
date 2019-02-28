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
            //Console.WriteLine(result.Slideshow.Count);
            //foreach (var item in result.Slideshow)
            //{
            //    var str = string.Join(" ", item.Photos.Select(_ => _.Index));
            //    Console.WriteLine(str); 
            //}
        }

        public override void PrintToFile(ProblemOutput result, string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine(result.Slideshow.Count);
                foreach (var item in result.Slideshow)
                {
                    var str = string.Join(" ", item.Photos.Select(_=>_.Index));
                    writer.WriteLine(str);
                }
            }
        }
    }
}
