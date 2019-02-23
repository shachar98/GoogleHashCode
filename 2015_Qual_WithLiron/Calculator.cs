using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015_Qual_WithLiron
{
    public class Calculator : ScoreCalculatorBase<ProblemInput, ProblemOutput>
    {
        public override long Calculate(ProblemInput input, ProblemOutput output)
        {

            var pools = new Dictionary<int, int>();
            foreach (var item in output.Servers)
            {
               if (!pools.ContainsKey(item.Pool.Index))
                {
                    pools.Add(item.Pool.Index, item.Capacity);
                }
                else
                {
                    pools[item.Pool.Index] += item.Capacity;
                }
            }

            return pools.Min(_ => _.Value);
        }

        public override ProblemOutput GetResultFromReader(ProblemInput input, TextReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
