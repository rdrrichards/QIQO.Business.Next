using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace QIQO.Business.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StatsController : Controller
    {
        private readonly ILogger<StatsController> _log;
        private readonly IStatsService _statsService;

        public StatsController(ILogger<StatsController> logger, IStatsService statsService)
        {
            _log = logger;
            _statsService = statsService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            _log.LogInformation($"Stats get called @ {DateTime.Now}");
            var stats = _statsService.Measures.Select(m => new { m.Key, m.Value.Occurences.Count }).ToArray();
            return Ok(stats);
        }
    }
}
