
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

                //Factory gasFactory = new Factory()
                //{
                //    FactoryType = FactoryType.GasFactory,
                //    Health = Constants.GasFactoryHealth,
                //    Level = Constants.DefaultFactoryLevel
                //};

                //Factory metalFactory = new Factory()
                //{
                //    FactoryType = FactoryType.MetalFactory,
                //    Health = Constants.MetalFactoryHealth,
                //    Level = Constants.DefaultFactoryLevel
                //};

                //Factory mineralsFactory = new Factory()
                //{
                //    FactoryType = FactoryType.MineralsFactory,
                //    Health = Constants.MineralsFactoryHealth,
                //    Level = Constants.DefaultFactoryLevel
                //};

                //Factory warFactory = new Factory()
                //{
                //    FactoryType = FactoryType.WarFactory,
                //    Health = Constants.WarFactoryHealth,
                //    Level = Constants.DefaultFactoryLevel
                //};

                //EngineeringFactory engineeringFactory = new EngineeringFactory()
                //{
                //    FactoryType = FactoryType.EngineeringFactory,
                //    Health = Constants.EngineeringFactoryHealth,
                //    Level = Constants.DefaultFactoryLevel
                //};

                Planet planet = new Planet()
                {
                    Name = "Earth",
                };

                if (PlayerService.IfNoOtherPlayers(context))
                {
                    planet.Locations = new List<Cell>()
                    {
                        new Cell() { row = 1,col =1},
                        new Cell() { row = 1,col =2},
                        new Cell() { row = 2,col =1},
                        new Cell() { row = 2,col =2},
                        new Cell() { row = 2,col =3},
                        new Cell() { row = 3,col =1},
                        new Cell() { row = 3,col =2},
                    };
                }
                else
                {
                    int r = 10;
                    int c = 10;
                    planet.Locations = new List<Cell>()
                    {
                        new Cell() { row = 1+r,col =1+c},
                        new Cell() { row = 1+r,col =2+c},
                        new Cell() { row = 2+r,col =1+c},
                        new Cell() { row = 2+r,col =2+c},
                        new Cell() { row = 2+r,col =3+c},
                        new Cell() { row = 3+r,col =1+c},
                        new Cell() { row = 3+r,col =2+c},
                    };
                }

                if (context.Maps.All().FirstOrDefault()?.Id ==null)
                {
                    context.Maps.Add(new Map()
                    {
                        Rows = 16,
                        Cols = 20,
                        Name = "Rogue One"
                    });
                    context.SaveChanges();
                }

                context.Players.Add(new Player()
                {
                    AspNetId = aspNetId,
                    Planets = new[] { planet },
                    MapId = context.Maps.All().FirstOrDefault().Id,
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
