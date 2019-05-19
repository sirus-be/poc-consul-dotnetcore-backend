using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Sirus.Poc.Consul.Backend.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return $"Path = {Environment.GetEnvironmentVariable("path")}";
        }
    }
}
