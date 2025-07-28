using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaServices.Application.Interfaces
{
    public interface ICriarPropostaUseCase
    {
        Task<Guid> ExecutarAsync(string cliente, decimal valor);
    }
}
