namespace PicPay.Simplificado.Domain.Exceptions;

public class CpfDomainException : Exception
{
    public CpfDomainException(string message) : base(message)
    {
    }
}