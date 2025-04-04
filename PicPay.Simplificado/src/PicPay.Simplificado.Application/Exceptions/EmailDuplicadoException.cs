namespace PicPay.Simplificado.Application.Exceptions;

public class EmailDuplicadoException : Exception
{
    public EmailDuplicadoException()
        : base("E-mail já cadastrado.")
    {
    }

    public EmailDuplicadoException(string message)
        : base(message)
    {
    }
}