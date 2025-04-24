using System.Reflection;
using Mapster;

namespace DynamicFlow.Service.Common.Configs
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);
            //string[] assemblyNames = ["Module.Flow.Core"];
            //foreach (var assembly in assemblyNames)
            //{
            //    Assembly referencedAssembly = Assembly.Load(assembly);
            //    var types = referencedAssembly.GetTypes().Where(type => type.GetInterfaces().Contains(typeof(IRegister)));
            //    foreach (var type in types)
            //    {
            //        var instance = Activator.CreateInstance(type) as IRegister;
            //        instance?.Register(TypeAdapterConfig.GlobalSettings);
            //    }
            //}
        }
    }
}
