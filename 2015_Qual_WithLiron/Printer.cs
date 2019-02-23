using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015_Qual_WithLiron
{
    public class Printer : PrinterBase<ProblemOutput>
    {
        public override void PrintToConsole(ProblemOutput result)
        {
            result.Servers = result.Servers.OrderBy(_ => _.Index).ToList();
            foreach (var item in result.Servers)
            {
                var s = "x";
                if (item.Assigned)
                {
                    s = $"{item.Slot.RowId} {item.Slot.SlotId} {item.PoolId }";
                }
                Console.WriteLine(s);
            }
        }

        public override void PrintToFile(ProblemOutput result, string outputPath)
        {
            using (var writer = new StreamWriter(outputPath))
            {
                result.Servers = result.Servers.OrderBy(_ => _.Index).ToList();
                foreach (var item in result.Servers)
                {
                    var s = "x";
                    if (item.Assigned)
                    {
                        s = $"{item.Slot.RowId} {item.Slot.SlotId} {item.PoolId }";
                    }
                    writer.WriteLine(s);
                }
            }
        }
    }
}
