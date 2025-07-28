using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaServices.Application.DTOs;
using PropostaServices.Application.Interfaces;
using PropostaServices.Domain.Entities;
using PropostaServices.Domain.Interfaces;

namespace PropostaServices.Application.UseCases
{
    public class ListarPropostasUseCase(IPropostaRepository propostaRepository) : IListarPropostasUseCase
    {
        public async Task<IEnumerable<PropostaResponse>> ExecutarAsync()
        {
            var propostas = await propostaRepository.ListarAsync();
            
            return propostas.Select(p => new PropostaResponse
            {
                Id = p.Id,
                Cliente = p.Cliente,
                Valor = p.Valor,
                Status = p.Status.ToString(),
                DataCriacao = p.DataCriacao
            });
        }
    }
}
