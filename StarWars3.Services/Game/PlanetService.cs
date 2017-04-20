
namespace StarWars3.Services.Game
{
    using Models;
    using ServicesDTO;
    using StartWars3.Data.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class PlanetService
    {
        public static int GetPlanetIdByLocation(IStarWars3DB context, CellDTO cell)
        {
            int id = context.Planets.FirstOrDefault(p =>

            p.PlanetTemplate.Locations.Any(l => (l.row == cell.row) && (l.col == cell.col))).Id;

            return id;
        }

        public static void BuildFactory(IStarWars3DB context, FactoryType factoryType, int playerId, CellDTO location)
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
                Location = new Cell { row = location.row, col = location.col }
            };

            context.Factories.Add(factory);
            context.SaveChanges();
        }

        public static void buildUnit(IStarWars3DB context, int playerId, UnitType unitType, CellDTO location)
        {
            Cell cell = FreeCell(context, location.row, location.col);
            UnitLevel uLevel = GetUnitLevel(context, unitType, 0);

            if (cell != null)
            {
                UnitTemplate unitTemplate = context.UnitTemplates.FirstOrDefault(t => t.UnitType == unitType);
                if (unitTemplate == null)
                {
                    throw new NullReferenceException("BuildFighter: unitTemplate not found!");
                }

                Unit unit = new Unit()
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
                    FuelConsumption = unitTemplate.FuelConsumption,                   
                };

                context.Units.Add(unit);
                context.SaveChanges();
            }

        }

        private static Cell FreeCell(IStarWars3DB context, int r, int c)
        {
            int[][] cellArrayOdd = new int[][]
            {
                new int[] { (r - 1), c },
                new int[] { (r - 1), (c + 1) },
                new int[] { r, (c + 1) },
                new int[] { (r + 1), (c + 1) },
                new int[] { (r + 1), c },
                new int[] { r, (c - 1) }
            };

            int[][] cellArrayEven = new int[][]
            {
                new int[] { (r - 1), (c - 1) },
                new int[] { (r - 1), c },
                new int[] { r, (c + 1) },
                new int[] { (r + 1), c },
                new int[] { (r + 1), (c - 1) },
                new int[] { r, (c - 1) }
            };

            int[][] array;

            if (r % 2 == 0)
            {
                array = cellArrayEven;
            }
            else
            {
                array = cellArrayOdd;
            }

            Cell cell = new Cell();

            for (int i = 0; i < array.Length; i++)
            {
                Unit unit = PlayerService.LocationHasUnit(
                    context, array[i][0], array[i][1]);
                Planet planet = PlayerService.LocationHasPlanet(
                    context, array[i][0], array[i][1]);

                if (unit == null && planet == null)
                {
                    cell.row = array[i][0];
                    cell.col = array[i][1];
                    return cell;
                }
            }
            return null;
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
