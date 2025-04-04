namespace PicPay.Simplificado.Domain.Core.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();

    Task CommitTransactionAsync();

    Task RollbackTransactionAsync();

    bool Commit();

    IUsuarioComunRepositorio UsuarioComunRepositorio { get; }
    IUsuarioLojistaRepositorio UsuarioLojistaRepositorio { get; }
    ITransfereneciaRepositorio TransfereneciaRepositorio { get; }
}