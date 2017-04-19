
namespace StartWars3.Data.UnitOfWork
{
    using StarWars3.Data;
    using StarWars3.Models;

    public interface IStarWars3DB
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<PlanetTemplate> PlanetTemplates { get; }

        IRepository<FactoryTemplate> FactoryTemplates { get; }

        IRepository<UnitTemplate> UnitTemplates { get; }

        IRepository<LevelUpgradePrice> EngineeringLevelsPrices { get; }

        IRepository<Factory> Factories { get; }

        IRepository<Planet> Planets { get; }

        IRepository<Player> Players { get; }

        IRepository<Price> Prices { get; }

        IRepository<ResurceBuildingsLevel> ResurceBuildingsLevels { get; }

        IRepository<UnitLevel> UnitLevels { get; }

        IRepository<Unit> Units { get; }

        IRepository<Cell> Cells { get; }

        IRepository<Map> Maps { get; }

        void SaveChanges();
    }
}