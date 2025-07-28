using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContratacaoService.Domain.Entities;

namespace ContratacaoService.Infrastructure.Persistence.Configurations
{
    public class ContratacaoConfiguration : IEntityTypeConfiguration<Contratacao>
    {
        public void Configure(EntityTypeBuilder<Contratacao> builder)
        {
            builder.ToTable("Contratacoes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.PropostaId)
                .IsRequired();

            builder.Property(c => c.Cliente)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.DataContratacao)
                .IsRequired();
        }
    }
}
