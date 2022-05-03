using Abstractions.Regex;
using FluentValidation;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Validation;
public class UserModelValidator : AbstractValidator<UserModel>
{
    public UserModelValidator()
    {
        RuleFor(x => x.Email)
            .Matches(Regexes.Email)
            .WithMessage("Invalid Email")
            .MaximumLength(250)
            .WithMessage("Email may not exceed 250 characters");

        RuleFor(x => x.BrutoSalary)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Salary cannot be less than 1");

        RuleFor(x => x.PostalCode)
            .MaximumLength(10)
            .WithMessage("Postal code may not exceed 10 characters")
            .MinimumLength(4)
            .WithMessage("Postal code needs to be atleast 4 characters");
    }
}
