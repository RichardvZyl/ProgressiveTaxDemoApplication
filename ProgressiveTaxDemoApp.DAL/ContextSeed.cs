using Microsoft.EntityFrameworkCore;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;

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
                Id = 1,
                LastUpdated = DateTimeOffset.UtcNow,
                PostalCode = "7441",
                TaxType = TaxType.Progressive
            },
            new
            {
                Id = 2,
                LastUpdated = DateTimeOffset.UtcNow,
                PostalCode = "A100",
                TaxType = TaxType.FlatValue
            },
            new
            {
                Id = 3,
                LastUpdated = DateTimeOffset.UtcNow,
                PostalCode = "7000",
                TaxType = TaxType.FlatRate
            },
            new
            {
                Id = 4,
                LastUpdated = DateTimeOffset.UtcNow,
                PostalCode = "1000",
                TaxType = TaxType.Progressive
            });
        });
    }

    public static void SeedProgressiveTaxEndpointDefinition(this ModelBuilder builder)
    {
        builder.Entity<ProgressiveTax>(x =>
        {
            x.HasData(new
            {
                Id = 1,
                LastUpdated = DateTimeOffset.UtcNow,
                From = 0,
                Rate = 10
            },
            new
            {
                Id = 2,
                LastUpdated = DateTimeOffset.UtcNow,
                From = 8351,
                Rate = 15
            },
            new
            {
                Id = 3,
                LastUpdated = DateTimeOffset.UtcNow,
                From = 33951,
                Rate = 25
            },
            new
            {
                Id = 4,
                LastUpdated = DateTimeOffset.UtcNow,
                From = 82251,
                Rate = 28
            },
            new
            {
                Id = 5,
                LastUpdated = DateTimeOffset.UtcNow,
                From = 171151,
                Rate = 33
            },
            new
            {
                Id = 6,
                LastUpdated = DateTimeOffset.UtcNow,
                From = 372951,
                Rate = 35
            });
        });
    }

    public static void SeedUsers(this ModelBuilder builder)
    {
        builder.Entity<User>(x =>
        {
            x.HasData(new
            {
                Id = Guid.NewGuid(),
                LastUpdated = DateTimeOffset.UtcNow,
                Email = "example@example.com",
                PostalCode = "7441"
            },
            new
            {
                Id = Guid.NewGuid(),
                LastUpdated = DateTimeOffset.UtcNow,
                Email = "test@test.com",
                PostalCode = "A100"
            },
            new
            {
                Id = Guid.NewGuid(),
                LastUpdated = DateTimeOffset.UtcNow,
                Email = "test@example.com",
                PostalCode = "7000"
            },
            new
            {
                Id = Guid.NewGuid(),
                LastUpdated = DateTimeOffset.UtcNow,
                Email = "example@test.com",
                PostalCode = "1000"
            });
        });
    }

}
