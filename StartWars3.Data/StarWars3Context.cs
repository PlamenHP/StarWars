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
        public virtual DbSet<EngineeringFactory> EngineeringFactories { get; set; }
        public virtual DbSet<LevelUpgradePrice> EngineeringLevelsPrices { get; set; }
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ResurceBuildingsLevel> ResurceBuildingsLevels { get; set; }
        public virtual DbSet<UnitLevel> UnitLevels { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Unicode
            modelBuilder.Entity<CreateUnit>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EngineeringFactory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Factory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Planet>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Price>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ResurceBuildingsLevel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UnitLevel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Name)
                .IsUnicode(false);
            #endregion
        }
    }
}
