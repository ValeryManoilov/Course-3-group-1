using Microsoft.AspNetCore.Mvc;
using Practice15.Interfaces;
using Practice15.Services;

namespace Practice15.Controllers
{
    [ApiController]
    [Route("logs")]
    public class LogsController : ControllerBase
    {
        private readonly DatabaseLoggingManager _logs;

        public LogsController(DatabaseLoggingManager logs)
        {
            _logs = logs;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllLogs()
        {
            return Ok(_logs.GetAllLogs());
        }
    }
}
