using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Dynamic.Infrastructure.DbContext;

namespace Module.Dynamic.Infrastructure
{
    public static class DynamicInfrastructureCollection
    {
        public static IServiceCollection AddDynamicInfrastructureCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDynamicDbContext, DynamicDbContext>();
            return services;
        }
    }
}
