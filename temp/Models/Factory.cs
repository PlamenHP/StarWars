namespace StarWars3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Factory
    {
        private string[] name =
        {
            "MetalFactory",
            "GasFactory",
            "MineralsFactory",
            "WarFactory"
        };

        public int Id { get; set; }

        public string Name { get; private set; }

        public int Level { get; set; }

        public int Health { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public int? PlanetId { get; set; }
        public virtual Planet Planet { get; set; }

        public Factory(FactoryType type)
        {
            this.Name = name[(int)type];
        }

        public Factory()
        {

        }
    }

    public enum FactoryType
    {
        MetalFactory,
        GasFactory,
        MineralsFactory,
        WarFactory
    }
}
