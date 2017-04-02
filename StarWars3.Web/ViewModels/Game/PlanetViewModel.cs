using System.Collections.Generic;

namespace StarWars3.Web.ViewModels.Game
{
    public class PlanetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ViewImage { get; set; }

        public ICollection<BuildingViewModel> Buildings { get; set; }
    }
}