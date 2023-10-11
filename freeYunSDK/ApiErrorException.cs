namespace freeYunSDK;

[Serializable]
public class ApiErrorException : Exception
{
    private int Code { get; set; }

    public ApiErrorException(int code)
    {
        Code = code;
    }

    public ApiErrorException(string? message, int code) : base(message)
    {
        Code = code;
    }

    public ApiErrorException(string? message, Exception? innerException, int code) : base(message, innerException)
    {
        Code = code;
    }
}