namespace PicPay.Simplificado.Domain.ValueObjects;

public class Carteira
{
    public double Saldo { get; }

    public Carteira(double saldo)
    {
        if (saldo < 0)
            throw new SaldoDomainException("Saldo insuficente.");

        Saldo = saldo;
    }
}