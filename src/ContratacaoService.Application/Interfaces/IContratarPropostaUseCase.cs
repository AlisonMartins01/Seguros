using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguros.Contracts.Events;

namespace ContratacaoService.Application.Interfaces
{
    public interface IContratarPropostaUseCase
    {
        Task ExecuteAsync(PropostaAprovadaEvent proposta);
    }
}
