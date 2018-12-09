using System.Collections.Generic;

namespace TaechIdeas.Alessiodisalvo.Models
{
    public class Room
    {
        public string Name { get; set; }

        public string CoverRelativePath { get; set; }
        public IEnumerable<Picture> Pictures { get; set; }
    }
}