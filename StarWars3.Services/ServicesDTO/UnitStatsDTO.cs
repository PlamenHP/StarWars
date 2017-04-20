using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars3.Services.ServicesDTO
{
    public class UnitStatsDTO
    {
        public int Id { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int Speed { get; set; }
        public int FuelConsumption { get; set; }
        public int Health { get; set; }
    }
}
