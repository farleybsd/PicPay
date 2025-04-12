namespace PicPay.Simplificado.Domain.Core.Interfaces.Patterns;

public class GerenciadorDeTransacoesBancarias
{
    private readonly List<ITransactionCommand> _transacao = new List<ITransactionCommand>();

    public GerenciadorDeTransacoesBancarias(List<ITransactionCommand> transacao)
    {
        _transacao = transacao;
    }

    public void ExecutarTransacao(ITransactionCommand transaction)
    {
        transaction.Commit();
        _transacao.Add(transaction);
    }

    public void DesfazerTransacao(ITransactionCommand transaction)
    {
        if (_transacao.Count > 0)
        {
            var lastTransaction = _transacao[^1];
            transaction.Rollback();
            _transacao.Remove(lastTransaction);
        }
    }
}