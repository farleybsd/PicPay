using PicPay.Simplificado.Domain.ValueObjects;

namespace PicPay.Simplificado.Domain.Core.Interfaces.Patterns;
public class CreditarTransaction : ITransactionCommand
{
    private readonly Carteira _carteira;
    private readonly double _valor;
    public CreditarTransaction(Carteira carteira, double valor)
    {
        _carteira = carteira;
        _valor = valor;
    }
       
    public void Commit()
    {
        _carteira.Creditar(_valor);
    }

    public void Rollback()
    {
        _carteira.Debitar(_valor);
    }
}
