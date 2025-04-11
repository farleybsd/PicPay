namespace PicPay.Simplificado.Domain.ValueObjects;

public class Carteira
{
    public double Saldo { get; private set; }

    public Carteira(double saldo)
    {
        if (saldo < 0)
            throw new SaldoDomainException("Saldo insuficente.");

        Saldo = saldo;
    }

    public void Debitar(double valor)
    {
        if (valor <= 0)
            throw new SaldoDomainException("O valor para débito deve ser maior que zero.");

        if (Saldo < valor)
            throw new SaldoDomainException("Saldo insuficiente.");

        Saldo -= valor;
    }

    public void Creditar(double valor)
    {
        if (valor <= 0)
            throw new SaldoDomainException("O valor para Credito deve ser maior que zero.");

        Saldo += valor;
    }
}