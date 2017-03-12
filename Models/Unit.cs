namespace StarWars3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Unit
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        //public int? Atack { get; set; }
        //public int? Shield { get; set; }
        //public int? Armor { get; set; }
        //public int? Speed { get; set; }
        //public int? FuelConsumption { get; set; }

        public int? WarFactotyRequiredLevel { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public int? PriceId { get; set; }
        public virtual Price Price { get; set; }

        public int? PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int UnitLevelId { get; set; }
        public virtual UnitLevel UnitLevel { get; set; }
    }
}
