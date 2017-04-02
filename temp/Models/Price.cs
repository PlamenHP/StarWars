namespace StarWars3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Price
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? MetalCost { get; set; }
        public int? GasCost { get; set; }
        public int? MineralsCost { get; set; }
        public int? TimeCost { get; set; }
    }
}
