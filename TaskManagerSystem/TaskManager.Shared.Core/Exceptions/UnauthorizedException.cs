namespace Modules.Shared.Exceptions;

public class UnauthorizedException(string message) : BaseAppException(message, 401);