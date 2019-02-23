using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015_Qual_WithLiron
{
    public class Pool
    {
        public int Capacity { get; set; }
        public List<Machine> Machines { get; set; }
    }

    public class Machine
    {
        public int Size { get; set; }
        public int Capacity { get; set; }
        public Slot Slot { get; set; }
        public Pool Pool { get; set; }

    }

    public class Slot
    {
        public int RowId { get; set; }
        public int SlotId { get; set; }
    }
}
