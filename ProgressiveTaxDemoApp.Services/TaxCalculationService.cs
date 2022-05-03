using ProgressiveTaxDemoApp.Models;
using ProgressiveTaxDemoApplication.DAL;

namespace ProgressiveTaxDemoApp.Framework;

public sealed class TaxCalculationService : ITaxCalculationService
{
    private readonly IProgressiveTaxRepository _progressiveTaxRepository;
    private readonly ITaxCalculationTypeRepository _taxCalculationTypeRepository;
    private readonly IUserRepository _userRepository;

    public TaxCalculationService
    (
        IProgressiveTaxRepository progressiveTaxRepository,
        ITaxCalculationTypeRepository taxCalculationTypeRepository,
        IUserRepository userRepository
    )
    {
        _progressiveTaxRepository = progressiveTaxRepository;
        _taxCalculationTypeRepository = taxCalculationTypeRepository;
        _userRepository = userRepository;
    }

    public async Task<decimal> CalculateTax(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        var taxType = (await _taxCalculationTypeRepository.ListAsync()).FirstOrDefault(x => x.PostalCode == user.PostalCode);

        var taxOnSalary = taxType?.TaxType switch
        {
            TaxType.Progressive => await CalculateProgressiveTax(user.Salary),
            TaxType.FlatValue => CalculateFlatValue(user.Salary),
            TaxType.FlatRate => CalculateFlatRate(user.Salary),
            _ => decimal.Zero
        };

        return taxOnSalary;
    }

    private async Task<decimal> CalculateProgressiveTax(decimal salary)
    {
        var taxOnSalary = 0M;
        var monthlySalary = salary / 12M;

        foreach (var progressiveTax in await _progressiveTaxRepository.ListAsync())
            taxOnSalary += (monthlySalary < ((progressiveTax.From <= 0M) ? 1M : progressiveTax.From) - 1M) ? (monthlySalary * (progressiveTax.Rate / 100)) : 0;

        return taxOnSalary;
    }

    //However unlikely if a user earns less than 10,000 per year I assume he is not taxed
    private static decimal CalculateFlatValue(decimal salary)
        => (salary > 200000) ? salary * 0.05M : (salary < 10000M) ? salary : salary - 10000M;

    private static decimal CalculateFlatRate(decimal salary)
        => salary * 0.175M;
}