using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApp.Database;

public sealed class TaxCalculationTypeConfiguration : IEntityTypeConfiguration<TaxCalculationType>
{
    public void Configure(EntityTypeBuilder<TaxCalculationType> builder)
    {

    }
}
