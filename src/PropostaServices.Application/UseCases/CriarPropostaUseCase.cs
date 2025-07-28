using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaServices.Application.Interfaces;
using PropostaServices.Domain.Entities;
using PropostaServices.Domain.Interfaces;

namespace PropostaServices.Application.UseCases
{
    public class CriarPropostaUseCase(IPropostaRepository propostaRepository) : ICriarPropostaUseCase
    {
        public async Task<Guid> ExecutarAsync(string cliente, decimal valor)
        {
            var proposta = new Proposta(cliente, valor);
            await propostaRepository.CriarAsync(proposta);
            return proposta.Id;
        }
    }
}
