using System;
using Microsoft.AspNetCore.Mvc;

namespace QIQO.Business.Api.Controllers
{
    [Route("api/[controller]")]
    public class HeartbeatController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DateTime.Now);
        }
    }
}
