using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApp.Database;

public sealed class TaxCalculationTypeConfiguration : IEntityTypeConfiguration<TaxCalculationType>
{
    public void Configure(EntityTypeBuilder<TaxCalculationType> builder)
    {
        builder.ToTable(nameof(TaxCalculationType));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd(); // Identity Column
        builder.Property(x => x.PostalCode).HasMaxLength(10); // no unnecessarily large NVarChar(Max) ColumnTypes //  the longest postal code currently in use in the world is 10 digits long.
        builder.Property(x => x.TaxType);

        builder.Property(x => x.LastUpdated);

        builder.Ignore(x => x.IsDeleted); // Soft delete not implemented here
    }
}
