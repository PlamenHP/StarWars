
namespace StartWars3.Data
{
    using StarWars3.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IStarWars3Context : IDisposable
    {
        IDbSet<CreateUnit> CreateUnits { get; set; }
        IDbSet<Cell> Cells { get; set; }
        IDbSet<Map> Maps { get; set; }
        IDbSet<LevelUpgradePrice> EngineeringLevelsPrices { get; set; }
        IDbSet<Factory> Factories { get; set; }
        IDbSet<Image> Images { get; set; }
        IDbSet<Planet> Planets { get; set; }
        IDbSet<Player> Players { get; set; }
        IDbSet<Price> Prices { get; set; }
        IDbSet<ResurceBuildingsLevel> ResurceBuildingsLevels { get; set; }
        IDbSet<UnitLevel> UnitLevels { get; set; }
        IDbSet<Unit> Units { get; set; }
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IDbSet<T> Set<T>() where T : class;
    }
}
