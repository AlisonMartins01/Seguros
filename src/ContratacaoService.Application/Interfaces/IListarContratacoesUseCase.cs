using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Application.DTOs;

namespace ContratacaoService.Application.Interfaces
{
    public interface IListarContratacoesUseCase
    {
        Task<List<ContratacaoResponse>> ExecuteAsync();
    }
}
