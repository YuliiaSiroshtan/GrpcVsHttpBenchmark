using Microsoft.AspNetCore.Mvc;

namespace HttpServer.Controllers;

[ApiController]
[Route("weathers")]
public class WeatherController : ControllerBase
{
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet("{id:int}")]
    public WeatherForecast GetById([FromRoute] int id)
    {
        return new WeatherForecast
            {
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
    }
}