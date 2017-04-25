namespace StarWars3.Web.SignalR
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.SignalR;
    using Models;
    using Services.Game;
    using Services.ServicesDTO;
    using StartWars3.Data.UnitOfWork;

    public class Game : Hub
    {
        private IStarWars3DB data;

        private static int playerId;

        private static CellDTO selectedCell;
        private static CellDTO previousCell;

        private static bool changeLocation;

        public Game(IStarWars3DB data)
        {
            this.data = data;

            if (selectedCell == null)
            {
                selectedCell = new CellDTO();
            }

            if (previousCell == null)
            {
                previousCell = new CellDTO();
            }
        }


        public void ShowGame(int id)
        {
            playerId = id;
            Clients.All.clearBoard();
            Clients.All.drawBoard(16, 20);
            GetPlanets();
            GetBuildings();
            GetUnits();
        }


        //////////// GET OBJECTS FROM DATABASE AND DRAW THEM ///////////////////
        public void GetPlanets()
        {
            var planets = PlayerService.GetPlanets(data);

            foreach (var planet in planets)
            {
                foreach (var cell in planet.Cells)
                {
                    Clients.All.drawGameObject(cell.row, cell.col, planet.Image);
                }
            }
        }

        public void GetBuildings()
        {
            var buildings = PlayerService.GetBuildings(data);

            foreach (var building in buildings)
            {
                Clients.All.drawGameObject(building.Cell.row, building.Cell.col, building.Image);
            }
        }

        public void GetUnits()
        {
            var units = PlayerService.GetUnits(data);

            foreach (var unit in units)
            {
                Clients.All.drawGameObject(unit.Cell.row, unit.Cell.col, unit.Image);
            }
        }

        
        /////////////// RECEIVE MOUSE CLICK CELL LOCATION AND SHOW MENU BUTTONS///////////////////////
        public void OnMouseDown(int row, int col)
        {
            ShowGame(playerId);

            previousCell.row = selectedCell.row;
            previousCell.col = selectedCell.col;

            selectedCell.row = row;
            selectedCell.col = col;

            Clients.Caller.markHexagonAsSelected(row, col);

            UnitStatsDTO unitStats = PlayerService.LocationHasUnit(data, row, col);
            Unit unit = PlayerService.GetUnitByLocation(data, row, col);
            Planet planet = PlayerService.LocationHasPlanet(data, row, col);
            Factory building = PlayerService.LocationHasBuilding(data, row, col);

            if (unit != null && 
                unit.PlayerId == playerId)
            {
                changeLocation = true;
                Clients.Caller.showUnitsStats(unitStats);
            }
            else if (building != null &&
                    planet != null &&
                    planet.PlayerId == playerId)
            {
                changeLocation = false;
                Clients.Caller.showUnitsMenu();
            }
            else if (planet != null &&
                    building == null &&
                    planet.PlayerId == playerId)
            {
                changeLocation = false;
                Clients.All.showBuildingsMenu();
            }
            else if (changeLocation)
            {
                PlayerService.ChangeUnitLocation(data, selectedCell, previousCell);
                changeLocation = false;
                Clients.All.hideMenu();
                ShowGame(playerId);
            }
            else
            {
                Clients.All.hideMenu();
            }
        }


        ////////////// CREATING  BUILDINGS ////////////////////////
        public void BuildGasFactory()
        {
            int planetId = PlanetService.GetPlanetIdByLocation(data, selectedCell);
         
            PlanetService.BuildFactory(data, FactoryType.GasFactory, playerId, selectedCell);

            GetBuildings();
        }

        public void BuildMetalFactory()
        {
            int planetId = PlanetService.GetPlanetIdByLocation(data, selectedCell);

            PlanetService.BuildFactory(data, FactoryType.MetalFactory, playerId, selectedCell);

            GetBuildings();
        }

        public void BuildMineralsFactory()
        {
            int planetId = PlanetService.GetPlanetIdByLocation(data, selectedCell);

            PlanetService.BuildFactory(data, FactoryType.MineralsFactory, playerId, selectedCell);

            GetBuildings();
        }


        // //////////// CREATING UNITS ////////////////////
        public void BuildFighter()
        {
            PlanetService.buildUnit(data,playerId, UnitType.Fighter, selectedCell);

            GetUnits();
        }
        public void BuildDestroyer()
        {
            PlanetService.buildUnit(data, playerId, UnitType.Destroyer, selectedCell);

            GetUnits();
        }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}