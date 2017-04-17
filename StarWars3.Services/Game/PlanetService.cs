
namespace StarWars3.Services.Game
{
    using Models;
    using ServicesDTO;
    using StartWars3.Data.UnitOfWork;
    using System.Linq;

    public static class PlanetService
    {
        public static int GetPlanetIdByLocation(IStarWars3DB context, CellDTO cell)
        {
            int id = context.Planets.FirstOrDefault(p =>

            p.Locations.Any(l => (l.row == cell.row) && (l.col == cell.col))).Id;

            return id;
        }

        public static void BuildFactory(IStarWars3DB context, int planetId, int factoryHealth, FactoryType factoryType, CellDTO location)
        {
            Factory factory = new Factory()
            {
                FactoryType = factoryType,
                Health = factoryHealth,
                Location = new Cell { row = location.row, col = location.col },
                PlanetId = planetId           
            };

            context.Factories.Add(factory);
            context.SaveChanges();
        }

        public static void BuildFighter(IStarWars3DB context, int playerId, UnitType unitType,CellDTO location)
        {
            Unit fighter = new Unit()
            {
                Name = "Fighter",
                PlayerId = playerId,
                Location = new Cell { row = location.row, col = location.col },
                UnitLevelId = 1
            };

            context.Units.Add(fighter);
            context.SaveChanges();
        }
    }
}
