namespace CorePackages.Application.Wrappers;

public class ServiceResponse<T>
{
    public T Value { get; set; }

    public bool Success { get; set; }
    public string Message { get; set; }

    public ServiceResponse(T value)
    {
        Value = value;
        Success = false;
        Message = string.Empty;
    }
    public ServiceResponse()
    {
        
    }
}
