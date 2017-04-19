namespace StarWars3.Models
{
    public class Unit
    {
        public int Id { get; set; }

        public int Damage { get; set; }
        public int Range { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int Speed { get; set; }
        public int FuelConsumption { get; set; }
        public int Health { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int UnitTemplateId { get; set; }
        public virtual UnitTemplate UnitTemplate { get; set; }

        public int LocationId { get; set; }
        public virtual Cell Location { get; set; }
    }
}
