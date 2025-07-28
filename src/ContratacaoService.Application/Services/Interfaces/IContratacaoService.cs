using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguros.Contracts.Events;

namespace ContratacaoService.Application.Services.Interfaces
{
    public interface IContratacaoService
    {
        Task ProcessarAsync(PropostaAprovadaEvent proposta);
    }
}
