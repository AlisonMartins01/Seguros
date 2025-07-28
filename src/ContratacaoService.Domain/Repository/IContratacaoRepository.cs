using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Domain.Entities;

namespace ContratacaoService.Domain.Repository
{
    public interface IContratacaoRepository
    {
        Task AdicionarAsync(Contratacao contratacao);
        Task<List<Contratacao>> ListarTodasAsync();
    }
}
