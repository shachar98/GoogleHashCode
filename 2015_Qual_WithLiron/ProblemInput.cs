using System.Collections.Generic;

namespace _2015_Qual_WithLiron
{
    public class ProblemInput
    {
        public int Rows{ get; set; }
        public int Slots { get; set; }
        public int UnavailableSlotsNum { get; set; }
        public int Pools { get; set; }
        public int ServersNum { get; set; }

        public List<Server> Servers { get; set; } = new List<Server>();
        public List<Slot> UnavailableSlots { get; set; } = new List<Slot>();
    }
}
