namespace StarWars3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Planet
    {
        public Planet()
        {
            this.Factories = new HashSet<Factory>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public virtual EngineeringFactory EngineeringFactory { get; set; }

        public virtual ICollection<Factory> Factories { get; set; }
    }
}
