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
        public Pool(int index, int numOfRows) : base(index)
        {
        }

        public int Capacity { get; set; }
        public List<Server> Servers { get; set; }
        public List<int> Rows = new List<int>();

        public IEnumerable<int> GetOrderedRows()
        {
            return null;
        }

        public void AddServer(Server server, int row)
        {
            Servers.Add(server);
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
        public Pool Pool { get; set; }

    }

    public class Slot
    {
        public int RowId { get; set; }
        public int SlotId { get; set; }
    }
}
