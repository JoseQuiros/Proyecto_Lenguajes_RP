using Microsoft.AspNetCore.Mvc;

namespace APILab.Controllers
{
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
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("[action]/{date}")]///Weatherforcadst/GetByDate
        [HttpGet]
        public WeatherForecast getByDate(DateTime date)
        {
            var range = new Random();
            return new WeatherForecast
            {
                Date = date,
                TemperatureC = range.Next(-20, 55),
                Summary = Summaries[range.Next(Summaries.Length)]
            };

        }
        [Route("[action]")]///weTHERfORECAST/POST
        [HttpPost]
        public WeatherForecast Post(WeatherForecast weatherForecast)
        {
            List<WeatherForecast> list = new List<WeatherForecast>();
            list.Add(weatherForecast);
            return weatherForecast;
        }
        [Route("[action]")]///weTHERfORECAST/POST
        [HttpPut]
        public WeatherForecast Put(DateTime date,WeatherForecast weatherForecast)
        {
            List<WeatherForecast> list = new List<WeatherForecast>();
            list.Add(weatherForecast);
            return weatherForecast;
        }


        /////////implemnetar el metodo pash
        ///orm es un mapeador relacional de los objetos 
        ///data entity framework core
        ///DTO
    }
}