namespace PicPay.Simplificado.Domain.Core.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    bool Commit();

    IUsuarioComunRepositorio UsuarioComunRepositorio { get; }
    IUsuarioLojistaRepositorio UsuarioLojistaRepositorio { get; }
    ITransfereneciaRepositorio TransfereneciaRepositorio { get; }
}