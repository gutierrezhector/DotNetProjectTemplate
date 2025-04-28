using FluentValidation.Results;

namespace SaM.Core.Exceptions.Implementations;

public class ValidationResultException(ValidationResult result) : SaMException(GenerateErrorMessage(result))
{
    private static string GenerateErrorMessage(ValidationResult result)
    {
        var errorMessages = result.Errors.Select(e => e.ErrorMessage);
        return string.Join(", ", errorMessages);
    }
}