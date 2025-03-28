namespace PicPay.Simplificado.Domain.Exceptions;

public class CnpjDomainException : Exception
{
    public CnpjDomainException(string message) : base(message)
    {
    }
}