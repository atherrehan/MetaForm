using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Dynamic.Core;
using Module.Dynamic.Infrastructure;

namespace Module.Dynamic
{
    public static class DynamicCollection
    {
        public static IServiceCollection AddModuleDynamic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDynamicCoreCollection().AddDynamicInfrastructureCollection(configuration);
            return services;
        }
    }
}
