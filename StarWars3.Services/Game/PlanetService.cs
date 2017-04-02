
namespace StarWars3.Services.Game
{
    using Data;
    using Models;
    using System.Collections.Generic;

    public class PlanetService
    {
        public ICollection<Factory> GetFactories(int? id)
        {
            var context = new StarWars3Context();
            var factories = context.Planets.Find(id).Factories;
            return factories;
        }
    }
}
