using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    public class Photo
    {
        public Directions Direction { get; set; }
        public List<string> Tags { get; set; }
    }

    public enum Directions
    {
        Horizontal,
        Veical
    }
}
