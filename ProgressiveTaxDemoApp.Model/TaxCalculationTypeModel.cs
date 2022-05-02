using System.Text.Json.Serialization;

namespace ProgressiveTaxDemoApp.Models;

public class TaxCalculationTypeModel
{
    public int Id { get; set; }

    public string PostalCode { get; set; } = string.Empty;
    public TaxType TaxType { get; set; }
}
