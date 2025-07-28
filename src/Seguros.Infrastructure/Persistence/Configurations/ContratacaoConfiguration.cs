using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Seguros.Infrastructure.Persistence.Configurations
{
    public class ContratacaoConfiguration : IEntityTypeConfiguration<Contratacao>
    {
        public void Configure(EntityTypeBuilder<Contratacao> builder)
        {
            builder.ToTable("Contratacoes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.PropostaId)
                .IsRequired();

            builder.Property(c => c.Cliente)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.DataContratacao)
                .IsRequired();
        }
    }
}
