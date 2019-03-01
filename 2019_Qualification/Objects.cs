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

        int index = 0;

        public void AddPhoto(Photo photo)
        {
            index += photo.Index * 137;
            Photos.Add(photo);
            foreach (var item in photo.Tags)
            {
                Tags.Add(item);
            }
        }

        public override int GetHashCode()
        {
            return index;
        }

        public override bool Equals(object obj)
        {
            Slide other = obj as Slide;
            return Photos.Count == other.Photos.Count && Photos.Intersect(other.Photos).Count() == Photos.Count;
        }
    }

    public enum Directions
    {
        Horizontal,
        Vertical
    }
}
