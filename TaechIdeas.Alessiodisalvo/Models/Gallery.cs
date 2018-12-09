using System.Collections.Generic;

namespace TaechIdeas.Alessiodisalvo.Models
{
    public class Gallery
    {
        public string Name { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}