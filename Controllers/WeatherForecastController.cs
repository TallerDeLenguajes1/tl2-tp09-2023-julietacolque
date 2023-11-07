using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
namespace tl2_tp09_2023_julietacolque.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        var usuarioR = new UsuarioRepository();
        var user = new Usuario();
        user.NombreUsuario = "florDespues";
        usuarioR.Update(2, user);
        var listaU = usuarioR.GetAll();
        Console.WriteLine(listaU[0].NombreUsuario);
        Console.WriteLine(usuarioR.GetById(2).NombreUsuario);
        usuarioR.Remove(2);

    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
