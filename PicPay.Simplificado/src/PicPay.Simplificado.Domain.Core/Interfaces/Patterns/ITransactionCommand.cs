namespace PicPay.Simplificado.Domain.Core.Interfaces.Patterns;
public interface ITransactionCommand
{
    void Commit();
    void Rollback();
}
