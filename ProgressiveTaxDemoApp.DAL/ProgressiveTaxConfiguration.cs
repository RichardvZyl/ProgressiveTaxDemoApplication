using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApp.Database;

public sealed class ProgressiveTaxConfiguration : IEntityTypeConfiguration<ProgressiveTax>
{
    public void Configure(EntityTypeBuilder<ProgressiveTax> builder)
    {
        builder.ToTable(nameof(ProgressiveTax));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd(); // Identity Column
        builder.Property(x => x.Rate);
        builder.Property(x => x.From);

        builder.Property(x => x.LastUpdated);
        
        builder.Ignore(x => x.IsDeleted); // Soft delete not implemented here
    }
}
