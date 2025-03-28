namespace PicPay.Simplificado.Infrastructure.Data.Repositories
{
    public class TransferenciaRepositorio : GenericRepository<Transferencia>, ITransfereneciaRepositorio
    {
        public TransferenciaRepositorio(PicPaySimplificadoContext picPaySimplificadoContext) : base(picPaySimplificadoContext)
        {
        }
    }
}