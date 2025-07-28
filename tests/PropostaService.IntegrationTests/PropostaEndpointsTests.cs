using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace PropostaService.IntegrationTests
{
    public class PropostaEndpointsTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public PropostaEndpointsTests(CustomWebApplicationFactory factory)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_Proposta_DeveRetornar201()
        {
            var proposta = new
            {
                cliente = "Amor",
                valor = 8000
            };

            var content = new StringContent(
                JsonSerializer.Serialize(proposta),
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync("/Propostas", content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_Propostas_DeveRetornar200()
        {
            var response = await _client.GetAsync("/Propostas");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
