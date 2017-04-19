namespace StarWars3.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Planet
    {
        [Key]
        [ForeignKey("PlanetTemplate")]
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public virtual PlanetTemplate PlanetTemplate { get; set; }
    }
}
