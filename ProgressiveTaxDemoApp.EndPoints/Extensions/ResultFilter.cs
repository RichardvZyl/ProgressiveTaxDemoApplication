using Abstractions.Results;
using Microsoft.AspNetCore.Http;
using IResult = Abstractions.Results.IResult;

namespace ProgressiveTaxDemoApp.Endpoints;

public class ResultFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        // before endpoint call // used for validation or middleware
        var result = await next(context);
        // after endpoint call I can now execute my result
        return Task.FromResult(result as IResult ?? await Result.SuccessAsync("", 204))?.ResultAsync();
    }
}
