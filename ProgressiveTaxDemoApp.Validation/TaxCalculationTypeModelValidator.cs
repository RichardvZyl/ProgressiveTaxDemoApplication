using FluentValidation;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Validation;
public class TaxCalculationTypeModelValidator : AbstractValidator<TaxCalculationTypeModel>
{
    public TaxCalculationTypeModelValidator()
    {
        RuleFor(x => x.PostalCode)
            .MaximumLength(10)
            .WithMessage("Postal code may not exceed 10 characters")
            .MinimumLength(4)
            .WithMessage("Postal code needs to be atleast 4 characters");

        RuleFor(x => x.TaxType)
            .IsInEnum();
    }
}
