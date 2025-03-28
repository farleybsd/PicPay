namespace PicPay.Simplificado.Domain.ValueObjects;

public class DocCnpj
{
    public string Cnpj { get; }

    public DocCnpj(string cnpj)
    {
        if (string.IsNullOrEmpty(cnpj))
            throw new CnpjDomainException("O Cnpj não pode estar vazio.");

        Cnpj = cnpj.Trim();
    }

    public override string ToString() => Cnpj;
}