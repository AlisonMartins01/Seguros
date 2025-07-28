using ContratacaoService.API;
using ContratacaoService.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContratacaoService.IntegrationTest;
public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            builder.UseEnvironment("Testing");
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<ContratacaoDbContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<ContratacaoDbContext>(options =>
                options.UseInMemoryDatabase("IntegrationTestDb"));

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ContratacaoDbContext>();
            db.Database.EnsureCreated();
        });
    }
}


