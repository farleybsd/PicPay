using PicPay.Simplificado.Domain.Core.Interfaces.Repositories;
using PicPay.Simplificado.Domain.Entidades;
using PicPay.Simplificado.Infrastructure.Data.Context;
using PicPay.Simplificado.Infrastructure.Data.Repositories.Base;

namespace PicPay.Simplificado.Infrastructure.Data.Repositories
{
    public class UsuarioLojistaRepositorio : GenericRepository<UsuarioLojista>, IUsuarioLojistaRepositorio
    {
        public UsuarioLojistaRepositorio(PicPaySimplificadoContext picPaySimplificadoContext) : base(picPaySimplificadoContext)
        {
            
        }
    }
}
