
namespace StarWars3.Services.Game
{
    using Data;
    using Models;
    using StartWars3.Data.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;

    public class InitialisePlayer
    {
        public static int Initialise(string aspNetId, IStarWars3DB context )
        {
            int? playerId;

            if (!(context.Players.Any(p => p.AspNetId == aspNetId)))
            {
                Planet planet = new Planet()
                {
                    PlanetTemplate = context.PlanetTemplates.FirstOrDefault(p => p.IsTaken == false)
                };

                if (planet.PlanetTemplate == null)
                {
                    throw new ArgumentException("No available planets found");
                }

                planet.PlanetTemplate.IsTaken = true;

                context.Players.Add(new Player()
                {
                    AspNetId = aspNetId,
                    Planets = new[] { planet },
                    Gas = Constants.InitialPlayerGas,
                    Metal = Constants.InitialPlayerMetal,
                    Minerals = Constants.InitialPlayerMinerals
                });

                context.SaveChanges();
            }

            playerId = context.Players.FirstOrDefault(p=>p.AspNetId == aspNetId).Id;

            if (playerId == null)
            {
                throw new ArgumentException("Initialise: PlayerId cannot be null");
            }

            return (int)playerId;
        }

        private bool IsExistingPlayer(int? id)
        {
            var context = new StarWars3Context();
            return context.Players.Any(p=>p.Id == id);
        }
    }
}
