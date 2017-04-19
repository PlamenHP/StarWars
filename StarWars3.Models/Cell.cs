
namespace StarWars3.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cell
    {
        public Cell()
        {
            Units = new HashSet<Unit>();
            Factories = new HashSet<Factory>();
        }

        [Key]
        public int Id { get; set; }
        public int row { get; set; }
        public int col { get; set; }

        public virtual ICollection<Unit> Units { get; set; }

        public virtual ICollection<Factory> Factories { get; set; }

        public int? PlanetId { get; set; }
        public virtual Planet Planet { get; set; }
    }
}
