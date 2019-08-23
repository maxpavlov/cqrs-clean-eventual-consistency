using Ametista.Core.Cards;
using Ametista.Core.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Ametista.Infrastructure.Persistence
{
    public class WriteDbContext : DbContext
    {
        private readonly string _connectionString;
        
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public WriteDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
            .ToTable("Cards");

            modelBuilder.Entity<Card>()
                .Ignore(x => x.Valid);

            modelBuilder.Entity<Transaction>()
            .ToTable("Transactions");

            modelBuilder.Entity<Transaction>()
                .Ignore(x => x.Valid);

            modelBuilder
                .Entity<Transaction>()
                .OwnsOne(p => p.Charge)
                .Property(p => p.CurrencyCode).HasColumnName("CurrencyCode");

            modelBuilder
                .Entity<Transaction>()
                .OwnsOne(p => p.Charge)
                .Property(p => p.Amount).HasColumnName("Amount");
        }
    }
}