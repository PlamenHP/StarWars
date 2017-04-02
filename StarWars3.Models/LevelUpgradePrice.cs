namespace StarWars3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public enum Level
    {
        Level1,
        Level2,
        Level3
    }

    public enum UpgradeType
    {
        Atack,
        Shiel,
        Armor,
        Scout,
        Health
    }

    public class LevelUpgradePrice
    {
        [Key]
        [Column(Order = 0)]
        public Level Level { get; set; }

        [Key]
        [Column(Order = 1)]
        public UpgradeType UpgradeType { get; set; }

        public int PriceId { get; set; }
        public virtual Price Price { get; set; }

        public int? EngineeringFactoryId { get; set; }
        public virtual EngineeringFactory EngineeringFactory { get; set; }
    }
}
