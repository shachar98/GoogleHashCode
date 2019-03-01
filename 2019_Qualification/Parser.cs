using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    public class Parser : ParserBase<ProblemInput>
    {
        protected override ProblemInput ParseFromStream(TextReader reader)
        {
            ProblemInput input = new ProblemInput();

            string[] firstLineSplited = reader.ReadLine().Split(' ');
            var imageCount = int.Parse(firstLineSplited[0]);
           
            for (var i = 0; i < imageCount; i++)
            {
                string[] photoStr = reader.ReadLine().Split(' ');

                Photo photo = new Photo(i);
               
                if(photoStr[0] == "H")
                {
                    photo.Direction = Directions.Horizontal;
                }
                else
                {
                    photo.Direction = Directions.Vertical;
                }
                
                photo.Tags = photoStr.ToList().Skip(2).OrderBy(_ => _).Select(_ => GetCode(_)).ToList();

                input.Photos.Add(photo);
            }

            input.NumOfTags = codesMap.Count;
            return input;
        }

        Dictionary<string, int> codesMap = new Dictionary<string, int>();

        private int GetCode(string tag)
        {
            if (codesMap.TryGetValue(tag, out int code))
            {
                return code;
            }
            else
            {
                codesMap.Add(tag, codesMap.Count);
                return codesMap.Count - 1;
            }
        }
    }
}
