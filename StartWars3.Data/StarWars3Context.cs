namespace StarWars3.Data
{
    using System.Data.Entity;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data;
    using StartWars3.Data;
    using System;

    public partial class StarWars3Context : IdentityDbContext<ApplicationUser>, IStarWars3Context
    {
        public StarWars3Context()
            : base("StarWars3Context", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<StarWars3Context>()
                );
        }

        public static StarWars3Context Create()
        {
            return new StarWars3Context();
        }

        IDbSet<T> IStarWars3Context.Set<T>()
        {
            return base.Set<T>();
        }
        public virtual IDbSet<Cell> Cells { get; set; }
        public virtual IDbSet<Map> Maps { get; set; }
        public virtual IDbSet<CreateUnit> CreateUnits { get; set; }
        public virtual IDbSet<LevelUpgradePrice> EngineeringLevelsPrices { get; set; }
        public virtual IDbSet<Factory> Factories { get; set; }
        public virtual IDbSet<Image> Images { get; set; }
        public virtual IDbSet<Planet> Planets { get; set; }
        public virtual IDbSet<Player> Players { get; set; }
        public virtual IDbSet<Price> Prices { get; set; }
        public virtual IDbSet<ResurceBuildingsLevel> ResurceBuildingsLevels { get; set; }
        public virtual IDbSet<UnitLevel> UnitLevels { get; set; }
        public virtual IDbSet<Unit> Units { get; set; }
        
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
