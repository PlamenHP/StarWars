
namespace StarWars3.Services.ServicesDTO
{
    using StarWars3.Models;
    using System.Collections.Generic;

    public class GameObjectDTO
    {
        public int Id { get; set; }

        public Image Image { get; set; }

        public ICollection<Cell> Location { get; set; }
    }
}
