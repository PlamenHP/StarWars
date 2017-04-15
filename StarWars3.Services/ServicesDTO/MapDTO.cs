
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars3.Services.ServicesDTO
{
    public class MapDTO
    {
        public MapDTO()
        {
            GameObjects = new List<GameObjectDTO>();
        }
        public int Row { get; set; }

        public int Col { get; set; }

        public List<GameObjectDTO> GameObjects { get; set; }
    }
}
