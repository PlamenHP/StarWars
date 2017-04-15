namespace StarWars3.Models
{
    public class Factory
    {
        public int Id { get; set; }

        public FactoryType FactoryType { get; set; }

        public int Level { get; set; }

        public int Health { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public int? PlanetId { get; set; }
        public virtual Planet Planet { get; set; }

        public int LocationId { get; set; }
        public virtual Cell Location { get; set; }
    }
}
