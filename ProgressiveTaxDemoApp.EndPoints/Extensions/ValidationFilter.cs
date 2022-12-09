using Abstractions.Results;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using IResult = Abstractions.Results.IResult;

namespace ProgressiveTaxDemoApp.Endpoints;

public class ValidationFilter<T> : IEndpointFilter where T : class
{
    private readonly IValidator<T> _validator;

    public ValidationFilter(IValidator<T> validator) => _validator = validator;


    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validatable = context.Arguments.SingleOrDefault(x => x?.GetType() == typeof(T)) as T;

        if (validatable is null)
            return await Result.FailAsync(string.Empty, 400).ResultAsync();

        var validationResult = await _validator.ValidateAsync(validatable);

        if (!validationResult.IsValid)
            return await Result.FailAsync(validationResult.Errors.ToString() ?? string.Empty, 204).ResultAsync();

        // before endpoint call // used for validation or middleware
        var result = await next(context);

        // after endpoint call I can now execute my result
        return Task.FromResult(result as IResult ?? await Result.SuccessAsync(string.Empty, 204))?.ResultAsync();
    }
}
