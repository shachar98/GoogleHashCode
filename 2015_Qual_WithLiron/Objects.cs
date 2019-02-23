using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015_Qual_WithLiron
{
    public class Pool : IndexedObject
    {
        private int m_Rows;

        public Pool(int index, int numOfRows) : base(index)
        {
            m_Rows = numOfRows;
            Rows = new SlotRow[numOfRows];
            for (int i = 0; i < numOfRows; i++)
            {
                Rows[i] = new SlotRow(i) { Capacity = 0 };
            }
            OrderdRows = Rows.OrderBy(_ => _.Capacity).ToList();
            Servers = new List<Server>();

            if (AllRows == null || AllRows.Length != numOfRows)
            {
                AllRows = new SlotRow[numOfRows];
                for (int i = 0; i < numOfRows; i++)
                {
                    AllRows[i] = new SlotRow(i) { Capacity = 0 };
                }
            }
        }

        public long Capacity { get; set; }
        public List<Server> Servers { get; set; }
        private static SlotRow[] AllRows;
        public SlotRow[] Rows;
        private List<SlotRow> OrderdRows;

        public List<SlotRow> GetOrderedRows()
        {
            return Rows.OrderBy(_ => _.Capacity * 100000 + AllRows[_.Index].Capacity).ToList();
        }

        public void AddServer(Server server, int row)
        {
            Servers.Add(server);
            Rows[row].Capacity += server.Capacity;
            AllRows[row].Capacity += server.Capacity;

            OrderdRows = Rows.OrderBy(_ => _.Capacity).ToList();

            Capacity = Rows.Sum(_ => _.Capacity) - OrderdRows.Last().Capacity;
        }
    }

    public class SlotRow : IndexedObject
    {
        public SlotRow(int index) : base(index)
        {
        }

        public long Capacity { get; set; }
    }

    public class Server : IndexedObject
    {
        public Server(int index) : base(index)
        {
        }

        public int Size { get; set; }
        public int Capacity { get; set; }
        public bool Assigned { get; set; }
        public Slot Slot { get; set; }
        public int PoolId { get; set; }

    }

    public class Slot
    {
        public int RowId { get; set; }
        public int SlotId { get; set; }
    }
}
