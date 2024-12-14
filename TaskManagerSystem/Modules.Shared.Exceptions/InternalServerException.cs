namespace Modules.Shared.Exceptions;

public class InternalServerException(string message) : BaseAppException(message, 500);