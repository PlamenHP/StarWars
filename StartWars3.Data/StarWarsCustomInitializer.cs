namespace StartWars3.Data
{
    using StarWars3.Data;
    using StarWars3.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public class StarWarsCustomInitializer
        : CreateDatabaseIfNotExists<StarWars3Context>
    {
        protected override void Seed(StarWars3Context context)
        {
            string pathFighters = HttpContext.Current.Server.MapPath("~/App_Data/fighters.csv");
            SeedFighterLevels(context, pathFighters);

            base.Seed(context);
        }

        public static void SeedFighterLevels(IStarWars3Context context, string path)
        {
            string[] fighters = File.ReadAllLines(path);

            for (int i = 1; i < fighters.Length; i++)
            {
                string[] data = fighters[i]
                    .Split(',')
                    .Select(arg => arg.Replace("\"", string.Empty))
                    .ToArray();

                UnitLevel fighter = new UnitLevel
                {
                    Name = data[0],
                    Type = (UnitType)int.Parse(data[1]),
                    Level = int.Parse(data[2]),
                    Atack = int.Parse(data[3]),
                    Shield = int.Parse(data[4]),
                    Armor = int.Parse(data[5]),
                    Health = int.Parse(data[6]),
                    Speed = int.Parse(data[7]),
                    FuelConsumption = int.Parse(data[8]),
                };

                //context.UnitLevels.AddOrUpdate(a =>
                //  new { a.Name, a.Level, ... },
                //  fighter);

                context.UnitLevels.Add(fighter);
            }
            context.SaveChanges();
        }
    }
}
