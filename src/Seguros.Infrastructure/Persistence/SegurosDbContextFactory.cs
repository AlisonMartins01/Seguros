using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Seguros.Infrastructure.Persistence
{
    public class SegurosDbContextFactory : IDesignTimeDbContextFactory<SegurosDbContext>
    {
        public SegurosDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SegurosDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=SegurosDb;User Id=sa;Password=S3gur0!@123;TrustServerCertificate=True;Encrypt=False");

            return new SegurosDbContext(optionsBuilder.Options);
        }
    }
}
