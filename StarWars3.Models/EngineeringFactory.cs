namespace StarWars3.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EngineeringFactories")]
    public class EngineeringFactory : Factory
    {
        public virtual ICollection<LevelUpgradePrice> AttackLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ShieldLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ArmorLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ScoutLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> HealthLevel { get; set; }

        public int Attack { get; set; }

        public int Armor { get; set; }

        public int Shield { get; set; }
    }
}
