namespace VerticalSliceArch.Common.Helpers;

public class CustomResponse<T>
{
    public int StatusCode { get; set; }
    public T Results { get; set; }
    public List<string> Messages { get; set; }
    public Exception Exception { get; set; }
    public string ExceptionRefId { get; set; }

    public CustomResponse()
    {
        StatusCode = 200;
        Messages = new List<string>();
    }
    
    public CustomResponse(int statusCode, T results, List<string> messages = null)
    {
        StatusCode = statusCode;
        Results = results;
        Messages = messages ?? new List<string>();
    }

    
    public CustomResponse(int statusCode, Exception exception, string exceptionRefId, List<string> messages = null)
    {
        StatusCode = statusCode;
        Exception = exception;
        ExceptionRefId = exceptionRefId;
        Messages = messages ?? new List<string>();
    }
}
