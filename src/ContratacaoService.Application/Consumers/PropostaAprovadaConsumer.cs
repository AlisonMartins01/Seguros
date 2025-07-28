using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassTransit;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Seguros.Contracts.Events;
using ContratacaoService.Application.Services.Interfaces;
using ContratacaoService.Application.Services;

namespace ContratacaoService.Application.Consumers
{
    public class PropostaAprovadaConsumer(IContratacaoService contratacaoService, ILogger<PropostaAprovadaConsumer> logger) : IConsumer<PropostaAprovadaEvent>
    {
        public async Task Consume(ConsumeContext<PropostaAprovadaEvent> context)
        {
            logger.LogInformation("Proposta recebida no ContratacaoService: {Id}", context.Message.PropostaId);

            await contratacaoService.ProcessarAsync(context.Message);
            await Task.CompletedTask;
        }
    }
}
