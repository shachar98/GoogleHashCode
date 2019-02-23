using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015_Qual_WithLiron
{
    public class Solver : SolverBase<ProblemInput, ProblemOutput>
    {
        private ProblemOutput m_ProblemOutput = new ProblemOutput();
        private ProblemInput m_ProblemInput;

        protected override ProblemOutput Solve(ProblemInput input)
        {
            m_ProblemInput = input;
            List<Server> orderedServers = OrderServersByCapacity().ToList();
            List<Server> sizeOneServers = orderedServers.Where( _=> _.Size == 1).ToList();
            List<Server> notSizeOneServers = orderedServers.Where( _=> _.Size != 1).ToList();
            
            List<Server> leftServers = AssignFirstTwoRows(notSizeOneServers).ToList();
            
            AssignServers(leftServers);
            AssignServers(sizeOneServers);

            return null;
        }

        private IEnumerable<Server> OrderServersByCapacity()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Server> AssignFirstTwoRows(List<Server> notSizeOneServers)
        {
            throw new NotImplementedException();
        }

        private void AssignServers(IEnumerable<Server> servers)
        {
            foreach (Server server in servers)
            {
                IEnumerable<Pool> pools = GetOrderedPools().Reverse();

                foreach (var pool in pools)
                {
                    foreach (int row in pool.GetOrderedRows().Reverse())
                    {
                        if (TryAssignServerToRow(server, row, pool))
                        {
                            break;
                        }
                    }

                    if (server.Assigned)
                        break;
                }
            }
        }

        private IEnumerable<Pool> GetOrderedPools()
        {
            throw new NotImplementedException();
        }

        private bool TryAssignServerToRow(Server server, int row, Pool pool)
        {
            throw new NotImplementedException();
        }
    }
}
