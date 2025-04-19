using Microsoft.AspNetCore.Mvc;

namespace SaM.Core.Exceptions.ExceptionsToProblemDetails;

public static class ProblemDetailsFactory
{
    public static ProblemDetails NotFound()
    {
        return new ProblemDetails
        {
            Status = 404,
            Title = "Not Found",
            Detail = "Resource was not found."
        };
    }

    public static ProblemDetails Unauthorized()
    {
        return new ProblemDetails
        {
            Status = 401,
            Title = "Unauthorized",
            Detail = "You are not authorized to access this resource."
        };
    }

    public static ProblemDetails Forbidden()
    {
        return new ProblemDetails
        {
            Status = 403,
            Title = "Forbidden",
            Detail = "You lack rights to access this resource."
        };
    }

    public static ProblemDetails Conflict()
    {
        return new ProblemDetails
        {
            Status = 409,
            Title = "Conflict",
            Detail = "There is a conflict"
        };
    }
}