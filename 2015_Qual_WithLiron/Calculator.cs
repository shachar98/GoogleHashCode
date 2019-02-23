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
            var pools = new List<Pool>();
            for (int i = 0; i < input.Pools; i++)
            {
                pools.Add(new Pool(i, input.Rows));
            }

            foreach (var item in output.Servers)
            {
                var server = input.Servers[item.Index];
                pools[item.PoolId].AddServer(server, item.Slot.RowId);
            }

            var result =  pools.Min(_ => _.Capacity);
            return result;
        }

        public override ProblemOutput GetResultFromReader(ProblemInput input, TextReader reader)
        {
            ProblemOutput output = new ProblemOutput();
            output.Servers = new List<Server>();
            string s = reader.ReadLine();
            int j = 0;
            while (s != null)
            {
                if (!s.Equals("x"))
                {
                    string[] splited = s.Split(' ');
                    output.Servers.Add(new Server(j) { Slot = new Slot() { RowId = int.Parse(splited[0]), SlotId = int.Parse(splited[1]) }, PoolId = int.Parse(splited[2]) });
                }

                j++;
                s = reader.ReadLine();
            }

            return output;
        }
    }
}
