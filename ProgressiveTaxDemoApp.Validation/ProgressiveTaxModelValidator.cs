using FluentValidation;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Validation;
public class ProgressiveTaxModelValidator : AbstractValidator<ProgressiveTaxModel>
{
    public ProgressiveTaxModelValidator()
    {
        RuleFor(x => x.From)
            .GreaterThanOrEqualTo(0)
            .WithMessage("From needs to be greater than or equal to 0");

        RuleFor(x => x.Rate)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Rate needs to be greater than or equal to 0")
            .LessThanOrEqualTo(100)
            .WithMessage("Rate cannot exceed 100");
    }
}
