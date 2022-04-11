using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Softplan.Projeto2.Api.Interface;
using Softplan.Projeto2.Api.Service;

namespace Softplan.Projeto2.Api.Controllers
{
    [ApiController]
    [Route("api/juros")]
    public class JurosController : ControllerBase
    {
        private readonly IJurosService _jurosService;

        public JurosController(IJurosService jurosService)
        {
            _jurosService = jurosService;
        }

        [HttpGet("calculajuros")]
        public IActionResult Get([FromQuery] decimal valorInicial, int tempo)
        {
            try
            {
                var valorFinal = _jurosService.CalculaJuros(valorInicial, tempo);

                return Ok(valorFinal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("showmethecode")]
        public IActionResult Get()
        {
            return Ok("https://github.com/fabiosoares-net/softplan.api");
        }
    }
}
