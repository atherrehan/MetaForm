using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SME.DynamicFlow.TestUI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();
SME.DynamicFlow.UI.AppConfig.BaseUrl = "http://localhost:5268/";//http://10.38.38.166:8027/ Change accordingly in DynamicFlow DB Baseurl
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
