using Abstractions.Results;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using IResult = Abstractions.Results.IResult;

namespace Abstractions.Validator;

public class ResultFilter<T> : IRouteHandlerFilter where T : class
{
    private readonly IValidator<T> _validator;

    public ResultFilter(IValidator<T> validator) => _validator = validator;

    // this is a temporary work around to allow for the Result pattern in minimal API's I only later realized I would be returning the result object which is not what I wanted
    // but it also allows me to abstract validation!
    // TODO: Add to personal Nuget Repository once .net 7.0 releases
    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next)
    {
        var validatable = context.Parameters.SingleOrDefault(x => x?.GetType() == typeof(T)) as T;

        if (validatable is null)
            return await Result.FailAsync(string.Empty, 400).ResultAsync();

        var validationResult = await _validator.ValidateAsync(validatable);

        if (!validationResult.IsValid)
            return await validationResult.Errors.ToResponse();

        // before endpoint call // used for validation or middleware
        var result = await next(context);

        // after endpoint call I can now execute my result
        return Task.FromResult(result as IResult ?? await Result.SuccessAsync("", 204))?.ResultAsync();
    }
}
