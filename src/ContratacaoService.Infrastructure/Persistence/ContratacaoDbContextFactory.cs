using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ContratacaoService.Infrastructure.Persistence
{
    public class ContratacaoDbContextFactory : IDesignTimeDbContextFactory<ContratacaoDbContext>
    {
        public ContratacaoDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ContratacaoDbContext>();
            optionsBuilder.UseSqlServer(
                config.GetConnectionString("SqlServer"),
                sql => sql.MigrationsAssembly(typeof(ContratacaoDbContext).Assembly.FullName)
            );

            return new ContratacaoDbContext(optionsBuilder.Options);
        }
    }
}
