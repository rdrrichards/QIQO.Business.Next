using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace QIQO.Business.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HeartbeatController : Controller
    {
        private readonly ILogger<HeartbeatController> _log;

        public HeartbeatController(ILogger<HeartbeatController> logger)
        {
            _log = logger;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            _log.LogInformation($"Heartbeat called @ {DateTime.Now}");
            return Ok(DateTime.Now);
        }
    }
}
