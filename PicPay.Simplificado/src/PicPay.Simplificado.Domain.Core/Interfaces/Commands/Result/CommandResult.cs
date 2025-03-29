namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands.Result;

public class CommandResult
{
    public bool Success { get; }
    public string Message { get; set; }
    public object Data { get; set; }

    public CommandResult(bool success, string message, object data = null)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}
