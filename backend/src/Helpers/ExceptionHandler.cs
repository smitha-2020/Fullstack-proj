using System.Net;

namespace backend.src.Helpers;

public class ExceptionHandler : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public override string Message { get; }
    
    public ExceptionHandler(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public static ExceptionHandler IllegalArgumentException(string message)
    {
        return new ExceptionHandler(HttpStatusCode.Unauthorized, "UnAuthorized Operation");
    }

}