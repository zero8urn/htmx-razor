namespace HtmxRazorComponents.Models;

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public static string GetWeatherSummary(int index) => new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild"
    }[index];
}


public class WeatherViewModel
{
    public IEnumerable<WeatherForecast> Forecasts { get; set; } = [];
}
