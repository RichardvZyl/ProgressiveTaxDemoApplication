using Microsoft.EntityFrameworkCore;
using Abstractions.IoC;

namespace ProgressiveTaxDemoApp.Database;
public class ProgressiveTaxDatabase : DbContext
{
    public ProgressiveTaxDatabase(DbContextOptions<ProgressiveTaxDatabase> options) : base(options) {  }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddConfigurationsFromAssembly();
        builder.Seed();
    }
}
