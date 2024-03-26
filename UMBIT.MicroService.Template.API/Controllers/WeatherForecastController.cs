using Microsoft.AspNetCore.Mvc;
using System;
using UMBIT.MicroService.Template.Contract;

namespace UMBIT.MicroService.Template.API.Controllers
{
    public class WeatherForecastController : WeatherForecastControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        public override async Task<ActionResult<ICollection<Contract.WeatherForecast>>> GetWeatherForecast()
        {
            var result =  Enumerable.Range(1, 5).Select(index => {

                var date = System.DateOnly.FromDateTime(DateTime.Now.AddDays(index));

                return new Contract.WeatherForecast
                {
                    Date = new Contract.DateOnly()
                    {
                        Day = date.Day,
                },
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            }).ToArray();

            return result;
        }
    }
}
