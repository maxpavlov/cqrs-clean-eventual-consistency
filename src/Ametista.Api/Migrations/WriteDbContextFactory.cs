using System;
using System.IO;
using Ametista.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ametista.Api.Migrations
{
    public class WriteDbContextFactory :
        IDesignTimeDbContextFactory<WriteDbContext>
    {
        public WriteDbContext CreateDbContext(string[] args)
        {
            var connectionString = Program.Configuration.GetConnectionString("SqlConnectionString");

            ILogger logger = Program.Configuration.Get<ILogger>();
            
            logger.LogInformation("Example log message");

            return new WriteDbContext(connectionString);
        }
        
        IConfiguration GetAppConfiguration()
        {
            var environmentName =
                Environment.GetEnvironmentVariable(
                    "DOTNETCORE_ENVIRONMENT");

            var dir = Directory.GetParent(AppContext.BaseDirectory);      

            if(EnvironmentName.Development.Equals(environmentName, 
                StringComparison.OrdinalIgnoreCase))
            {                  
                var depth = 0;
                do
                    dir = dir.Parent;
                while (++depth < 5 && dir.Name != "bin");
                dir = dir.Parent;
            }

            var path = dir.FullName;

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
