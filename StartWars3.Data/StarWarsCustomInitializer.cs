namespace StartWars3.Data
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using StarWars3.Data;
    using StarWars3.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Web;

    public class StarWarsCustomInitializer
        : CreateDatabaseIfNotExists<StarWars3Context>
    {
        protected override void Seed(StarWars3Context context)
        {
            string pathFighters = HttpContext.Current.Server.MapPath("~/App_Data/fighters.csv");

            SeedAccountsAndRoles(context);
            SeedPlanets(context);
            SeedFighterLevels(context, pathFighters);

            base.Seed(context);
        }

        public void SeedPlanets(IStarWars3Context context)
        {
            PlanetTemplate planetTemplate = new PlanetTemplate()
            {
                IsTaken = false,
                Name = "Tatuin-1",

                Locations = new List<Cell>()
                {
                    new Cell(){row =2,col =2},
                    new Cell(){row =2, col=3},
                    new Cell(){row =3,col =1},
                    new Cell(){row =3, col=2},
                    new Cell(){row =3,col =3},
                    new Cell(){row =4, col=2},
                    new Cell(){row =4, col=3},
                },              
            };

            context.PlanetTemplates.Add(planetTemplate);
        }

        public void SeedFighterLevels(IStarWars3Context context, string path)
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
                    Damage = int.Parse(data[3]),
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

        public void SeedAccountsAndRoles(StarWars3Context context)
        {
            if (!context.Roles.Any())
            {
                this.CreateRole(context, "Admin");
                this.CreateRole(context, "User");
            }

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                this.CreateRole(context, "Admin");
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                this.CreateRole(context, "User");
            }

            if (!context.Users.Any())
            {
                this.CreateUser(context, "admin@admin.com", "123");
                this.SetRoleToUser(context, "admin@admin.com", "Admin");
            }
        }

        private void CreateRole(StarWars3Context context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var result = roleManager.Create(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(StarWars3Context context, string email, string password)
        {
            // Create user manager
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Set user manager password validator
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            // Create user object
            var admin = new ApplicationUser()
            {
                UserName = email,
                Email = email,            
            };

            // Create user
            var result = userManager.Create(admin, password);

            // Validate result
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void SetRoleToUser(StarWars3Context context, string email, string role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = context.Users.Where(u => u.Email == email).First();

            var result = userManager.AddToRole(user.Id, role);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }
    }
}
