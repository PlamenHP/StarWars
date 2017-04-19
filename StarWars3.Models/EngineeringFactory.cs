namespace StarWars3.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EngineeringFactories")]
    public class EngineeringFactory : Factory
    {
        public virtual ICollection<LevelUpgradePrice> DamageLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> RangeLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ShieldLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ArmorLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> HealthLevel { get; set; }
    }
}
