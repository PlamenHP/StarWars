
namespace StarWars3.Services.Game
{
    using Models;
    using ServicesDTO;
    using StartWars3.Data.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class PlayerService
    {
        public static PlayerResourcesDTO GetPlayerResources(IStarWars3DB context, int playerId)
        {
            var player = context.Players.GetById(playerId);

            PlayerResourcesDTO playerResourcesDto = new PlayerResourcesDTO()
            {
                Gas = player.Gas,
                Metal = player.Metal,
                Minerals = player.Minerals
            };

            return playerResourcesDto;
        }

        public static bool IfNoOtherPlayers(IStarWars3DB context)
        {
            return context.Players.All() == null;
        }

        public static MapDTO GetMap(IStarWars3DB context, int playerId)
        {
            var map = context.Players.GetById(playerId).Map;

            MapDTO mapDto = new MapDTO()
            {
                Col = map.Cols,
                Row = map.Rows
            };

            var units = context.Units.All().Select(u => new GameObjectDTO() { Id = u.Id, Image = u.Image, Location = new[] { u.Location } }).ToList();
            var factories = context.Factories.All().Select(u => new GameObjectDTO() { Id = u.Id, Image = u.Image, Location = new[] { u.Location } }).ToList();
            var planets = context.Planets.All().Select(u => new GameObjectDTO() { Id = u.Id, Image = u.Image, Location = u.Locations }).ToList();

            mapDto.GameObjects.AddRange(units);
            mapDto.GameObjects.AddRange(factories);
            mapDto.GameObjects.AddRange(planets);

            return mapDto;
        }

        public static ICollection<PlanetDTO> GetPlanets(IStarWars3DB context)
        {
            var planets = context.Planets.All().Select(p => new PlanetDTO
            { Id = p.Id, Image = p.Image, Cells = p.Locations.Select(l=>new CellDTO { row=l.row,col= l.col}).ToList() }).ToList();

            return planets;
        }

        public static bool LocationHasUnit(IStarWars3DB context, int row, int col)
        {
            bool hasPlanet = context.Units.Any(l =>  l.Location.row == row && l.Location.col == col);

            return hasPlanet;
        }

        public static bool LocationHasBuilding(IStarWars3DB context, int row, int col)
        {
            bool hasPlanet = context.Factories.Any(l => l.Location.row == row && l.Location.col == col);

            return hasPlanet;
        }

        public static bool LocationHasPlanet(IStarWars3DB context,int row, int col)
        {
            bool hasPlanet = context.Planets.Any(p=>p.Locations.Any(l=>l.row==row&&l.col==col));

            return hasPlanet;
        }

        public static ICollection<BuildingDTO> GetBuildings(IStarWars3DB context)
        {
            var buildings = context.Factories.All().Select(p => new BuildingDTO
            { Id = p.Id, Image = p.Image, Cell = new CellDTO { row = p.Location.row, col = p.Location.col } }).ToList();

            return buildings;
        }

        public static ICollection<UnitDTO> GetUnits(IStarWars3DB context)
        {
            var units = context.Units.All().Select(p => new UnitDTO
            { Id = p.Id, Image = p.Image, Cell = new CellDTO { row = p.Location.row, col = p.Location.col } }).ToList();

            return units;
        }
    }
}

