namespace StarWars3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new StarWars3Context();
            context.Database.Initialize(true);

            //AddData(context);
        }

        private static void AddData(StarWars3Context context)
        {
            context.Factories.Add(new Factory(FactoryType.GasFactory)
            {
                Health = 100,
                Level = 0
            });

            context.SaveChanges();
        }
    }
}
