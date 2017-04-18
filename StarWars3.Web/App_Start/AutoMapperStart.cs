
namespace StarWars3.Web.App_Start
{
    using StarWars3.Infrastructure.Mapping;
    using System.Reflection;

    public class AutoMapperStart
    {
        public static void RegisterAllMappings()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}