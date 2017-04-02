namespace StarWars3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class EngineeringFactory
    {

        [ForeignKey("Planet")]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<LevelUpgradePrice> AttackLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ShieldLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ArmorLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> ScoutLevel { get; set; }

        public virtual ICollection<LevelUpgradePrice> HealthLevel { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public virtual Planet Planet { get; set; }
    }
}
