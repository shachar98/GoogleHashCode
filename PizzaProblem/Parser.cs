using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PizzaProblem
{
    public class Parser : ParserBase<ProblemInput>
    {
        protected override ProblemInput ParseFromStream(TextReader reader)
        {
            ProblemInput input = new ProblemInput();
            string[] firstLineSplited = reader.ReadLine().Split(' ');
            input.Rows = int.Parse(firstLineSplited[0]);
            input.Columns = int.Parse(firstLineSplited[1]);
            input.MinIngredients = int.Parse(firstLineSplited[2]);
            input.MaxSliceSize = int.Parse(firstLineSplited[3]);
            input.Cells = new Cell[input.Rows, input.Columns];
            for (int i = 0; i < input.Rows; i++)
            {
                string s = reader.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == 'T')
                        input.Cells[i, j] = new Cell();
                    else
                        input.Cells[i, j] = new Cell();
                }
            }

            return input;
        }
    }
}
