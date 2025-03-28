namespace PicPay.Simplificado.Infrastructure.Data.UOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly PicPaySimplificadoContext _context;

    public UnitOfWork(PicPaySimplificadoContext context)
    {
        _context = context;
    }

    private IUsuarioComunRepositorio _usuarioComunRepositorio;

    public IUsuarioComunRepositorio UsuarioComunRepositorio
    {
        get => _usuarioComunRepositorio ?? (_usuarioComunRepositorio = new UsuarioComunRepositorio(_context));
    }

    private IUsuarioLojistaRepositorio _usuarioLojistaRepositorio;

    public IUsuarioLojistaRepositorio UsuarioLojistaRepositorio
    {
        get => _usuarioLojistaRepositorio ?? (_usuarioLojistaRepositorio = new UsuarioLojistaRepositorio(_context));
    }

    private ITransfereneciaRepositorio _transfereneciaRepositorio;

    public ITransfereneciaRepositorio TransfereneciaRepositorio
    {
        get => _transfereneciaRepositorio ?? (_transfereneciaRepositorio = new TransferenciaRepositorio(_context));
    }

    public bool Commit()
    {
        return _context.SaveChanges() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}