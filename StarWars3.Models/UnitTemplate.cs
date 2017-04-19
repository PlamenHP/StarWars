namespace StarWars3.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UnitTemplate
    {
        public UnitTemplate()
        {
            Units = new HashSet<Unit>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public UnitType UnitType { get; set; }

        public byte[] Image { get; set; }

        public int RequiredLevel { get; set; }

        public int Damage { get; set; }
        public int Range { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int Speed { get; set; }
        public int FuelConsumption { get; set; }
        public int Health { get; set; }

        public int MetalCost { get; set; }
        public int GasCost { get; set; }
        public int MineralsCost { get; set; }
        public int TimeCost { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}
