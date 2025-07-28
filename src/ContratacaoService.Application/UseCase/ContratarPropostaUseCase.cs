using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguros.Contracts.Events;
using ContratacaoService.Domain.Repository;
using ContratacaoService.Domain.Entities;
using ContratacaoService.Application.Interfaces;


namespace ContratacaoService.Application.UseCase
{
    public class ContratarPropostaUseCase(IContratacaoRepository contratacaoRepository) : IContratarPropostaUseCase
    {
        public async Task ExecuteAsync(PropostaAprovadaEvent proposta)
        {
            var contratacao = new Contratacao(proposta.PropostaId, proposta.Cliente, proposta.Valor);
            await contratacaoRepository.AdicionarAsync(contratacao);
        }
    }
}
