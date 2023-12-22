namespace DocManager.Core.Domain.ValueObjects;

public class ApplicationResponse<T>
{

    public string[]? ErrorDetails { get; }

    public string? Error { get; }

    public T? Data { get; }

    public bool Success { get; }
    public string Status { get; }
    
    
    private ApplicationResponse(bool success, T? data)
    {
        Success = success;
        Data = data;
        Status = "OK";
    }
    
    private ApplicationResponse(string status, string error, string[]? errorDetails = null)
    {
        Error = error;
        ErrorDetails = errorDetails;
        Status = status;
    }

    public override string ToString()
    {
        if (Success)
        {
            return $"[{Status}] => {typeof(T).Name}";
        }
        return $"ERROR: [{Status}] => {typeof(T).Name}:{Error}" +
               $"\n{string.Join("\n", ErrorDetails ?? Array.Empty<string>())}";
    }

    public static ApplicationResponse<T> Succeed(T? data = default) => new ApplicationResponse<T>(true, data);
    public static ApplicationResponse<T> Fail(string status, string error, string[]? errorDetails = null) => new ApplicationResponse<T>(status, error, errorDetails);
}