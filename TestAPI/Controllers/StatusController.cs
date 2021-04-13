using Microsoft.AspNetCore.Mvc;
using System;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetStatus()
        {
            return $"true {DateTime.Now}";
        }
    }
}
