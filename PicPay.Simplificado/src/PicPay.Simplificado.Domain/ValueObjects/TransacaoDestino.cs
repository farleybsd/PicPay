namespace PicPay.Simplificado.Domain.ValueObjects;

public class TransacaoDestino
{
    public string NomeCompleto { get; }

    public TransacaoDestino(string nomeCompleto)
    {
        if (string.IsNullOrWhiteSpace(nomeCompleto))
            throw new NomeCompletoDomainException("O nome completo não pode estar vazio.");

        NomeCompleto = nomeCompleto.Trim();
    }

    public override string ToString() => NomeCompleto;
}