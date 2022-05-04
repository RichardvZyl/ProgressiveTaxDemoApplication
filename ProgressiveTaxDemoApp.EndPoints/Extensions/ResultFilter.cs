using Abstractions.Results;
using Microsoft.AspNetCore.Http;
using IResult = Abstractions.Results.IResult;

namespace ProgressiveTaxDemoApp.Endpoints;

public class ResultFilter : IRouteHandlerFilter
{
    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next)
    {
        // before endpoint call // used for validation or middleware
        var result = await next(context);
        // after endpoint call I can now execute my result
        return Task.FromResult(result as IResult ?? await Result.SuccessAsync("", 204))?.ResultAsync();
    }
}
