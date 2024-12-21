namespace TaskManager.Shared.Core.Exceptions;

public class UnauthorizedException(string message) : BaseAppException(message, 401);