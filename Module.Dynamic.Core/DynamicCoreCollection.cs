using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Module.Dynamic.Core.Services;

namespace Module.Dynamic.Core
{
    public static class DynamicCoreCollection
    {
        public static IServiceCollection AddDynamicCoreCollection(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IDynamicService, DynamicService>();
            return services;
        }
    }
}
