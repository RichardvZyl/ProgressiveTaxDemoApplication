using Microsoft.EntityFrameworkCore;
using Abstractions.IoC;

namespace ProgressiveTaxDemoApp.Database;
public class ProgressiveTaxDatabaase : DbContext
{
    public ProgressiveTaxDatabaase(DbContextOptions<ProgressiveTaxDatabaase> options) : base(options) {  }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddConfigurationsFromAssembly();
        builder.Seed();
    }
}
