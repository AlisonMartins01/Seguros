using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using RabbitMQ.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using RabbitMQ.Client;
using Xunit;

namespace ContratacaoService.IntegrationTest
{
    public class ContratacaoEndpointsTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ContratacaoEndpointsTests(CustomWebApplicationFactory factory)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Contratacoes_DeveRetornar200()
        {
            var response = await _client.GetAsync("/api/contratacoes");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
