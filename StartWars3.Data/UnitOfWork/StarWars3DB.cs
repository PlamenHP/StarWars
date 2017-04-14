
namespace StartWars3.Data.UnitOfWork
{
    using StarWars3.Data;
    using StarWars3.Models;
    using System;

    class StarWars3DB: IStarWars3DB
    {
        private readonly IStarWars3Context starWars3DB;
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

        public StarWars3DB(IStarWars3Context starWars3Contect)
        {
            if (starWars3Contect == null)
            {
                throw new ArgumentException("An instance of starWars3Contect is required to use this unit of work.", "starWars3Contect");
            }

            this.starWars3DB = starWars3Contect;
        }

        public IRepository<ApplicationUser> ApplicationUsers => (applicationUsers ?? (this.applicationUsers = new GenericRepository<ApplicationUser>(starWars3DB)));
        public IRepository<CreateUnit> CreateUnits => (createUnits ?? (this.createUnits = new GenericRepository<CreateUnit>(starWars3DB)));
        public IRepository<LevelUpgradePrice> EngineeringLevelsPrices => (engineeringLevelsPrices ?? (this.engineeringLevelsPrices = new GenericRepository<LevelUpgradePrice>(starWars3DB)));
        public IRepository<Factory> Factories => (factories ?? (this.factories = new GenericRepository<Factory>(starWars3DB)));
        public IRepository<Image> Images => (images ?? (this.images = new GenericRepository<Image>(starWars3DB)));
        public IRepository<Planet> Planets => (planets ?? (this.planets = new GenericRepository<Planet>(starWars3DB)));
        public IRepository<Player> Players => (players ?? (this.players = new GenericRepository<Player>(starWars3DB)));
        public IRepository<Price> Prices => (prices ?? (this.prices = new GenericRepository<Price>(starWars3DB)));
        public IRepository<ResurceBuildingsLevel> ResurceBuildingsLevels => (resurceBuildingsLevels ?? (this.resurceBuildingsLevels = new GenericRepository<ResurceBuildingsLevel>(starWars3DB)));
        public IRepository<UnitLevel> UnitLevels => (unitLevels ?? (this.unitLevels = new GenericRepository<UnitLevel>(starWars3DB)));
        public IRepository<Unit> Units => (units ?? (this.units = new GenericRepository<Unit>(starWars3DB)));

        public void SaveChanges()
        {
            this.starWars3DB.SaveChanges();
        }
    }
}
