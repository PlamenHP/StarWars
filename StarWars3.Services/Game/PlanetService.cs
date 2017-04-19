
namespace StarWars3.Services.Game
{
    using Models;
    using ServicesDTO;
    using StartWars3.Data.UnitOfWork;
    using System;
    using System.Linq;

    public static class PlanetService
    {
        public static int GetPlanetIdByLocation(IStarWars3DB context, CellDTO cell)
        {
            int id = context.Planets.FirstOrDefault(p =>

            p.PlanetTemplate.Locations.Any(l => (l.row == cell.row) && (l.col == cell.col))).Id;

            return id;
        }

        public static void BuildFactory(IStarWars3DB context, FactoryType factoryType,int playerId ,CellDTO location)
        {
            FactoryTemplate factoryTemplate = context.FactoryTemplates.FirstOrDefault(t => t.FactoryType == factoryType);

            if (factoryTemplate == null)
            {
                throw new NullReferenceException("BuildFactory: Factory type not found!");
            }

            Factory factory = new Factory()
            {
                FactoryTemplateId = factoryTemplate.Id,
                Level = factoryTemplate.Level,
                PlayerId = playerId,
                Health = factoryTemplate.Health,
                Shield = factoryTemplate.Shield,
                Location = new Cell { row = location.row, col = location.col },    
            };

            context.Factories.Add(factory);
            context.SaveChanges();
        }

        public static void BuildFighter(IStarWars3DB context, int playerId, UnitType unitType,CellDTO location)
        {
            int r = location.row;
            int c = location.col;

            int[][] cellArray = new int[][]
            {
                new int[] { (r - 1), c },
                new int[] { (r - 1), (c + 1) },
                new int[] { r, (c + 1) },
                new int[] { (r + 1), (c + 1) },
                new int[] { (r + 1), c },
                new int[] { r, (c - 1) }
            };


            Cell cell = new Cell();
            bool emptyCell = false;
            for (int i = 0; i < cellArray.Length; i++)
            {
                Unit unit = PlayerService.LocationHasUnit(
                    context, cellArray[i][0], cellArray[i][1]);
                bool planet = PlayerService.LocationHasPlanet(
                    context, cellArray[i][0], cellArray[i][1]);

                if (unit == null && !planet)
                {
                    cell.row = cellArray[i][0];
                    cell.col = cellArray[i][1];
                    emptyCell = true;
                    break;
                }
            }

            UnitTemplate unitTemplate = context.UnitTemplates.FirstOrDefault(t=>t.UnitType == unitType);
            if (unitTemplate == null)
            {
                throw new NullReferenceException("BuildFighter: unitTemplate not found!");
            }

            UnitLevel uLevel = GetUnitLevel(context, unitTemplate.UnitType, 0);

            if (emptyCell)
            {
                Unit fighter = new Unit()
                {
                    UnitTemplateId = unitTemplate.Id,
                    PlayerId = playerId,
                    Location = cell,
                    Armor = unitTemplate.Armor,
                    Damage = unitTemplate.Damage,
                    Shield = unitTemplate.Shield,
                    Range = unitTemplate.Range,
                    Speed = unitTemplate.Speed,
                    Health = unitTemplate.Health,
                    FuelConsumption = unitTemplate.FuelConsumption
                };

                context.Units.Add(fighter);
                context.SaveChanges();
            }
            else
            {
                //throw new ArgumentException("Not enought space in Space!");
            }
        }

        public static UnitLevel GetUnitLevel(IStarWars3DB context, UnitType unitType, int level)
        {
            return context.UnitLevels.All()
                .Where(ul =>
                    ul.Type == unitType &&
                    ul.Level == level)
                .FirstOrDefault();
        }
    }
}
