namespace Modules.Shared.Exceptions;

public class NotFoundException(string message) : BaseAppException(message, 404);