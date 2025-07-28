using Microsoft.AspNetCore.Mvc;
using PropostaServices.Application.DTOs;
using PropostaServices.Application.Services.Interfaces;
using PropostaServices.Application.UseCases;

namespace PropostaServices.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropostasController(IPropostaService propostaService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarPropostaRequest request)
        {
            var resposta = await propostaService.CriarPropostaAsync(request);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropostaResponse>>> Listar()
        {
            var resposta = await propostaService.ListarPropostasAsync();
            return Ok(resposta);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> AlterarStatus(Guid id, [FromBody] AlterarStatusPropostaRequest request)
        {
            await propostaService.AlterarStatusAsync(id, request.NovoStatus);
            return Ok();
        }
    }
}
