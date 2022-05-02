using Newtonsoft.Json;

namespace ProgressiveTaxDemoApp.Models;

public class UserModel
{
    public Guid Id { get; set; }


    public string Email { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;


    [JsonProperty(PropertyName = "Salary")]
    public decimal BrutoSalary { get; set; }

    public decimal? TaxOnSalary { get; set; } = decimal.Zero;

    public decimal NetSalary => BrutoSalary - TaxOnSalary ?? 0M;
}
