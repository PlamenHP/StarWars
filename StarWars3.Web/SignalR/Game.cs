namespace StarWars3.Web.SignalR
{
    using Microsoft.AspNet.SignalR;
    using Newtonsoft.Json;
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

        public void ShowGame()
        {
            //int playerId = int.Parse(id);
            //MapDTO mapDTO = PlayerService.GetMap(data, playerId);
            //PlayerResourcesDTO playerResourcesDto = PlayerService.GetPlayerResources(data, playerId);
            //LoadGameViewModel showGameVieModel = new LoadGameViewModel()
            //{
            //    mapDto = mapDTO,
            //    playerResourcesDto = playerResourcesDto
            //};
            Clients.Caller.drawBoard(0, 16, 20);
            GetPlanets();
            //GetBuildings();
            //GetUnits();
        }


        public void GetPlanets()
        {
            var planets = PlayerService.GetPlanets(data);

            foreach (var planet in planets)
            {
                foreach (var cell in planet.Cells)
                {
                    Clients.Caller.drawGameObject(cell.row, cell.col);
                }
            }
        }

        public void GetBuildings()
        {
            var buildings = PlayerService.GetBuildings(data);

            foreach (var building in buildings)
            {
                Clients.Caller.drawGameObject(building.Cell.row, building.Cell.col);
            }
        }

        public void GetUnits()
        {
            var units = PlayerService.GetUnits(data);

            foreach (var unit in units)
            {
                Clients.Caller.drawGameObject(unit.Cell.row, unit.Cell.col);
            }
        }

        public void OnMouseDown(int row, int col)
        {
            if (PlayerService.LocationHasUnit(data,row,col))
            {
                Clients.Caller.showBuildingsMenu();
            }
            if (PlayerService.LocationHasBuilding(data, row, col))
            {
                Clients.Caller.showBuildingsMenu();
            }
            if (PlayerService.LocationHasPlanet(data, row, col))
            {
                Clients.Caller.showBuildingsMenu();
            }
        }
    }
}