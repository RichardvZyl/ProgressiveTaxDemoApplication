using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Abstractions.IoC;

namespace ProgressiveTaxDemoApp.Database;
public class ProgressiveTaxDatabaase : IdentityDbContext
{
    public ProgressiveTaxDatabaase(DbContextOptions<ProgressiveTaxDatabaase> options) : base(options) {  }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddConfigurationsFromAssembly();
        builder.Seed();
    }
}
