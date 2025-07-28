using Xunit;
using System;
using PropostaServices.Domain.Entities;
using PropostaServices.Domain.Enums;

namespace PropostaServices.Tests.Domain
{
    public class PropostaTests
    {
        [Fact]
        public void Construtor_DeveInicializarComStatusEmAnalise()
        {
            // Arrange & Act
            var proposta = new Proposta("Cliente Exemplo", 1500m);

            // Assert
            Assert.Equal("Cliente Exemplo", proposta.Cliente);
            Assert.Equal(1500m, proposta.Valor);
            Assert.Equal(StatusProposta.EmAnalise, proposta.Status);
            Assert.NotEqual(Guid.Empty, proposta.Id);
        }

        [Fact]
        public void Aprovar_DeveAlterarStatusParaAprovada()
        {
            // Arrange
            var proposta = new Proposta("Cliente", 2000m);

            // Act
            proposta.Aprovar();

            // Assert
            Assert.Equal(StatusProposta.Aprovada, proposta.Status);
        }

        [Fact]
        public void Rejeitar_DeveAlterarStatusParaRejeitada()
        {
            // Arrange
            var proposta = new Proposta("Cliente", 2000m);

            // Act
            proposta.Rejeitar();

            // Assert
            Assert.Equal(StatusProposta.Rejeitada, proposta.Status);
        }

        [Fact]
        public void MarcarEmAnalise_DeveAlterarStatusParaEmAnalise()
        {
            // Arrange
            var proposta = new Proposta("Cliente", 2000m);
            proposta.Aprovar();

            // Act
            proposta.MarcarEmAnalise();

            // Assert
            Assert.Equal(StatusProposta.EmAnalise, proposta.Status);
        }

        [Fact]
        public void Cliente_DeveSerSomenteLeitura()
        {
            // Arrange
            var proposta = new Proposta("Cliente", 500m);

            // Assert
            var prop = typeof(Proposta).GetProperty(nameof(Proposta.Cliente));
            Assert.True(prop?.SetMethod?.IsPrivate); // deve ser apenas leitura (private set)
        }

        [Fact]
        public void Valor_DeveSerSomenteLeitura()
        {
            var property = typeof(Proposta).GetProperty(nameof(Proposta.Valor))!;
            Assert.NotNull(property);
            Assert.True(property.SetMethod?.IsPrivate); // Verifica se o set é privado
        }

        [Fact]
        public void Status_DeveSerSomenteAlteradoPorMetodos()
        {
            var property = typeof(Proposta).GetProperty(nameof(Proposta.Status))!;
            Assert.NotNull(property);
            Assert.True(property.SetMethod?.IsPrivate); // agora verifica corretamente se o set é privado
        }
    }
}
