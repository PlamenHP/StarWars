﻿
namespace StarWars3.Services.Game
{
    using Data;
    using Models;
    using StartWars3.Data.UnitOfWork;
    using System.Linq;
    using Utilities;

    public class InitialiseUser
    {
        public static int Initialise(string aspNetId, IStarWars3DB context )
        {
            int playerId;

            if (!(context.Players.Any(p => p.AspNetId == aspNetId)))
            {

                Factory gasFactory = new Factory()
                {
                    FactoryType = FactoryType.GasFactory,
                    Health = Constants.GasFactoryHealth,
                    Level = Constants.DefaultFactoryLevel
                };

                Factory metalFactory = new Factory()
                {
                    FactoryType = FactoryType.MetalFactory,
                    Health = Constants.MetalFactoryHealth,
                    Level = Constants.DefaultFactoryLevel
                };

                Factory mineralsFactory = new Factory()
                {
                    FactoryType = FactoryType.MineralsFactory,
                    Health = Constants.MineralsFactoryHealth,
                    Level = Constants.DefaultFactoryLevel
                };

                Factory warFactory = new Factory()
                {
                    FactoryType = FactoryType.WarFactory,
                    Health = Constants.WarFactoryHealth,
                    Level = Constants.DefaultFactoryLevel
                };

                EngineeringFactory engineeringFactory = new EngineeringFactory()
                {
                    FactoryType = FactoryType.EngineeringFactory,
                    Health = Constants.EngineeringFactoryHealth,
                    Level = Constants.DefaultFactoryLevel
                };

                Planet planet = new Planet()
                {
                    Name = "Earth",
                    Factories = new[]
                    {
                        gasFactory,
                        metalFactory,
                        mineralsFactory,
                        warFactory,
                        engineeringFactory
                    }
                };

                context.Players.Add(new Player()
                {
                    AspNetId = aspNetId,
                    Planets = new[] { planet }
                });

                context.SaveChanges();
            }

            playerId = context.Players.FirstOrDefault(p=>p.AspNetId == aspNetId).Id;

            return playerId;
        }

        private bool IsExistingPlayer(int? id)
        {
            var context = new StarWars3Context();
            return context.Players.Any(p=>p.Id == id);
        }
    }
}
