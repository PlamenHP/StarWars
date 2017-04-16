namespace StarWars3.Web.SignalR
{
    using Microsoft.AspNet.SignalR;
    using Services.Game;
    using Services.ServicesDTO;
    using StartWars3.Data.UnitOfWork;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Game;

    public class Game : Hub
    {
        private IStarWars3DB data;

        public Game(IStarWars3DB data)
        {
            this.data = data;
        }

        public void ShowGame(string id)
        {
            int playerId = int.Parse(id);
            MapDTO mapDTO = PlayerService.GetMap(data, playerId);
            PlayerResourcesDTO playerResourcesDto = PlayerService.GetPlayerResources(data, playerId);
            ShowGameViewModel showGameVieModel = new ShowGameViewModel()
            {
                mapDto = mapDTO,
                playerResourcesDto = playerResourcesDto
            };

            

            Clients.All.showGame(id);
        }

    }
}