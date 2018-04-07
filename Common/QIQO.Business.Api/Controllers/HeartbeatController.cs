using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace QIQO.Business.Api.Controllers
{
    [Route("api/[controller]")]
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
