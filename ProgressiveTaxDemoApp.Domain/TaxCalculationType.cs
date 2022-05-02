using Abstractions.Domain;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Domain;

public sealed class TaxCalculationType : Entity<int>
{
    public TaxCalculationType(string postalCode, TaxType taxType)
    {
        PostalCode = postalCode;
        TaxType = taxType;
    }

    public string PostalCode { get; private set; } = string.Empty;
    public TaxType TaxType { get; private set; }

    public void Update(string postalCode, TaxType taxType)
    {
        this.PostalCode = postalCode;
        this.TaxType = taxType;
        this.LastUpdated = DateTime.UtcNow;
    }
}
