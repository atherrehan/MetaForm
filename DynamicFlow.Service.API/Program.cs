using DynamicFlow.Service.Common.Configs;
using Module.Dynamic;
using DynamicFlow.Service.Common;
using DynamicFlow.Service.Common.Generic;
using DynamicFlow.Service.Common.Service.Interfaces;
using DynamicFlow.Service.Common.Service;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddDistributedMemoryCache();
services.AddCommonService(builder.Configuration);
services.Configure<CacheConfiguraiton>(builder.Configuration.GetSection("CacheTimeConfig"));
services.Configure<ServiceDatabaseConnection>(builder.Configuration.GetSection("ConnectionString"));
services.AddModuleDynamic(builder.Configuration);
MapsterConfig.RegisterMappings();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
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


