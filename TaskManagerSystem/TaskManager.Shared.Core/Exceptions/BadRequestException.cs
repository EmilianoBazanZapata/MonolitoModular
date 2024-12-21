namespace TaskManager.Shared.Core.Exceptions;

public class BadRequestException(string message) : BaseAppException(message, 400);