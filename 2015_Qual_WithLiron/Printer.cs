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
            result.Servers = result.Servers.OrderBy(_ => _.Index);
            foreach (var item in result.Servers)
            {
                var s = "x";
                if (item.Assigned)
                {
                    s = $"Server {item.Index} placed in row {item.Slot.RowId} at slot {item.Slot.SlotId} and assigned to pool {item.Pool.Index}.";
                }
                Console.WriteLine(s);
            }
        }

        public override void PrintToFile(ProblemOutput result, string outputPath)
        {
            using (var writer = new StreamWriter(outputPath))
            {
                result.Servers = result.Servers.OrderBy(_ => _.Index);
                foreach (var item in result.Servers)
                {
                    var s = "x";
                    if (item.Assigned)
                    {
                        s = $"Server {item.Index} placed in row {item.Slot.RowId} at slot {item.Slot.SlotId} and assigned to pool {item.Pool.Index}.";
                    }
                    writer.WriteLine(s);
                }
            }
        }
    }
}
