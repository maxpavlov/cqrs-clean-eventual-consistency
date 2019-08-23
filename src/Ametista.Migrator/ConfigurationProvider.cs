using System.IO;
using Microsoft.Extensions.Configuration;

namespace Ametista.Migrator
{
    public static class ConfigurationProvider
    {
        static ConfigurationProvider()
        {
            DbConnectionString = BuildConfiguration().GetConnectionString("DbConnectionString");
        }

        public static string DbConnectionString { get; }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}