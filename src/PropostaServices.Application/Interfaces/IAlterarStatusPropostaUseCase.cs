using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaServices.Domain.Enums;

namespace PropostaServices.Application.Interfaces
{
    public interface IAlterarStatusPropostaUseCase
    {
        Task<bool> ExecutarAsync(Guid id, StatusProposta novoStatus);
    }
}
