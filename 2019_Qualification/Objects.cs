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
        public List<string> Tags { get; set; }
    }

    public class Slide
    {
        public List<Photo> Photos { get; set; } = new List<Photo>();

        public List<string> Tags { get; set; } = new List<string>();

        public void AddPhoto(Photo photo)
        {
            Photos.Add(photo);
            Tags = Tags.Union(photo.Tags).ToList();
        }
    }

    public enum Directions
    {
        Horizontal,
        Vertical
    }
}
