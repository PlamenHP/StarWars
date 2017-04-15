
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
        public static PlayerResourcesDTO GetPlayerResources(IStarWars3DB context,int playerId)
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

            var units = context.Units.All().Select(u=>new GameObjectDTO(){Id=u.Id,Image = u.Image, Location = new[] { u.Location } }).ToList();
            var factories = context.Factories.All().Select(u => new GameObjectDTO() { Id = u.Id, Image = u.Image, Location = new[] { u.Location } }).ToList();
            var planets = context.Planets.All().Select(u => new GameObjectDTO() { Id = u.Id, Image = u.Image, Location = u.Locations }).ToList();

            mapDto.GameObjects.AddRange(units);
            mapDto.GameObjects.AddRange(factories);
            mapDto.GameObjects.AddRange(planets);

            return mapDto;
        }
    }
}
