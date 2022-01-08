using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQCalculator.UseCases.Domain.Calculation;
using RabbitMQCalculator.UseCases.Shared.Database.Configuration;

namespace RabbitMQCalculator.UseCases.Shared.Database.Context
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration.GetConnectionString("ElephantSQLConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CalculationEntityTypeConfiguration().Configure(modelBuilder.Entity<CalculationEntity>());
        }

        public DbSet<CalculationEntity> Calculations { get; set; }
    }
}
