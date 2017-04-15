namespace StarWars3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {
        public Player()
        {
            this.Units = new HashSet<Unit>();
            this.Planets = new HashSet<Planet>();
        }

        public int Id { get; set; }
        [Index(IsUnique = true),MaxLength(128)]
        public string AspNetId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int MapId { get; set; }
        public virtual Map Map { get; set; }

        public int Metal { get; set; }
        public int Gas { get; set; }
        public int Minerals { get; set; }

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
