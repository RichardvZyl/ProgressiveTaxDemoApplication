using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.EndPoints.Extensions;

public class AddTaxToUserModel : IMappingAction<User, UserModel>
{
    private readonly ITaxCalculationService _taxCalculationService;

    public AddTaxToUserModel(ITaxCalculationService taxCalculationService)
        => _taxCalculationService = taxCalculationService;

    public async void Process(User source, UserModel destination, ResolutionContext context)
        => destination.TaxOnSalary = await _taxCalculationService.CalculateTax(source.Id);
}
