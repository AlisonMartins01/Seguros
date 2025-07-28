using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PropostaServices.Domain.Interfaces;
using PropostaServices.Infrastructure.Persistence;

namespace PropostaServices.Infrastructure.Repository
{
    public class PropostaRepository(PropostaDbContext context) : IPropostaRepository
    {
        public async Task CriarAsync(Proposta proposta)
        {
            await context.Propostas.AddAsync(proposta);
            await context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Proposta proposta)
        {
            context.Propostas.Update(proposta);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Proposta>> ListarAsync()
        {
            return await context.Propostas.ToListAsync();
        }

        public async Task<Proposta?> ObterPorIdAsync(Guid id)
        {
            return await context.Propostas.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
