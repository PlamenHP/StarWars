
namespace StarWars3.Services.ServicesDTO
{
    using Models;

    public class BuildingDTO
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public CellDTO Cell { get; set; }
    }
}
