using Microsoft.EntityFrameworkCore;
using ProgressiveTaxDemoApp.Domain;

namespace ProgressiveTaxDemoApp.Database;

public static class ContextSeed
{
    public static void Seed(this ModelBuilder builder)
    {
        builder.SeedUsers();
        builder.SeedProgressiveTaxEndpointDefinition();
        builder.SeedTaxCalculationType();
    }

    public static void SeedTaxCalculationType(this ModelBuilder builder)
    {
        builder.Entity<TaxCalculationType>(x =>
        {
            x.HasData(new
            {
                
            });
        });
    }

    public static void SeedProgressiveTaxEndpointDefinition(this ModelBuilder builder)
    {
        builder.Entity<ProgressiveTax>(x =>
        {
            x.HasData(new
            {

            });
        });
    }

    public static void SeedUsers(this ModelBuilder builder)
    {
        builder.Entity<User>(x =>
        {
            x.HasData(new
            {

            });
        });
    }

}
