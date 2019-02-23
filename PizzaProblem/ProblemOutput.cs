using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProblem
{
    public class ProblemOutput
    {
        public List<Slice> Slices { get; set; }
        public ProblemInput Input { get; set; }
    }

    public class Slice
    {
        public int minRow { get; set; }
        public int maxRow { get; set; }
        public int minCol { get; set; }
        public int maxCol { get; set; }

        public int RowSize { get { return maxRow - minRow + 1; } }
        public int ColSize { get { return maxCol - minCol + 1; } }
        public int Size { get { return RowSize * ColSize; } }
    }
}
