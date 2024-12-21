namespace TaskManager.Shared.Core.Exceptions;

public class InternalServerException(string message) : BaseAppException(message, 500);