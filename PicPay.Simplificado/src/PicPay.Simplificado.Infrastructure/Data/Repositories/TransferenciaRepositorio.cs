using PicPay.Simplificado.Domain.Core.Interfaces.Repositories;
using PicPay.Simplificado.Domain.Entidades;
using PicPay.Simplificado.Infrastructure.Data.Context;
using PicPay.Simplificado.Infrastructure.Data.Repositories.Base;

namespace PicPay.Simplificado.Infrastructure.Data.Repositories
{
    public class TransferenciaRepositorio : GenericRepository<Transferencia>, ITransfereneciaRepositorio
    {
        public TransferenciaRepositorio(PicPaySimplificadoContext picPaySimplificadoContext) : base(picPaySimplificadoContext)
        {
            
        }
    }
}
