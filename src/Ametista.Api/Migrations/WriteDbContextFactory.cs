using System;
using Ametista.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ametista.Api.Migrations
{
    public class WriteDbContextFactory :
        IDesignTimeDbContextFactory<WriteDbContext>
    {
        public WriteDbContext CreateDbContext(string[] args)
        {
            var connectionString = Program.Configuration.GetConnectionString("MigrationConnection");

            return new WriteDbContext(connectionString);
        }
    }
}
