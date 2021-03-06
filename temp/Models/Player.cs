namespace StarWars3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Player
    {
        public Player()
        {
            this.Units = new HashSet<Unit>();
            this.Planets = new HashSet<Planet>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Metal { get; set; }
        public int? Gas { get; set; }
        public int? Minerals { get; set; }

        public int? IncomeMetalTime { get; set; }
        public int? IncomeMetalAmount { get; set; }
        public int? IncomeGasTime { get; set; }
        public int? IncomeGasAmount { get; set; }
        public int? IncomeMineralsTime { get; set; }
        public int? IncomeMineralsAmount { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
    }
}
