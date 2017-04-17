using StarWars3.Services.ServicesDTO;

namespace StarWars3.Web.ViewModels.Game
{
    public class LoadGameViewModel
    {
        public PlayerResourcesDTO playerResourcesDto { get; set; }

        public MapDTO mapDto { get; set; }
    }
}