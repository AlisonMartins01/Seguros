using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Domain.Entities;
using ContratacaoService.Domain.Repository;
using ContratacaoService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ContratacaoService.Infrastructure.Repository
{
    public class ContratacaoRepository : IContratacaoRepository
    {
        private readonly ContratacaoDbContext _context;

        public ContratacaoRepository(ContratacaoDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Contratacao contratacao)
        {
            _context.Contratacoes.Add(contratacao);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Contratacao>> ListarTodasAsync()
        {
            return await _context.Contratacoes.ToListAsync();
        }
    }
}
