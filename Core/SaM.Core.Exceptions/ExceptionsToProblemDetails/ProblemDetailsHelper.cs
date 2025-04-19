using Microsoft.AspNetCore.Mvc;
using SaM.Core.Exceptions.Implementations;

namespace SaM.Core.Exceptions.ExceptionsToProblemDetails;

public static class ProblemDetailsHelper
{
    public static ProblemDetails GenerateProblemDetailsFromSaMException(SaMException exception)
    {
        return exception switch
        {
            ConflictException => ProblemDetailsFactory.Conflict(),
            ForbiddenException => ProblemDetailsFactory.Forbidden(),
            UnauthorizedException => ProblemDetailsFactory.Unauthorized(),
            NotFoundException => ProblemDetailsFactory.NotFound(),
            _ => throw new ArgumentOutOfRangeException(nameof(exception))
        };
    }
}