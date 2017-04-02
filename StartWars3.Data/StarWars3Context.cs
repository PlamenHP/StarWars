namespace StarWars3.Data
{
    using System.Data.Entity;
    using Models;

    public partial class StarWars3Context : DbContext
    {
        public StarWars3Context()
            : base("name=StarWars3Context")
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<StarWars3Context>()
                );
        }

        public virtual DbSet<CreateUnit> CreateUnits { get; set; }
        public virtual DbSet<LevelUpgradePrice> EngineeringLevelsPrices { get; set; }
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ResurceBuildingsLevel> ResurceBuildingsLevels { get; set; }
        public virtual DbSet<UnitLevel> UnitLevels { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
    }
}
