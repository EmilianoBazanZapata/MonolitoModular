namespace Modules.Shared.Entities;

public class SuccessResponse<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}