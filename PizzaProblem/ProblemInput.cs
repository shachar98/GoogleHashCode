using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProblem
{
    public class ProblemInput
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int MinIngredients { get; set; }
        public int MaxSliceSize { get; set; }

        public Cell[,] Cells { get; set; }
    }

    public class Cell
    {
    }
}
