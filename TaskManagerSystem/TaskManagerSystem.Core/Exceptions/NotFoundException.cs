namespace TaskManagerSystem.Core.Exceptions;

public class NotFoundException(string message) : BaseAppException(message, 404);