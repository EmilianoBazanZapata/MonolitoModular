namespace Modules.Shared.Exceptions;

public abstract class BaseAppException(string message, int statusCode) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}