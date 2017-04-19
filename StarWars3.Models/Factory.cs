
namespace StarWars3.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Factory
    {
        public int Id { get; set; }

        public int Health { get; set; }
        public int Shield { get; set; }
        public int Level { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int LocationId { get; set; }
        public virtual Cell Location { get; set; }

        public int FactoryTemplateId { get; set; }
        public virtual FactoryTemplate FactoryTemplate { get; set; }
    }
}
