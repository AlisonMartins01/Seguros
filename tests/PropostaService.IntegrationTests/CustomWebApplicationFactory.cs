using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using PropostaServices.Application.Services.Interfaces;
using PropostaServices.Domain.Entities;
using PropostaServices.Infrastructure.Persistence;

namespace PropostaService.IntegrationTests
{
    public class CustomWebApplicationFactory : Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                builder.UseEnvironment("Testing");
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<PropostaDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<PropostaDbContext>(options =>
                    options.UseInMemoryDatabase("IntegrationTestDb"));

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<PropostaDbContext>();
                db.Database.EnsureCreated();
               var teste =  new PropostaServices.Application.DTOs.CriarPropostaRequest { Cliente = It.IsAny<string>(), Valor = It.IsAny<decimal>() };
                var propostaServiceMock = new Mock<IPropostaService>();
                propostaServiceMock
                    .Setup(x => x.CriarPropostaAsync(teste))
                    .ReturnsAsync(new Guid()); // ou valor fake esperado

                services.AddSingleton(propostaServiceMock.Object);

                var massTransit = services.Where(s => s.ServiceType.Namespace?.Contains("MassTransit") ?? false).ToList();
                foreach (var s in massTransit)
                    services.Remove(s);
            });
        }
    }
}
