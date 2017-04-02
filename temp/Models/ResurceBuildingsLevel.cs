namespace StarWars3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ResurceBuildingsLevel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int Level { get; set; }

        public int? PriceId { get; set; }

        public int? ResourceTime { get; set; }

        public int? ResourseAmount { get; set; }

    }
}
