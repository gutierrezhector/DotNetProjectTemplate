namespace SaM.Core.Exceptions.Implementations;

public class UnauthorizedException(string message) : SaMException(message)
{
}