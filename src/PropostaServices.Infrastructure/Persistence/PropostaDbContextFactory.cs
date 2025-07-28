using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PropostaServices.Infrastructure.Persistence
{
    public class PropostaDbContextFactory : IDesignTimeDbContextFactory<PropostaDbContext>
    {
        public PropostaDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PropostaDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SqlServer"),
                sql => sql.MigrationsAssembly(typeof(PropostaDbContext).Assembly.FullName));

            return new PropostaDbContext(optionsBuilder.Options);
        }
    }
}
