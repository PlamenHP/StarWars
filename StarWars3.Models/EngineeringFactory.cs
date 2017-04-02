namespace StarWars3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class EngineeringFactory : Factory
    {
        public virtual ICollection<LevelUpgradePrice> AttackLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ShieldLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ArmorLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ScoutLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> HealthLevel { get; set; }
    }
}
