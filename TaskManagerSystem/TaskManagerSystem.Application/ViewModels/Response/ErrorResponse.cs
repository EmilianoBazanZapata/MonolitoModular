namespace TaskManagerSystem.Application.ViewModels.Response;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string ErrorType { get; set; }
    public string Message { get; set; }
    public string TraceId { get; set; }
    public DateTime Timestamp { get; set; }
}