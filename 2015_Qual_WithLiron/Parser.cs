using HashCodeCommon;
using System.Collections.Generic;
using System.IO;

namespace _2015_Qual_WithLiron
{
    public class Parser : ParserBase<ProblemInput>
    {
        protected override ProblemInput ParseFromStream(TextReader reader)
        {
            ProblemInput input = new ProblemInput();
            
            string[] firstLineSplited = reader.ReadLine().Split(' ');
            input.Rows = int.Parse(firstLineSplited[0]);
            input.Slots = int.Parse(firstLineSplited[1]);
            input.UnavailableSlotsNum = int.Parse(firstLineSplited[2]);
            input.Pools = int.Parse(firstLineSplited[3]);
            input.ServersNum = int.Parse(firstLineSplited[4]);
            input.UnavailableSlots = new List<Slot>();
            input.Servers = new List<Server>();

            for (int i = 0; i < input.UnavailableSlotsNum; i++)
            {
                string[] coor = reader.ReadLine().Split(' ');
                Slot slot = new Slot();
                checked
                {
                    slot.RowId = int.Parse(coor[0]);
                    slot.SlotId = int.Parse(coor[1]);
                }

                input.UnavailableSlots.Add(slot);
            }

            for (var i = 0; i < input.ServersNum; i++)
            {
                string[] serverStr = reader.ReadLine().Split(' ');
                Server server = new Server();
                checked
                {
                    server.Size = int.Parse(serverStr[0]);
                    server.Capacity = int.Parse(serverStr[1]);
                }

                input.Servers.Add(server);
            }

            return input;
        }
    }
}
