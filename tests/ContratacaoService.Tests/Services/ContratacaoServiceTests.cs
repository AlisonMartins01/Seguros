using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Application.Interfaces;
using ContratacaoService.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Seguros.Contracts.Events;
using Xunit;

namespace ContratacaoServices.Tests.Services
{
    public class ContratacaoServiceTests
    {
        private readonly Mock<ILogger<ContratacaoService.Application.Services.ContratacaoService>> _loggerMock;
        private readonly Mock<IContratarPropostaUseCase> _useCaseMock;
        private readonly IContratacaoService _service;

        public ContratacaoServiceTests()
        {
            _loggerMock = new Mock<ILogger<ContratacaoService.Application.Services.ContratacaoService>>();
            _useCaseMock = new Mock<IContratarPropostaUseCase>();
            _service = new ContratacaoService.Application.Services.ContratacaoService(_useCaseMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task ProcessarAsync_DeveLogarInicioEFim()
        {
            // Arrange
            var proposta = new PropostaAprovadaEvent
            {
                PropostaId = Guid.NewGuid(),
                Cliente = "Cliente Teste",
                Valor = 999
            };

            // Act
            await _service.ProcessarAsync(proposta);

            // Assert
            _loggerMock.Verify(l => l.Log(
                It.Is<LogLevel>(lvl => lvl == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Iniciando processo")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);

            _loggerMock.Verify(l => l.Log(
                It.Is<LogLevel>(lvl => lvl == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Processo de contratação finalizado")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);
        }
    }
}
