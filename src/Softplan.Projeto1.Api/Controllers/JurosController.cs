using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Softplan.Projeto1.Api.Model;

namespace Softplan.Projeto1.Api.Controllers
{
    [ApiController]
    [Route("api/juros")]
    public class JurosController : ControllerBase
    {
        [HttpGet("taxajuros")]
        public IActionResult Get()
        {
            return Ok(new Juros() { Taxa = 0.01 });
        }
    }
}
