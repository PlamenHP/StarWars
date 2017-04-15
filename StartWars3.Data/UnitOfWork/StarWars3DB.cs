
namespace StartWars3.Data.UnitOfWork
{
    using StarWars3.Data;
    using StarWars3.Models;
    using System;

    public class StarWars3DB: IStarWars3DB
    {
        private readonly IStarWars3Context starWars3Context;
        private IRepository<ApplicationUser> applicationUsers;
        private IRepository<CreateUnit> createUnits;
        private IRepository<LevelUpgradePrice> engineeringLevelsPrices;
        private IRepository<Factory> factories;
        private IRepository<Image> images;
        private IRepository<Planet> planets;
        private IRepository<Player> players;
        private IRepository<Price> prices;
        private IRepository<ResurceBuildingsLevel> resurceBuildingsLevels;
        private IRepository<UnitLevel> unitLevels;
        private IRepository<Unit> units;
        private IRepository<Cell> cells;
        private IRepository<Map> maps;


        public StarWars3DB(IStarWars3Context starWars3Contect)
        {
            if (starWars3Contect == null)
            {
                throw new ArgumentException("An instance of starWars3Contect is required to use this unit of work.", "starWars3Contect");
            }

            this.starWars3Context = starWars3Contect;
        }

        public IRepository<Cell> Cells => (cells ?? (this.cells = new GenericRepository<Cell>(starWars3Context)));
        public IRepository<Map> Maps => (maps ?? (this.maps = new GenericRepository<Map>(starWars3Context)));
        public IRepository<ApplicationUser> ApplicationUsers => (applicationUsers ?? (this.applicationUsers = new GenericRepository<ApplicationUser>(starWars3Context)));
        public IRepository<CreateUnit> CreateUnits => (createUnits ?? (this.createUnits = new GenericRepository<CreateUnit>(starWars3Context)));
        public IRepository<LevelUpgradePrice> EngineeringLevelsPrices => (engineeringLevelsPrices ?? (this.engineeringLevelsPrices = new GenericRepository<LevelUpgradePrice>(starWars3Context)));
        public IRepository<Factory> Factories => (factories ?? (this.factories = new GenericRepository<Factory>(starWars3Context)));
        public IRepository<Image> Images => (images ?? (this.images = new GenericRepository<Image>(starWars3Context)));
        public IRepository<Planet> Planets => (planets ?? (this.planets = new GenericRepository<Planet>(starWars3Context)));
        public IRepository<Player> Players => (players ?? (this.players = new GenericRepository<Player>(starWars3Context)));
        public IRepository<Price> Prices => (prices ?? (this.prices = new GenericRepository<Price>(starWars3Context)));
        public IRepository<ResurceBuildingsLevel> ResurceBuildingsLevels => (resurceBuildingsLevels ?? (this.resurceBuildingsLevels = new GenericRepository<ResurceBuildingsLevel>(starWars3Context)));
        public IRepository<UnitLevel> UnitLevels => (unitLevels ?? (this.unitLevels = new GenericRepository<UnitLevel>(starWars3Context)));
        public IRepository<Unit> Units => (units ?? (this.units = new GenericRepository<Unit>(starWars3Context)));

        public void SaveChanges()
        {
            this.starWars3Context.SaveChanges();
        }
    }
}
