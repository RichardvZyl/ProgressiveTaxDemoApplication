using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApp.Database;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Id);
        builder.Property(x => x.PostalCode);
        builder.Property(x => x.Salary).HasColumnType("DECIMAL(9, 2)");
        builder.Property(x => x.Email).HasMaxLength(250); // no unnecessarily large NVarChar(Max) ColumnTypes

        builder.Property(x => x.LastUpdated);

        builder.Ignore(x => x.IsDeleted); // Soft delete not implemented here
    }
}
