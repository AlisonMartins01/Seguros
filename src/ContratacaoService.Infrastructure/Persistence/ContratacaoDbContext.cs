using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Domain.Entities;
using ContratacaoService.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ContratacaoService.Infrastructure.Persistence
{
    public class ContratacaoDbContext : DbContext
    {
        public ContratacaoDbContext(DbContextOptions<ContratacaoDbContext> options) : base(options) { }

        public DbSet<Contratacao> Contratacoes => Set<Contratacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContratacaoDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
