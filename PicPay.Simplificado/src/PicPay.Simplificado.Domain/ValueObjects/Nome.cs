namespace PicPay.Simplificado.Domain.ValueObjects;

public class Nome
{
    public string NomeCompleto { get; }

    public Nome(string nomeCompleto)
    {
        if (string.IsNullOrWhiteSpace(nomeCompleto))
            throw new NomeCompletoDomainException("O nome completo não pode estar vazio.");

        NomeCompleto = nomeCompleto.Trim();
    }

    public override string ToString() => NomeCompleto;
}