namespace PicPay.Simplificado.Infrastructure.Data.Repositories
{
    public class UsuarioLojistaRepositorio : GenericRepository<UsuarioLojista>, IUsuarioLojistaRepositorio
    {
        public UsuarioLojistaRepositorio(PicPaySimplificadoContext picPaySimplificadoContext) : base(picPaySimplificadoContext)
        {
        }
    }
}