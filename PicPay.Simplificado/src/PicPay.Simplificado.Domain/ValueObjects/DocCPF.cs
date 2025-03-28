namespace PicPay.Simplificado.Domain.ValueObjects;

public class DocCPF
{
    public string Cpf { get; }

    public DocCPF(string cpf)
    {
        if (string.IsNullOrEmpty(cpf))
            throw new CpfDomainException("O CPF não pode estar vazio.");

        Cpf = cpf.Trim();
    }

    public override string ToString() => Cpf;
}