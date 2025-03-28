namespace PicPay.Simplificado.Infrastructure.Data.Repositories
{
    public class UsuarioComunRepositorio : GenericRepository<UsuarioComun>, IUsuarioComunRepositorio
    {
        public UsuarioComunRepositorio(PicPaySimplificadoContext picPaySimplificadoContext) : base(picPaySimplificadoContext)
        {
        }
    }
}