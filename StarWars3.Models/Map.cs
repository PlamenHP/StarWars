using System.Collections.Generic;

namespace StarWars3.Models
{
    public class Map
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int HorizontalCells { get; set; }

        public int VerticalCells { get; set; }
    }
}
