using PicPay.Simplificado.Domain.Core.Interfaces.Repositories;
using PicPay.Simplificado.Domain.Entidades;
using PicPay.Simplificado.Infrastructure.Data.Context;
using PicPay.Simplificado.Infrastructure.Data.Repositories.Base;

namespace PicPay.Simplificado.Infrastructure.Data.Repositories
{
    public class UsuarioComunRepositorio : GenericRepository<UsuarioComun>, IUsuarioComunRepositorio
    {
        public UsuarioComunRepositorio(PicPaySimplificadoContext picPaySimplificadoContext) : base(picPaySimplificadoContext)
        {
            
        }
    }
}
