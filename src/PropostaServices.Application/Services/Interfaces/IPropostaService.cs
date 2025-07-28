using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaServices.Application.DTOs;
using PropostaServices.Domain.Enums;

namespace PropostaServices.Application.Services.Interfaces
{
    public interface IPropostaService
    {
        Task<Guid> CriarPropostaAsync(CriarPropostaRequest dto);
        Task AlterarStatusAsync(Guid propostaId, StatusProposta novoStatus);
        Task<IEnumerable<PropostaResponse>> ListarPropostasAsync();
    }
}
