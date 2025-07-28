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
using Xunit;

namespace ContratacaoServices.Tests.UseCases
{
    public class ListarContratacoesUseCaseTests
    {
        private readonly Mock<IContratacaoRepository> _repositoryMock = new();
        private readonly IListarContratacoesUseCase _useCase;

        public ListarContratacoesUseCaseTests()
        {
            _useCase = new ListarContratacoesUseCase(_repositoryMock.Object);
        }

        [Fact]
        public async Task ExecuteAsync_DeveRetornarListaDeContratacoes()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ListarTodasAsync())
                .ReturnsAsync([new Contratacao(Guid.NewGuid(), "Maria", 500)]);

            // Act
            var result = await _useCase.ExecuteAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal("Maria", result.First().Cliente);
        }
    }
}
