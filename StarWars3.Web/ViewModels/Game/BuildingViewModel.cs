using StarWars3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWars3.Web.ViewModels.Game
{
    public class BuildingViewModel
    {
        public int Id { get; set; }
        public FactoryType FactoryType { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public string ViewImage { get; set; }
    }
}