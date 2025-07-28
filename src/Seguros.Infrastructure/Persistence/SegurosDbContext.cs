using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PropostaServices.Domain.Entities;

namespace Seguros.Infrastructure.Persistence
{
    public class SegurosDbContext : DbContext
    {
        public SegurosDbContext(DbContextOptions<SegurosDbContext> options) : base(options) { }
       
        public DbSet<Proposta> Propostas => Set<Proposta>();
        public DbSet<Contratacao> Contratacoes => Set<Contratacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SegurosDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
