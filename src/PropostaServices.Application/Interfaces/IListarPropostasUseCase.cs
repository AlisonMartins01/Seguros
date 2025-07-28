using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaServices.Application.DTOs;
using PropostaServices.Domain.Entities;

namespace PropostaServices.Application.Interfaces
{
    public interface IListarPropostasUseCase
    {
        Task<IEnumerable<PropostaResponse>> ExecutarAsync();
    }
}
