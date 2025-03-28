namespace PicPay.Simplificado.Domain.ValueObjects;

public class DocEmail
{
    public string Email { get; }

    public DocEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new EmailDomainException("O Email não pode estar vazio.");

        Email = email.Trim();
    }

    public override string ToString() => Email;
}