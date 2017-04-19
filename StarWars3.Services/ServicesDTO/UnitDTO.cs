
namespace StarWars3.Services.ServicesDTO
{
    using Models;

    public class UnitDTO
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public CellDTO Cell { get; set; }
    }
}
