using System.Collections.Generic;

namespace StarWars3.Models
{
    public class Map
    {
        public Map()
        {
            Players = new HashSet<Player>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Rows { get; set; }

        public int Cols { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
