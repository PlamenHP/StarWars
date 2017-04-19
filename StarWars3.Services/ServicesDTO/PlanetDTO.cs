
namespace StarWars3.Services.ServicesDTO
{
    using Models;
    using System.Collections.Generic;

    public class PlanetDTO
    {
        public PlanetDTO()
        {
            Cells = new List<CellDTO>();
        }

        public int Id { get; set; }

        public byte[] Image { get; set; }

        public ICollection<CellDTO> Cells { get; set; }
    }
}
