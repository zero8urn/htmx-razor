using HtmxRazorComponents.Components;
using HtmxRazorComponents.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents();

builder.Services.AddScoped<HtmlRenderer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAntiforgery();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store");
            ctx.Context.Response.Headers.Append("Expires", "-1");
        }
    });
}
else
{
    app.UseStaticFiles();
}



app.MapRazorPages();

app.MapRazorComponents<HtmxRazorComponents.App>();


app.MapGet("/weather", () =>
{
    var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = WeatherForecast.GetWeatherSummary(Random.Shared.Next(0, 4))
    });

    WeatherViewModel weatherViewModel = new()
    {
        Forecasts = forecasts
    };

    // This works from within aspnet core.
    // If you needed to render a component into html from a console app, you would need to use the HtmlRenderer class.
    return new RazorComponentResult<Weather>(weatherViewModel);
});

app.MapGet("/clicked", ([FromServices] HtmlRenderer htmlRenderer) =>
{
    var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = WeatherForecast.GetWeatherSummary(Random.Shared.Next(0, 4))
    });

    WeatherViewModel weatherViewModel = new()
    {
        Forecasts = forecasts
    };

    // This works from within aspnet core.
    // If you needed to render a component into html from a console app, you would need to use the HtmlRenderer class.
    return new RazorComponentResult<Weather>(weatherViewModel);
});

app.Run();
