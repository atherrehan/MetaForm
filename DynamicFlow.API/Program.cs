using DynamicFlow.API.Core.Service.Interfaces;
using DynamicFlow.API.Core.Service;
using DynamicFlow.Service.Common.Generic;
using System.Reflection;
using DynamicFlow.API.Infrastructure.DbContext;
using DynamicFlow.Service.Common.Service.Interfaces;
using DynamicFlow.Service.Common.Service;
using DynamicFlow.Service.Common.Configs;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

services.AddDistributedMemoryCache();  // Must be before CacheService


services.Configure<CacheConfiguraiton>(builder.Configuration.GetSection("CacheTimeConfig"));
services.Configure<ServiceDatabaseConnection>(builder.Configuration.GetSection("ConnectionString"));
services.AddScoped<IDynamicService, DynamicService>();
services.AddScoped<IDynamicDbContext, DynamicDbContext>();
services.AddScoped<ICacheService, CacheService>(); // Register BEFORE MediatR

MapsterConfig.RegisterMappings();

services.AddControllers();
services.AddOpenApi();
services.AddSwaggerGen();
services.AddOpenApi();

var app = builder.Build();

app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(o =>
    {
        o.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

app.MapControllers();
app.Run();
