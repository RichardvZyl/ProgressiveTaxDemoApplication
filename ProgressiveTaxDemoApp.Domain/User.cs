using Abstractions.Domain;

namespace ProgressiveTaxDemoApp.Domain;

public sealed class User : Entity<Guid>
{
    public User(string email, string postalCode, decimal salary)
    {
        Email = email;
        PostalCode = postalCode;
        Salary = salary;
    }

    public string Email { get; private set; }
    public string PostalCode { get; private set; }
    public decimal Salary { get; private set; }

    public void Update(string postalCode, decimal salary)
    {
        this.PostalCode = postalCode;
        this.Salary = salary;
    }
}
