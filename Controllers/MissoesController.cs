using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpiderNetApi.Models;

namespace SpiderNetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissoesController : ControllerBase
    {
        private static List<MissaoAranha>_missao = new();

        [HttpGet]
        public ActionResult<IEnumerable<MissaoAranha>>Get()
        {
            return Ok(_missao);
        }
        [HttpPost]
        public IActionResult Post([FromBody]MissaoAranha novasMissoes)
        {
             if (novasMissoes.NivelPerigo < 1 || novasMissoes.NivelPerigo > 10)
        {
            return BadRequest("Nivel de perigo deve estar entre 1 e 10");
        }
            _missao.Add(novasMissoes);

            return CreatedAtAction(nameof(Get), new {id = novasMissoes.Id }, novasMissoes);
           
        }

        }
        
    }
