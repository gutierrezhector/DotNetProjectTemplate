namespace SaM.Core.Exceptions.Implementations;

public class ForbiddenException(string message) : SaMException(message)
{
}