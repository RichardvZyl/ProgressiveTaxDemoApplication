using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;
using ProgressiveTaxDemoApplication.DAL;

namespace ProgressiveTaxDemoApp.Framework;

public sealed class TaxCalculationService : ITaxCalculationService
{
    private IDictionary<int, ProgressiveTax>? _progressiveTaxes { get; set; }
    private IDictionary<int, TaxCalculationType>? _taxCalculationTypes { get; set; }
    private IDictionary<Guid, User>? _users { get; set; }


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

    public async Task GetDataTables()
    {
        _progressiveTaxes = await _progressiveTaxRepository.GetTableAsync();
        _taxCalculationTypes = await _taxCalculationTypeRepository.GetTableAsync();
        _users = await _userRepository.GetTableAsync();
    }

    //If any of the other entities in program context is updated all tax needs to be recalculated
    public async Task<decimal> CalculateTax(Guid userId)
    {
        await GetDataTables();

        if (_taxCalculationTypes is null || _users is null || _progressiveTaxes is null)
            throw new ArgumentNullException();

        var user = await _userRepository.GetByIdAsync(userId);

        var taxType = _taxCalculationTypes.FirstOrDefault(x => x.Value.PostalCode == user.PostalCode);

        var taxOnSalary = taxType.Value.TaxType switch
        {
            TaxType.Progressive => CalculateProgressiveTax(user.Salary),
            TaxType.FlatValue => CalculateFlatValue(user.Salary),
            TaxType.FlatRate => CalculateFlatRate(user.Salary),
            _ => decimal.Zero
        };

        return taxOnSalary;
    }

    private decimal CalculateProgressiveTax(decimal salary)
    {
        var taxOnSalary = 0M;
        var monthlySalary = salary / 12M;

        foreach (var progressiveTax in _progressiveTaxes!)
            taxOnSalary += (monthlySalary < ((progressiveTax.Value.From <= 0M) ? 1M : progressiveTax.Value.From) - 1M) ? (monthlySalary * (progressiveTax.Value.Rate / 100)) : 0;

        return taxOnSalary;
    }

    //However unlikely if a user earns less than 10,000 per year I assume he is not taxed
    private static decimal CalculateFlatValue(decimal salary)
        => (salary > 200000) ? salary * 0.05M : (salary < 10000M) ? salary : salary -10000M;

    private static decimal CalculateFlatRate(decimal salary)
        => salary * 0.175M;
}