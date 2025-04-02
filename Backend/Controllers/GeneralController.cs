namespace Backend.Controllers;

using Backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class GeneralController : ControllerBase
{

    private readonly IEnumerable<string> summaries = new List<string>()
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    [HttpGet("GetAllWeatherForecase")]
    public ActionResult<IEnumerable<WeatherForecast>> GetAllWeatherForecase()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries.ElementAt(Random.Shared.Next(summaries.Count()))
        ))
        .ToList();
        return forecast;
    }
}