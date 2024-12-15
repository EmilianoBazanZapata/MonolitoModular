namespace Modules.Shared.Exceptions;

public class BadRequestException(string message) : BaseAppException(message, 400);