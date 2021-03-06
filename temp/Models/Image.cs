namespace StarWars3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Image
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public byte[] Container { get; set; }

    }
}
