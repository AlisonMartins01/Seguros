using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaServices.Domain.Entities;

namespace PropostaServices.Domain.Interfaces
{
    public interface IPropostaRepository
    {
        Task<IEnumerable<Proposta>> ListarAsync();
        Task<Proposta?> ObterPorIdAsync(Guid id);
        Task CriarAsync(Proposta proposta);
        Task AtualizarAsync(Proposta proposta);
    }
}
