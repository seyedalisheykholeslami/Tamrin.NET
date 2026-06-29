namespace Tamrin.Share;

public class OperationResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;

    public static OperationResult Success()
    {
        return new OperationResult
        {
            IsSuccess = true,
            Message = "Success"
        };
    }
    public static OperationResult Feilure(string msg)
    {
        return new OperationResult
        {
            IsSuccess = true,
            Message = msg
        };
    }
}
public class OperationResult<T> : OperationResult
{
    public T? Data { get; set; }
    public static  OperationResult<T> Success(T data)
    {
        return new OperationResult<T>
        {
            Data =  data,
            IsSuccess = true,
            Message = "Success"
        };
    }
    public new static  OperationResult<T> Feilure(string msg)
    {
        return new OperationResult<T>
        {
            IsSuccess = true,
            Message = msg
        };
    }
}