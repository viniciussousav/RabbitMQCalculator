using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RabbitMQCalculator.UseCases.Domain.Calculation;

namespace RabbitMQCalculator.UseCases.Shared.Database.Configuration
{
    public class CalculationEntityTypeConfiguration : IEntityTypeConfiguration<CalculationEntity>
    {
        public void Configure(EntityTypeBuilder<CalculationEntity> builder)
        {
            builder.HasKey(calculation => calculation.Guid);
            builder.Property(calculation => calculation.FirstNumber).IsRequired();
            builder.Property(calculation => calculation.SecondNumber).IsRequired();
            builder.Property(calculation => calculation.Operator).IsRequired();
        }
    }
}
