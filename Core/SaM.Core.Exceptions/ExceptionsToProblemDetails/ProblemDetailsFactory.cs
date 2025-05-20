using Microsoft.AspNetCore.Mvc;
using SaM.Core.Exceptions.Implementations;

namespace SaM.Core.Exceptions.ExceptionsToProblemDetails;

public static class ProblemDetailsFactory
{
    public static ProblemDetails ValidationFailed(ValidationResultException validationResultException)
    {
        return new ProblemDetails
        {
            Status = 400,
            Title = "Bad Request",
            Detail = validationResultException.Message,
            Type = ProblemTypeUris.BadRequest,
        };
    }

    public static ProblemDetails NotFound(NotFoundException notFoundException)
    {
        return new ProblemDetails
        {
            Status = 404,
            Title = "Not found",
            Detail = notFoundException.Message,
            Type = ProblemTypeUris.NotFound,
        };
    }

    public static ProblemDetails Unauthorized()
    {
        return new ProblemDetails
        {
            Status = 401,
            Title = "Unauthorized",
            Detail = "You are not authorized to access this resource.",
            Type = ProblemTypeUris.Unauthorized,
        };
    }

    public static ProblemDetails Forbidden()
    {
        return new ProblemDetails
        {
            Status = 403,
            Title = "Forbidden",
            Detail = "You lack rights to access this resource.",
            Type = ProblemTypeUris.Forbidden,
        };
    }

    public static ProblemDetails Conflict()
    {
        return new ProblemDetails
        {
            Status = 409,
            Title = "Conflict",
            Detail = "There is a conflict",
            Type = ProblemTypeUris.Conflict,
        };
    }

    public static ProblemDetails DotnetException()
    {
        return new ProblemDetails
        {
            Status = 500,
            Title = "Internal Server Error",
            Detail = "Internal Server Error.",
            Type = ProblemTypeUris.InternalServerError,
        };
    }
}