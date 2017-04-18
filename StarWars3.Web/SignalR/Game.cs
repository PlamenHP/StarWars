namespace StarWars3.Web.SignalR
{
    using Microsoft.AspNet.SignalR;
    using Models;
    using Services.Game;
    using Services.ServicesDTO;
    using Services.Utilities;
    using StartWars3.Data.UnitOfWork;

    public class Game : Hub
    {
        private IStarWars3DB data;

        private static int playerId;

        private static CellDTO selectedCell;

        public Game(IStarWars3DB data)
        {
            this.data = data;

            if (selectedCell == null)
            {
                selectedCell = new CellDTO();
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
                    Clients.All.drawPlanet(cell.row, cell.col);
                }
            }
        }

        public void GetBuildings()
        {
            var buildings = PlayerService.GetBuildings(data);

            foreach (var building in buildings)
            {
                Clients.All.drawGasFactory(building.Cell.row, building.Cell.col);
            }
        }

        public void GetUnits()
        {
            var units = PlayerService.GetUnits(data);

            foreach (var unit in units)
            {
                Clients.All.drawFighter(unit.Cell.row, unit.Cell.col);
            }
        }

        
        /////////////// RECEIVE MOUSE CLICK CELL LOCATION AND SHOW MENU BUTTONS///////////////////////
        public void OnMouseDown(int row, int col)
        {
            selectedCell.row = row;
            selectedCell.col = col;

            Unit unit = PlayerService.LocationHasUnit(data, row, col);

            if (unit != null)
            {
                Clients.Caller.showUnitsStats(unit.UnitLevel);
            }
            else if (PlayerService.LocationHasBuilding(data, row, col))
            {
                Clients.Caller.showUnitsMenu();
            }
            else if (PlayerService.LocationHasPlanet(data, row, col))
            {
                Clients.All.showBuildingsMenu();
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

            PlanetService.BuildFactory(data, planetId, Constants.GasFactoryHealth, FactoryType.GasFactory, selectedCell);

            Clients.All.drawGameObjectGas(selectedCell.row, selectedCell.col);
        }

        public void BuildMetalFactory()
        {
            int planetId = PlanetService.GetPlanetIdByLocation(data, selectedCell);

            PlanetService.BuildFactory(data, planetId, Constants.MetalFactoryHealth, FactoryType.MetalFactory, selectedCell);
        }

        public void BuildMineralsFactory()
        {
            int planetId = PlanetService.GetPlanetIdByLocation(data, selectedCell);

            PlanetService.BuildFactory(data, planetId, Constants.MineralsFactoryHealth, FactoryType.MineralsFactory, selectedCell);
        }


        // //////////// CREATING UNITS ////////////////////
        public void BuildFighter()
        {
            PlanetService.BuildFighter(data,playerId, UnitType.Fighter ,selectedCell);

            GetUnits();
        }
    }
}