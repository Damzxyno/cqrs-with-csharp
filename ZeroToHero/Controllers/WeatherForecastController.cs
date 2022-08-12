using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZeroToHero.Handlers.Queries;

namespace ZeroToHero.Controllers
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
        //public readonly IMediator _mediator;
        private IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            //_mediator = HttpContext.RequestServices.GetService<IMediator>();
        }

        [HttpGet("bwest")]
        public IActionResult Get()
        {
            _logger.LogInformation("I don arrive");
            var rng = new Random();
            return Ok(Enumerable.Range(2, 6).Select(index => new 
            {
                Index = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray());
        }

        [HttpGet("Book")]
        public IActionResult GetBooks()
        {

            var query = new BookQuery();
            var result = _mediator.Send(query);
            return Ok(result);
        }
    }
}
