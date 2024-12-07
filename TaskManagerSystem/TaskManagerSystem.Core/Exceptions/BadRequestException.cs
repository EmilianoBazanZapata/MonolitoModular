namespace TaskManagerSystem.Core.Exceptions;

public class BadRequestException(string message) : Exception(message);