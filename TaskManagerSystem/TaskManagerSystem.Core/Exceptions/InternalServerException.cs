namespace TaskManagerSystem.Core.Exceptions;

public class InternalServerException(string message) : BaseAppException(message, 500);