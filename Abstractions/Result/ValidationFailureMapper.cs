using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Abstractions.Results;

public static class ValidationFailureMapper
{
    public static async Task<IActionResult> ToResponse(this IEnumerable<ValidationFailure> failure)
        => await Result.FailAsync(string.Join(", \n", failure), 204).ResultAsync();
}
