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
            OrderdRows = Rows.OrderBy(_ => _.Capacity).Select(_ => _.Index).ToList();
            Servers = new List<Server>();
        }

        public int Capacity { get; set; }
        public List<Server> Servers { get; set; }
        public SlotRow[] Rows;
        private List<int> OrderdRows;

        public List<int> GetOrderedRows()
        {
            return OrderdRows;
        }

        public void AddServer(Server server, int row)
        {
            Servers.Add(server);
            Rows[row].Capacity += server.Capacity;

            OrderdRows = Rows.OrderBy(_ => _.Capacity).Select(_ => _.Index).ToList();

            Capacity = Rows.Sum(_ => _.Capacity) - Rows[OrderdRows.Last()].Capacity;
        }

        public class SlotRow : IndexedObject
        {
            public SlotRow(int index) : base(index)
            {
            }

            public int Capacity { get; set; }
        }
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
