using DynamicFlow.Service.Common.Generic;
using DynamicFlow.Service.Common.Service;
using DynamicFlow.Service.Common.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicFlow.Service.Common
{
    public static class CommonCollection
    {
        public static IServiceCollection AddCommonService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICacheService, CacheService>();

            return services;
        }
    }
}
