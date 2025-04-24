using System.Text.Json;
using DynamicFlow.Models.Generic;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddSingleton(new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
});
services.Configure<DatabaseConnection>(builder.Configuration.GetSection("ConnectionString"));
services.Configure<CacheConfigurations>(builder.Configuration.GetSection("CacheTimeConfig"));
//services.AddScoped<IHttpClientService, HttpClientService>();
//services.AddScoped<IFlowRepositoryService, FlowRepositoryService>();
// Add services to the container.
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddHttpClient("client", client =>
{
    client.Timeout = TimeSpan.FromSeconds(60);
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//app.UseMiddleware<ExceptionMiddleware>();
app.Run();
