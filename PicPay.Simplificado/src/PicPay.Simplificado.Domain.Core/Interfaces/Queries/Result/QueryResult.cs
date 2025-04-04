namespace PicPay.Simplificado.Domain.Core.Interfaces.Queries.Result;

public class QueryResult<T>
{
    public bool Success { get; }
    public string Message { get; set; }
    public T Data { get; set; }

    public QueryResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}