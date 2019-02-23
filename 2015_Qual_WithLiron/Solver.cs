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
        private ProblemInput m_ProblemInput;
        private List<Pool> m_Pools = new List<Pool>();
        private bool[,] m_Slots;

        protected override ProblemOutput Solve(ProblemInput input)
        {
            m_ProblemInput = input;
            InitPools();
            InitSlots();

            List<Server> orderedServers = OrderServersByCapacity().ToList();
            List<Server> sizeOneServers = orderedServers.Where(_ => _.Size == 1).ToList();
            List<Server> notSizeOneServers = orderedServers.Where(_ => _.Size != 1).ToList();

            List<Server> leftServers = AssignFirstRow(notSizeOneServers).ToList();

            AssignServers(leftServers);
            AssignServers(sizeOneServers);

            return new ProblemOutput() { Servers = input.Servers };
        }

        private void InitPools()
        {
            m_Pools = new List<Pool>();
            for (int i = 0; i < m_ProblemInput.Pools; i++)
            {
                m_Pools.Add(new Pool(i, m_ProblemInput.Rows));
            }
        }

        private void InitSlots()
        {
            m_Slots = new bool[m_ProblemInput.ServersNum, m_ProblemInput.Slots];
            foreach (Slot currSlot in m_ProblemInput.UnavailableSlots)
            {
                m_Slots[currSlot.RowId, currSlot.SlotId] = true;
            }
        }

        private IEnumerable<Server> OrderServersByCapacity()
        {
            return m_ProblemInput.Servers.OrderBy(_ => ((double)_.Capacity) / _.Size);
        }

        private IEnumerable<Server> AssignFirstRow(List<Server> notSizeOneServers)
        {
            int rowNum = 0;
            foreach (var pool in m_Pools)
            {
                Server server = notSizeOneServers[0];
                if (TryAssignServerToRow(server, rowNum++, pool))
                {
                    notSizeOneServers.RemoveAt(0);
                    break;
                }
            }

            return notSizeOneServers;
        }

        private void AssignServers(IEnumerable<Server> servers)
        {
            foreach (Server server in servers)
            {
                IEnumerable<Pool> pools = GetOrderedPools();

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
            return m_Pools.OrderBy(_ => _.Capacity);
        }

        private bool TryAssignServerToRow(Server server, int row, Pool pool)
        {
            int freeSpace = 0;

            for (int slot = 0; slot < m_ProblemInput.Slots; slot++)
            {
                if (m_Slots[row, slot])
                {
                    freeSpace = 0;
                }
                else
                {
                    freeSpace++;
                    if (freeSpace == server.Capacity)
                    {
                        server.Assigned = true;
                        server.Slot = new Slot() { RowId = row, SlotId = slot };
                        pool.AddServer(server, row);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
