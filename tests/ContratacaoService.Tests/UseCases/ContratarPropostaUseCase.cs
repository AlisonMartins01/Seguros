using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Application.Interfaces;
using ContratacaoService.Application.UseCase;
using ContratacaoService.Domain.Entities;
using ContratacaoService.Domain.Repository;
using Moq;
using Seguros.Contracts.Events;
using Xunit;

namespace ContratacaoServices.Tests.UseCases
{
    public class ContratarPropostaUseCaseTests
    {
        private readonly Mock<IContratacaoRepository> _contratacaoRepositoryMock = new();
        private readonly IContratarPropostaUseCase _useCase;

        public ContratarPropostaUseCaseTests()
        {
            _useCase = new ContratarPropostaUseCase(_contratacaoRepositoryMock.Object);
        }

        [Fact]
        public async Task ExecuteAsync_DeveInserirContratacao()
        {
            // Arrange
            var proposta = new PropostaAprovadaEvent
            {
                PropostaId = Guid.NewGuid(),
                Cliente = "João",
                Valor = 1200
            };

            // Act
            await _useCase.ExecuteAsync(proposta);

            // Assert
            _contratacaoRepositoryMock.Verify(x => x.AdicionarAsync(It.Is<Contratacao>(
                c => c.PropostaId == proposta.PropostaId && c.Cliente == "João" && c.Valor == 1200)), Times.Once);
        }
    }
}
