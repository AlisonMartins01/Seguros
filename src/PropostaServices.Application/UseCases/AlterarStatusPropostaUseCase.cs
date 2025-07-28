using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaServices.Application.Interfaces;
using PropostaServices.Domain.Entities;
using MassTransit;
using PropostaServices.Domain.Enums;
using PropostaServices.Domain.Interfaces;
using Seguros.Contracts.Events;

namespace PropostaServices.Application.UseCases
{
    public class AlterarStatusPropostaUseCase (IPropostaRepository  repository, IPublishEndpoint publishEndpoint) : IAlterarStatusPropostaUseCase
    {
        public async Task<bool> ExecutarAsync(Guid id, StatusProposta novoStatus)
        {
            var proposta = await repository.ObterPorIdAsync(id);
            if (proposta is null)
                return false;

            if (!PodeAlterarStatus(proposta.Status, novoStatus))
                throw new InvalidOperationException("Só é possível alterar o status de propostas que estão em análise e para status válidos.");

            AplicarStatus(proposta, novoStatus);
            await repository.AtualizarAsync(proposta);

            if (novoStatus == StatusProposta.Aprovada)
            {
                await publishEndpoint.Publish(new PropostaAprovadaEvent
                {
                    PropostaId = proposta.Id,
                    Cliente = proposta.Cliente,
                    Valor = proposta.Valor
                });
            }

            return true;
        }
        private static bool PodeAlterarStatus(StatusProposta atual, StatusProposta novo)
        {
            return atual == StatusProposta.EmAnalise && novo != StatusProposta.EmAnalise;
        }

        private static void AplicarStatus(Proposta proposta, StatusProposta novoStatus)
        {
            switch (novoStatus)
            {
                case StatusProposta.Aprovada:
                    proposta.Aprovar();
                    break;
                case StatusProposta.Rejeitada:
                    proposta.Rejeitar();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(novoStatus), $"Status inválido: {novoStatus}");
            }
        }
    }
}
