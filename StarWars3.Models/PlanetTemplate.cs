namespace StarWars3.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PlanetTemplate
    {
        public PlanetTemplate()
        {
            Locations = new HashSet<Cell>();
        }

        [Key]
        public int Id { get; set; }

        public bool IsTaken { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<Cell> Locations { get; set; }

        public virtual Planet Planet { get; set; }
    }
}
