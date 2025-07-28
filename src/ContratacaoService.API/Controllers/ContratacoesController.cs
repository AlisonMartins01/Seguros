using ContratacaoService.Application.DTOs;
using ContratacaoService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContratacaoService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratacoesController (IListarContratacoesUseCase listarContratacoesUseCase) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ContratacaoResponse>>> Get()
        {
            var contratacoes = await listarContratacoesUseCase.ExecuteAsync();
            return Ok(contratacoes);
        }
    }
}
