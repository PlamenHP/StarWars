namespace StartWars3.Data
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using StarWars3.Data;
    using StarWars3.Models;
    using System;
    using System.Data.Entity;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Web;

    public class StarWarsCustomInitializer
        : CreateDatabaseIfNotExists<StarWars3Context>
    {
        protected override void Seed(StarWars3Context context)
        {
            string pathFighters = HttpContext.Current.Server.MapPath("~/App_Data/fighters.csv");
            SeedFighterLevels(context, pathFighters);

            SeedAccountsAndRoles(context);

            string pathMetalFactory = "~/App_Data/robo_sc2.png";
            string pathGasFactory = "~/App_Data/commandement_sc2.png";
            string pathMineralsFactory = "~/App_Data/gateway_sc2.png";
            string pathFighter = "~/App_Data/phoenix_sc2.png";
            string pathDestroyer = "~/App_Data/carrier_sc2.png";
            string pathPlanet = "~/App_Data/greenplanet.png";

            ToByteArrayImage(context, pathMetalFactory, "MetalFactory", 50, 50);
            ToByteArrayImage(context, pathGasFactory, "GasFactory", 50, 50);
            ToByteArrayImage(context, pathMineralsFactory, "MineralsFactory", 50, 50);
            ToByteArrayImage(context, pathFighter, "Fighter", 50, 50);
            ToByteArrayImage(context, pathDestroyer, "Destroyer", 50, 50);
            ToByteArrayImage(context, pathPlanet, "Planet", 50, 50);

            base.Seed(context);
        }

        public void ToByteArrayImage(
            StarWars3Context context,
            string str,
            string name,
            int width,
            int height)
        {
            string path = HttpContext.Current.Server.MapPath(str);

            var stream = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read
            );

            var image = System.Drawing.Image.FromStream(stream, true, true);

            context.Images.Add(new StarWars3.Models.Image
            {
                Name = name,
                Container = ResizeImage(image, width, height)
            });
        }

        public byte[] ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(destImage, typeof(byte[]));
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
