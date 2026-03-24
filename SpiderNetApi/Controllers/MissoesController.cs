using Microsoft.AspNetCore.Mvc;
using SpiderNetApi.Models;

namespace SpiderNetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissoesController : ControllerBase
    {
        private static List<MissaoAranha> missoes = new List<MissaoAranha>();

        [HttpGet]
        public ActionResult<List<MissaoAranha>> Get()
        {
            return Ok(missoes);
        }

        [HttpPost]
        public ActionResult Post([FromBody] MissaoAranha novaMissao)
        {
            if (novaMissao.NivelPerigo < 1 || novaMissao.NivelPerigo > 10)
            {
                return BadRequest("O nível de perigo deve estar entre 1 e 10.");
            }

            missoes.Add(novaMissao);

            return CreatedAtAction(nameof(Get), novaMissao);
        }
    }
}
