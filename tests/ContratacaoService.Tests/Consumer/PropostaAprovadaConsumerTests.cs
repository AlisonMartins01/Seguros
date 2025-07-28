using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratacaoService.Application.Consumers;
using ContratacaoService.Application.Interfaces;
using ContratacaoService.Application.Services.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using Seguros.Contracts.Events;
using Xunit;

namespace ContratacaoServices.Tests.Consumer
{
    public class PropostaAprovadaConsumerTests
    {
        private readonly Mock<ILogger<PropostaAprovadaConsumer>> _loggerMock;

        public PropostaAprovadaConsumerTests()
        {
            _loggerMock = new Mock<ILogger<PropostaAprovadaConsumer>>();
        }
        [Fact]
        public async Task Consume_DeveChamarUseCase()
        {
            // Arrange
            var useCaseMock = new Mock<IContratacaoService>();
            var consumer = new PropostaAprovadaConsumer(useCaseMock.Object, _loggerMock.Object);

            var contextMock = new Mock<ConsumeContext<PropostaAprovadaEvent>>();
            var proposta = new PropostaAprovadaEvent
            {
                PropostaId = Guid.NewGuid(),
                Cliente = "Cliente Teste",
                Valor = 300
            };

            contextMock.Setup(c => c.Message).Returns(proposta);

            // Act
            await consumer.Consume(contextMock.Object);

            // Assert
            useCaseMock.Verify(u => u.ProcessarAsync(It.Is<PropostaAprovadaEvent>(
                p => p.PropostaId == proposta.PropostaId && p.Cliente == proposta.Cliente)), Times.Once);
        }
    }
}
