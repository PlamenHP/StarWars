
namespace StarWars3.Models
{
    using System.Collections.Generic;

    public class FactoryTemplate
    {
        public FactoryTemplate()
        {
            Factories = new HashSet<Factory>();
        }

        public int Id { get; set; }

        public FactoryType FactoryType { get; set; }

        public byte[] Image { get; set; }

        public int Health { get; set; }
        public int Shield { get; set; }
        public int Level { get; set; }
        public int? Income { get; set; }

        public int? MetalCost { get; set; }
        public int? GasCost { get; set; }
        public int? MineralsCost { get; set; }
        public int? TimeCost { get; set; }

        public virtual ICollection<Factory> Factories { get; set; }
    }
}
