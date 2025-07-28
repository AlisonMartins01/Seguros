using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Application.DTOs;
using ContratacaoService.Application.Interfaces;
using ContratacaoService.Domain.Repository;

namespace ContratacaoService.Application.UseCase
{
    public class ListarContratacoesUseCase(IContratacaoRepository contratacaoRepository) : IListarContratacoesUseCase
    {
        public async Task<List<ContratacaoResponse>> ExecuteAsync()
        {
            var contratacoes = await contratacaoRepository.ListarTodasAsync();

            return contratacoes.Select(c => new ContratacaoResponse
            {
                Id = c.Id,
                PropostaId = c.PropostaId,
                Cliente = c.Cliente,
                Valor = c.Valor,
                DataContratacao = c.DataContratacao
            }).ToList();
        }
    }
}
