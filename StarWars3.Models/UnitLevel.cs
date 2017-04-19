
namespace StarWars3.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UnitLevel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public UnitType Type { get; set; }
        public int Level { get; set; }

        public int? Damage { get; set; }
        public int? Range { get; set; }
        public int? Shield { get; set; }
        public int? Armor { get; set; }
        public int? Health { get; set; }
        public int? Speed { get; set; }
        public int? FuelConsumption { get; set; }
    }
}
