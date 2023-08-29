using Grpc.Core;

namespace GrpcServer.Services;

public class WeatherService : Weather.WeatherBase
{
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public override Task<WeatherResponse> GetById(WeatherRequest request, ServerCallContext context)
    {
        return Task.FromResult(new WeatherResponse
        {
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
    }
}