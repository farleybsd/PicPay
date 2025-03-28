namespace PicPay.Simplificado.Domain.ValueObjects;

public class TransferenciaSaldo
{
    public double Saldo { get; }

    public TransferenciaSaldo(double saldo)
    {
        if (saldo < 0)
            throw new SaldoDomainException("Saldo insuficente.");

        Saldo = saldo;
    }
}