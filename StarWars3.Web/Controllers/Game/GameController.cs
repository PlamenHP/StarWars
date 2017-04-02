
namespace StarWars3.Web.Controllers.Game
{
    using Data;
    using Microsoft.AspNet.Identity;
    using Services.Game;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels;
    using ViewModels.Game;

    public class GameController : Controller
    {
        public ActionResult Index()
        {

            int playerId = InitialiseUser.Initialise(User.Identity.GetUserId());

            return Redirect($"Game/Planet/{playerId}");
        }

        // GET: Planet
        public ActionResult Planet(int? id)
        {
            var context = new StarWars3Context();

            var factory = context.Players.Find(id).Planets.FirstOrDefault().Factories.ToList();
            List<BuildingViewModel> buildings = new List<BuildingViewModel>();

            foreach (var f in factory)
            {
                BuildingViewModel b = new BuildingViewModel()
                {
                    FactoryType = f.FactoryType,
                    Health = f.Health,
                    Id = f.Id,
                    Level = f.Level,
                };

                buildings.Add(b);
            }

            PlanetViewModel planetViewModel = new PlanetViewModel()
            {
                Name = context.Players.Find(id).Planets.FirstOrDefault().Name,
                Buildings = buildings               
            };

            return View(planetViewModel);
        }
    }
}