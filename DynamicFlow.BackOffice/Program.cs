using DynamicFlow.BackOffice.Config;
using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.Models.Generic;
using DynamicFlow.BackOffice.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<DatabaseConnection>(builder.Configuration.GetSection("ConnectionString"));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IService, Service>();
MapsterConfig.RegisterMapping();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
