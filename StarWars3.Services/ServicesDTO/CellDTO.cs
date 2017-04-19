
namespace StarWars3.Services.ServicesDTO
{
    using Infrastructure.Mapping;
    using StarWars3.Models;

    public class CellDTO : IMapFrom<Cell>, IMapTo<Cell>
    {
        public int row { get; set; }

        public int col { get; set; }
    }
}