using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Grpc.Net.Client;
using GrpcServer;
using GrpcVdUnaryCallBanchmark.Models;

namespace GrpcVdUnaryCallBanchmark;

[MemoryDiagnoser]
public class MemoryBenchmarkDemo
{
    private static Weather.WeatherClient _grpcWeatherClient;
    private static HttpClient _client;
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        _grpcWeatherClient = new(GrpcChannel.ForAddress("http://localhost:5001"));
        _client = new();
    }
    
    [Benchmark]
    public WeatherResponse CallGrpcServer()
    {
        return _grpcWeatherClient.GetById(new WeatherRequest() { Id = 1 });
    }
    
    [Benchmark]
    public async Task<WeatherForecast?> CallHttpServer()
    {
        try
        {
            using HttpResponseMessage response = await _client.GetAsync("http://localhost:5000/weathers/1");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WeatherForecast>(responseBody);
        }
        catch (HttpRequestException)
        {
            return null;
        }    
    }
}