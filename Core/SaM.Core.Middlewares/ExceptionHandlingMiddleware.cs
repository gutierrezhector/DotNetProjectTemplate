using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaM.Core.Exceptions;
using SaM.Core.Exceptions.ExceptionsToProblemDetails;

namespace SaM.Core.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var problemDetails = GenerateProblemDetails(ex);
            
            context.Response.StatusCode = (int)problemDetails.Status!;
            context.Response.ContentType = "application/json";
            
            var json = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(json);
        }
    }

    private static ProblemDetails GenerateProblemDetails(Exception ex)
    {
        if (ex is SaMException saMException)
        {
            return ProblemDetailsHelper.GenerateProblemDetailsFromSaMException(saMException);
        }

        return ProblemDetailsHelper.GenerateProblemDetailsFromDotnetException();
    }
}