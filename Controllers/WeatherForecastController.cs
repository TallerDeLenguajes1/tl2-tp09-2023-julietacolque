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
        Tablero tabl = new(){
        Nombre="modificado",
        Descripcion = "descripcion",
        IdUsuarioPropietario = 1
        };
        var tableroR = new TableroRepository();
        tableroR.Update(1,tabl);
        var tableroPerri = tableroR.GetById(4);
        // Console.WriteLine(tableroPerri.Nombre);
        // Console.WriteLine(tableroR.GetAll().Count);
        var listaT = tableroR.GetByUser(1);
        Console.WriteLine(listaT.Count);
       

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


//  var usuarioR = new UsuarioRepository();
//         var user = new Usuario();
//         user.NombreUsuario = "florDespues";
//         usuarioR.Update(2, user);
//         var listaU = usuarioR.GetAll();
//         Console.WriteLine(listaU[0].NombreUsuario);
//         Console.WriteLine(usuarioR.GetById(2).NombreUsuario);
//         usuarioR.Remove(2);