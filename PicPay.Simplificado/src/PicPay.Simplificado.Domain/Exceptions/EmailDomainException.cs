namespace PicPay.Simplificado.Domain.Exceptions;

public class EmailDomainException : Exception
{
    public EmailDomainException(string message) : base(message)
    {
    }
}