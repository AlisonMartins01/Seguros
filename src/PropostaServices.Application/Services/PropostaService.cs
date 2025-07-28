using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PropostaServices.Application.DTOs;
using PropostaServices.Application.Interfaces;
using PropostaServices.Application.Services.Interfaces;
using PropostaServices.Application.UseCases;
using PropostaServices.Domain.Entities;
using PropostaServices.Domain.Enums;

namespace PropostaServices.Application.Services
{
    public class PropostaService(IAlterarStatusPropostaUseCase alterarStatusPropostaUseCase, ICriarPropostaUseCase criarPropostaUseCase, IListarPropostasUseCase listarPropostasUseCase) : IPropostaService
    {
        public Task AlterarStatusAsync(Guid propostaId, StatusProposta novoStatus) => alterarStatusPropostaUseCase.ExecutarAsync(propostaId, novoStatus);
        public async Task<Guid> CriarPropostaAsync(CriarPropostaRequest dto) => await criarPropostaUseCase.ExecutarAsync(dto.Cliente, dto.Valor);
        public async Task<IEnumerable<PropostaResponse>> ListarPropostasAsync() => await listarPropostasUseCase.ExecutarAsync();
    }
}
