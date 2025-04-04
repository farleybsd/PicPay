using PicPay.Simplificado.Domain.Core.Interfaces.Queries.Result;

namespace PicPay.Simplificado.Domain.Core.Interfaces.Queries.Interfaces;
public interface IQueryUsuarioLojistaAsync
{
    Task<QueryResult<UsuarioLojistaSearchByCnpjResponse>> SearchLojistaUserByCnpj(string cnpj);
}
