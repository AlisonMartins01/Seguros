using PropostaServices.Application.UseCases;
using PropostaServices.Domain.Interfaces;
using PropostaServices.Domain.Enums;
using PropostaServices.Domain.Entities;
using Moq;
using MassTransit;

namespace PropostaServices.Tests.UseCases;
public class AlterarStatusPropostaUseCaseTests
{
    private AlterarStatusPropostaUseCase CriarUseCase(Proposta proposta)
    {
        var repoMock = new Mock<IPropostaRepository>();
        repoMock.Setup(r => r.ObterPorIdAsync(proposta.Id)).ReturnsAsync(proposta);
        var publishMock = new Mock<IPublishEndpoint>();
        publishMock.Setup(p => p.Publish(It.IsAny<object>(), default)).Returns(Task.CompletedTask);

        return new AlterarStatusPropostaUseCase(repoMock.Object, publishMock.Object);
    }
    [Fact]
    public async Task Deve_aprovar_proposta_em_analise()
    {
        var proposta = new Proposta("Cliente", 1000m);
        var useCase = CriarUseCase(proposta);

        var resultado = await useCase.ExecutarAsync(proposta.Id, StatusProposta.Aprovada);

        Assert.True(resultado);
        Assert.Equal(StatusProposta.Aprovada, proposta.Status);
    }
    [Fact]
    public async Task Deve_rejeitar_proposta_em_analise()
    {
        var proposta = new Proposta("Cliente", 1000m);
        var useCase = CriarUseCase(proposta);

        var resultado = await useCase.ExecutarAsync(proposta.Id, StatusProposta.Rejeitada);

        Assert.True(resultado);
        Assert.Equal(StatusProposta.Rejeitada, proposta.Status);
    }
    [Fact]
    public async Task Nao_deve_alterar_para_em_analise()
    {
        var proposta = new Proposta("Cliente", 1000m);
        proposta.Aprovar();
        var useCase = CriarUseCase(proposta);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            useCase.ExecutarAsync(proposta.Id, StatusProposta.EmAnalise));
    }
    [Fact]
    public async Task Nao_deve_alterar_status_se_nao_estiver_em_analise()
    {
        var proposta = new Proposta("Cliente", 1000m);
        proposta.Aprovar();
        var useCase = CriarUseCase(proposta);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            useCase.ExecutarAsync(proposta.Id, StatusProposta.Rejeitada));
    }

    [Fact]
    public async Task Deve_retornar_false_quando_proposta_nao_existir()
    {
        var repoMock = new Mock<IPropostaRepository>();
        repoMock.Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>())).ReturnsAsync((Proposta?)null);

        var publishMock = new Mock<IPublishEndpoint>();
        var useCase = new AlterarStatusPropostaUseCase(repoMock.Object, publishMock.Object);

        var resultado = await useCase.ExecutarAsync(Guid.NewGuid(), StatusProposta.Aprovada);

        Assert.False(resultado);
    }

}
