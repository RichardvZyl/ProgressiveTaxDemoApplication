using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApp.Database;

public sealed class ProgressiveTaxConfiguration : IEntityTypeConfiguration<ProgressiveTax>
{
    public void Configure(EntityTypeBuilder<ProgressiveTax> builder)
    {

    }
}
