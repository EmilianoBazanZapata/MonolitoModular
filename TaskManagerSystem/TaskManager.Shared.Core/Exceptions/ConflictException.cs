namespace TaskManager.Shared.Core.Exceptions;

public class ConflictException(string message) : BaseAppException(message, 409) { }