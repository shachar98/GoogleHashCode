using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    public class Photo : IndexedObject
    {
        public Photo(int index) : base(index)
        {
        }

        public int TimesAdded { get; set; } = 0;
        public Directions Direction { get; set; }
        public List<int> Tags { get; set; }
    }

    public class Slide
    {
        public List<Photo> Photos { get; set; } = new List<Photo>();

        public HashSet<int> Tags { get; set; } = new HashSet<int>();

        public void AddPhoto(Photo photo)
        {
            Photos.Add(photo);
            foreach (var item in photo.Tags)
            {
                Tags.Add(item);
            }
        }
    }

    public enum Directions
    {
        Horizontal,
        Vertical
    }
}
