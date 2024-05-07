namespace CorePackages.Application.Wrappers;

public class ServiceResponse<T>
{
    public T Value { get; set; }

    public bool Success { get; set; }
    public string Message { get; set; }

    public ServiceResponse(T value)
    {
        Value = value;
        Success = true;
        Message = string.Empty;
    }
    public ServiceResponse(string message)
    {
        Success = false;
        Message = message;
    }

    public ServiceResponse()
    {
        
    }
}
