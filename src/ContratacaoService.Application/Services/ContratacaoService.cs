using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Application.Interfaces;
using ContratacaoService.Application.Services.Interfaces;
using ContratacaoService.Application.UseCase;
using Microsoft.Extensions.Logging;
using Seguros.Contracts.Events;

namespace ContratacaoService.Application.Services
{
    public class ContratacaoService(IContratarPropostaUseCase contratarPropostaUseCase, ILogger<ContratacaoService> logger) : IContratacaoService
    {
        public async Task ProcessarAsync(PropostaAprovadaEvent proposta)
        {
            logger.LogInformation("Iniciando processo de contratação para a proposta {Id}", proposta.PropostaId);

            await contratarPropostaUseCase.ExecuteAsync(proposta);

            logger.LogInformation("Processo de contratação finalizado para a proposta {Id}", proposta.PropostaId);
        }
    }
}
