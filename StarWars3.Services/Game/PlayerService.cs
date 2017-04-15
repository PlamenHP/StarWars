
namespace StarWars3.Services.Game
{
    using Models;
    using StartWars3.Data.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class PlayerService
    {
        public static void GetResourcesAmount(int id)
        {

        }

        public static bool IfNoOtherPlayers(IStarWars3DB context)
        {
            return context.Players.All() == null;
        }

        public static Map GetMapSize(IStarWars3DB context, string mapName)
        {
            return context.Maps.FirstOrDefault(m => m.Name == mapName);
        }
    }
}
