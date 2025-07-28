using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropostaServices.Domain.Entities;

namespace PropostaServices.Infrastructure.Persistence
{
    public class PropostaDbContext : DbContext
    {
        public PropostaDbContext(DbContextOptions<PropostaDbContext> options) : base(options) { }

        public DbSet<Proposta> Propostas => Set<Proposta>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PropostaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
