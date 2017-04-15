
namespace StarWars3.Web.Controllers.Game
{
    using Microsoft.AspNet.Identity;
    using Services.Game;
    using System.Web.Mvc;
    using ViewModels.Game;
    using StartWars3.Data.UnitOfWork;
    using Services.ServicesDTO;

    public class GameController : BaseController
    {
        public GameController(IStarWars3DB data) : base(data)
        {
        }

        public ActionResult Index()
        {

            int playerId = InitialisePlayer.Initialise(User.Identity.GetUserId(), Data);

            return Redirect($"Game/ShowGame/{playerId}");
        }

        // GET: Planet
        public ActionResult ShowGame(int playerId)
        {
            MapDTO mapDTO = PlayerService.GetMap(Data, playerId);
            PlayerResourcesDTO playerResourcesDto = PlayerService.GetPlayerResources(Data, playerId);
            ShowGameViewModel showGameVieModel = new ShowGameViewModel()
            {
                mapDto = mapDTO,
                playerResourcesDto = playerResourcesDto
            };
            return View(showGameVieModel);
        }
    }
}