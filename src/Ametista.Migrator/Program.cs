using System;
using Ametista.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ametista.Migrator
{
    class Program
    {
        private const int ERROR_UNEXPECTED_EXCEPTION = -1;

        static void Main(string[] args)
        {
            try
            {
                var connectionString = ConfigurationProvider.DbConnectionString;
                using (var db = new WriteDbContext(connectionString))
                {
                    Console.WriteLine("Starting migrations for " + connectionString);
                    db.Database.Migrate();
                }

                Console.WriteLine("Migrations completed successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected Exception: " + e.Message);
                Environment.Exit(ERROR_UNEXPECTED_EXCEPTION);
            }
        }
    }
}