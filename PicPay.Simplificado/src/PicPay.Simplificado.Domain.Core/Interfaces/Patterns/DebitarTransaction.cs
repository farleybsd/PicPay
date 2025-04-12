namespace PicPay.Simplificado.Domain.Core.Interfaces.Patterns;

public class DebitarTransaction : ITransactionCommand
{
    private readonly Carteira _carteira;
    private readonly double _valor;

    public DebitarTransaction(Carteira carteira, double valor)
    {
        _carteira = carteira;
        _valor = valor;
    }

    public void Commit()
    {
        _carteira.Debitar(_valor);
    }

    public void Rollback()
    {
        _carteira.Creditar(_valor);
    }
}