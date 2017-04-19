
namespace StarWars3.Web.Areas.Admin.ViewModels
{
    using StarWars3.Infrastructure.Mapping;
    using StarWars3.Models;

    public class CellViewModel: IMapFrom<Cell>, IMapTo<Cell>
    {
        public int row { get; set; }

        public int col { get; set; }
    }
}