
namespace StarWars3.Services.Game
{
    using AutoMapper;
    using Infrastructure.Mapping;
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

        public static ICollection<PlanetDTO> GetPlanets(IStarWars3DB context)
        {
            var planets = context.PlanetTemplates.All().Where(p=>p.IsTaken).Select(p => new PlanetDTO
            { Id = p.Id, Image = p.Image, Cells = p.Locations.Select(l=>new CellDTO { row=l.row,col= l.col}).ToList() }).ToList();

            return planets;
        }

        public static UnitStatsDTO LocationHasUnit(IStarWars3DB context, int row, int col)
        {
            var unit = context.Units
                .All()
                .Where(u => 
                    u.Location.row == row && 
                    u.Location.col == col)
                .FirstOrDefault();

            if (unit != null)
            {
                return new UnitStatsDTO
                {
                    Id = unit.Id,
                    Armor = unit.Armor,
                    Damage = unit.Damage,
                    FuelConsumption = unit.FuelConsumption,
                    Health = unit.Health,
                    Range = unit.Range,
                    Shield = unit.Shield,
                    Speed = unit.Speed
                };
            }
            return null;

        }

        public static Unit GetUnitByLocation(IStarWars3DB context, int row, int col)
        {
            return context.Units.All().Where(u => u.Location.row == row && u.Location.col == col).FirstOrDefault();
        }

        public static Factory LocationHasBuilding(IStarWars3DB context, int row, int col)
        {
            return context.Factories
                .All()
                .Where(l => 
                    l.Location.row == row && 
                    l.Location.col == col)
                .FirstOrDefault();
        }

        public static Planet LocationHasPlanet(IStarWars3DB context,int row, int col)
        {
            return context.Planets.All()
                .Where(p => p.PlanetTemplate.Locations.Any(l =>
                    l.row == row &&
                    l.col == col))
                .FirstOrDefault();
        }

        public static ICollection<BuildingDTO> GetBuildings(IStarWars3DB context)
        {
            var buildings = context.Factories.All().Select(p => new BuildingDTO
                 { Id = p.Id, Image = p.FactoryTemplate.Image, Cell = new CellDTO { row = p.Location.row, col = p.Location.col } }).ToList();


            return buildings;
        }

        public static ICollection<UnitDTO> GetUnits(IStarWars3DB context)
        {
            var units = context.Units.All().Select(p => new UnitDTO
            { Id = p.Id, Image = p.UnitTemplate.Image, Cell = new CellDTO { row = p.Location.row, col = p.Location.col } }).ToList();

            return units;
        }

        public static void ChangeUnitLocation(IStarWars3DB context, CellDTO selectedCell, CellDTO previousCell)
        {
            Unit unit = GetUnitByLocation(context, previousCell.row, previousCell.col);
            Cell newLocation = new Cell
            {
                row = selectedCell.row,
                col = selectedCell.col
            };
            context.Cells.Add(newLocation);
            unit.Location = newLocation;
            context.SaveChanges();
        }
    }
}

